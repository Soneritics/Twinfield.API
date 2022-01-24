using System;
using System.Threading.Tasks;
using Api;
using Api.Dto.OAuth;
using Api.Exceptions;
using Azure;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Newtonsoft.Json;

namespace Demo
{
    /// <summary>
    /// This demo shows how to store the key in KeyVault, so it
    /// can be used for background processes.
    /// </summary>
    public static class KeyVaultDemo
    {
        // OAuth settings
        private static OAuthClientSettings oauthClientSettings = new OAuthClientSettings()
        {
            Id = "",
            Secret = ""
        };

        // This URL should catch the 'code' from the JSON which is POSTed after a successful user login
        private static string redirectUrl = "https://...";

        // Keyvault URL
        private static string keyVaultUrl = "https://{keyVaultName}.vault.azure.net";
        private static string keyVaultSecretName = "TwinfieldAccessToken";

        public static async Task Run()
        {
            Console.WriteLine("Choose 1 or 2:\n\t1. Authorize (only needed once)\n\t2. Load the token from KeyVault and access Twinfield");
            var program = Console.ReadLine();

            switch (program)
            {
                case "1":
                    await AuthorizeAndSaveTokenAsync();
                    break;

                case "2":
                    await LoadTokenFromKeyVaultandRunDemoAsync();
                    break;

                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        }

        private static async Task AuthorizeAndSaveTokenAsync()
        {
            // Create the TwinfieldApi
            var twinfieldApi = new TwinfieldApi(oauthClientSettings);

            // First get the authorization URL
            Console.WriteLine("Send the user to the following URL:");
            Console.WriteLine(twinfieldApi.GetAuthorizationUrl(redirectUrl));

            // Catch the authorization code in your own program, and paste it here
            Console.Write("\n\nEnter the code: ");
            var authenticationCode = Console.ReadLine();

            // Get the access token
            await twinfieldApi
                .SetAccessTokenByAuthorizationCodeAsync(authenticationCode, redirectUrl);

            // Store the access token in KeyVault
            var accessToken = twinfieldApi.Token;
            Console.WriteLine("Saving access token to KeyVault..");
            await StoreAccesstokenInKeyVaultAsync(accessToken);
            Console.WriteLine("Done.");
        }


        private static async Task LoadTokenFromKeyVaultandRunDemoAsync(bool canRetry = true)
        {
            // Create the TwinfieldApi
            var twinfieldApi = new TwinfieldApi(oauthClientSettings)
            {
                Token = await GetAccessTokenFromKeyVaultAsync()
            };

            // Check if the token should be refreshed
            if (twinfieldApi.Token.IsExpired())
            {
                Console.WriteLine("Token expired, refreshing..");
                await twinfieldApi.RefreshTokenAsync();
                await StoreAccesstokenInKeyVaultAsync(twinfieldApi.Token);
            }

            try
            {
                // The token should be good, make some calls to Twinfield now
                var officeList = await twinfieldApi.ServiceFactory.ProcessXmlDataService.GetOfficeList();

                Console.WriteLine($"List of all {officeList.Count} offices:");
                foreach (var o in officeList)
                {
                    Console.WriteLine("{0,10} {1,20} {2}", o.Code, o.ShortName, o.Name);
                }

                // And place the rest of your logic here, including extra calls to Twinfield
                //...
                //...
                //...
            }
            catch (TokenExpiredException)
            {
                if (canRetry)
                {
                    // Refresh the token
                    await twinfieldApi.RefreshTokenAsync();
                    await StoreAccesstokenInKeyVaultAsync(twinfieldApi.Token);

                    // Retry (once)
                    await LoadTokenFromKeyVaultandRunDemoAsync(false);
                }
                else
                {
                    // Token could not be refreshed. Throw exception and quit.
                    throw;
                }
            }
        }

        private static async Task StoreAccesstokenInKeyVaultAsync(OAuthToken accessToken)
        {
            var client = new SecretClient(
                new Uri(keyVaultUrl),
                new DefaultAzureCredential()
            );

            var jsonToken = JsonConvert.SerializeObject(accessToken);
            var secret = new KeyVaultSecret(keyVaultSecretName, jsonToken);
            await client.SetSecretAsync(secret);
        }

        private static async Task<OAuthToken> GetAccessTokenFromKeyVaultAsync()
        {
            try
            {
                var client = new SecretClient(
                    new Uri(keyVaultUrl),
                    new DefaultAzureCredential()
                );

                var secret = await client.GetSecretAsync(keyVaultSecretName);
                var jsonToken = secret.Value.Value;
                return JsonConvert.DeserializeObject<OAuthToken>(jsonToken);
            }
            catch (RequestFailedException)
            {
                Console.WriteLine($"Key not found in KeyVault: {keyVaultSecretName}");
                throw;
            }
        }
    }
}