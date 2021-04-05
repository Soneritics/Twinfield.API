using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api;
using Api.Dto.OAuth;
using Api.Dto.ProcessXml;
using Api.Exceptions;
using Api.Helpers;
using Api.Utilities;

namespace Demo
{
    class Program
    {
        // OAuth settings
        private static OAuthClientSettings oauthClientSettings = new OAuthClientSettings()
        {
            Id = "",
            Secret = ""
        };

        // This URL should catch the 'code' from the JSON which is POSTed after a successful user login
        private static string redirectUrl = "";

        // In Example 1, this is read from the command line.
        // You can choose to fill it manually, so you don't need to go over the authorization flow.
        private static OAuthToken accessToken;

        // Determine what data to show
        private static string company = "";
        private static int fromMonth = 0;
        private static int fromYear = DateTime.Now.Year;
        private static int toMonth = 2;
        private static int toYear = DateTime.Now.Year;

        #region Properties
        private static TwinfieldApi twinfieldApi;
        #endregion

        static async Task Main(string[] args)
        {
            // Create the TwinfieldApi
            twinfieldApi = new TwinfieldApi(oauthClientSettings);

            // You can also provide an HttpClient:
            // twinfieldApi = new TwinfieldApi(httpClient, oauthClientSettings);

            // Authorization flow
            await Example1();
            Console.WriteLine($"Auth code: {accessToken.Accesstoken}");

            // Instead of authenticating, you can also set the access token
            twinfieldApi.Token = accessToken;

            // Check if the token should be refreshed
            await Example2();
            Console.WriteLine($"Auth code: {accessToken.Accesstoken}");

            // Always try to catch a TokenExpiredException when calling the API
            try
            {
                // Get offices list and select the first
                await Example3();

                // Get the fields for the balance sheet
                await Example4();

                // Get the fields for profit and loss
                await Example5();

                // Example 6: Get the general ledger request options
                // Example 7: Get a valid request, including range
                // Example 9: Reading data from the general ledger
                var requestOptions = await Example6();
                var minimalRequestOptions = Example7(requestOptions);
                await Example9(minimalRequestOptions);

                // Example 8: Narrowing down the result of Example #6 even more
                // Example 9: Reading data from the general ledger
                minimalRequestOptions = Example8(requestOptions);
                await Example9(minimalRequestOptions);

                // Read data from the general ledger, based on the minimum request options.
                await Example10();
            }
            catch (TokenExpiredException)
            {
                // Refresh the token and retry
            }
        }

        #region Examples
        /// <summary>
        /// Authorization flow.
        /// </summary>
        static async Task Example1()
        {
            // First get the authorization URL
            Console.WriteLine("Send the user to the following URL:");
            Console.WriteLine(twinfieldApi.GetAuthorizationUrl(redirectUrl));

            // Catch the authorization code in your own program, and paste it here
            Console.Write("\n\nEnter the code: ");
            var authenticationCode = Console.ReadLine();

            // Get the access token
            await twinfieldApi
                .SetAccessTokenByAuthorizationCodeAsync(authenticationCode, redirectUrl);

            accessToken = twinfieldApi.Token;
        }

        /// <summary>
        /// Check if the token should be refreshed.
        /// </summary>
        static async Task Example2()
        {
            if (twinfieldApi.Token.IsExpired())
            {
                Console.WriteLine("Token expired, refreshing..");
            }
            else
            {
                Console.WriteLine("Token is not expired. Still refreshing :-)");
                await Task.Delay(2000);
            }

            await twinfieldApi.RefreshTokenAsync();
            accessToken = twinfieldApi.Token;
            // You should save the refreshed token, so you
            // can use it to call the Twinfield API the next time
        }

        /// <summary>
        /// Get offices list.
        /// </summary>
        static async Task Example3()
        {
            var officeList = await twinfieldApi.ServiceFactory.ProcessXmlDataService.GetOfficeList();

            Console.WriteLine($"List of all {officeList.Count} offices:");
            foreach (var o in officeList)
            {
                Console.WriteLine("{0,10} {1,20} {2}", o.Code, o.ShortName, o.Name);
            }

            var firstOffice = officeList.First();
            Console.WriteLine($"Selecting office `{firstOffice.Name}` ({firstOffice.Code})");
            twinfieldApi.SetCompany(firstOffice.Code);
        }

        /// <summary>
        /// Get the fields for the balance sheet.
        /// </summary>
        static async Task Example4()
        {
            var balanceSheetFields = await twinfieldApi
                .ServiceFactory
                .FinderDataService
                .GetBalanceSheetFields(company);

            Console.WriteLine("Balance sheet fields:");
            foreach (var field in balanceSheetFields)
            {
                Console.WriteLine("{0,10} {1}", field.Key, field.Value);
            }
        }

        /// <summary>
        /// Get the fields for profit and loss.
        /// </summary>
        static async Task Example5()
        {
            var pnlFields = await twinfieldApi
                .ServiceFactory
                .FinderDataService
                .GetProfitAndLossFields(company);

            Console.WriteLine("Profit & Loss fields:");
            foreach (var field in pnlFields)
            {
                Console.WriteLine("{0,10} {1}", field.Key, field.Value);
            }
        }

        /// <summary>
        /// Get the general ledger request options.
        /// </summary>
        /// <returns></returns>
        static async Task<List<GeneralLedgerRequestOption>> Example6()
        {
            var data = await twinfieldApi
                .ServiceFactory
                .ProcessXmlDataService
                .GetGeneralLedgerRequestOptions(company);

            Console.WriteLine("General Ledger request options:");
            foreach (var d in data)
            {
                Console.WriteLine("{0,10} {1,35} {2,10} {3,10} {4,10} {5}", d.Id, d.Field, d.Operator, d.Ask, d.Visible, d.Label);
            }

            return data;
        }

        /// <summary>
        /// Get a valid request, including range.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        static List<GeneralLedgerRequestOption> Example7(List<GeneralLedgerRequestOption> list)
        {
            var data = GeneralLedgerRequestOptionsHelper
                .GetRequestList(list, fromYear, fromMonth, toYear, toMonth);

            Console.WriteLine("General Ledger request:");
            foreach (var d in data)
            {
                Console.WriteLine("{0,10} {1,35} {2,10} {3,10}", d.Id, d.Field, d.From, d.To);
            }

            return data;
        }

        /// <summary>
        /// Narrowing down the result of Example #6 even more.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        static List<GeneralLedgerRequestOption> Example8(List<GeneralLedgerRequestOption> list)
        {
            var data = GeneralLedgerRequestOptionsHelper
                .GetRequestList(
                    list,
                    fromYear,
                    fromMonth,
                    toYear,
                    toMonth,
                    GeneralLedgerRequestOptionsLists.MinimalList
                );

            Console.WriteLine("General Ledger request with minimum fields:");
            foreach (var d in data)
            {
                Console.WriteLine("{0,10} {1,35} {2,10} {3,10}", d.Id, d.Field, d.From, d.To);
            }

            return data;
        }

        /// <summary>
        /// Reading data from the general ledger
        /// </summary>
        /// <param name="list">The list.</param>
        static async Task Example9(List<GeneralLedgerRequestOption> list)
        {
            var glData = await twinfieldApi
                .ServiceFactory
                .ProcessXmlDataService
                .GetGeneralLedgerData(list);

            Console.WriteLine("General Ledger data headers:");
            foreach (var h in glData.Headers)
            {
                Console.WriteLine($"\t{h.Value.Label} ({h.Value.ValueType})");
            }

            Console.WriteLine("General Ledger data lines (max 10 lines):");
            foreach (var h in glData.Data.Where(d => d.FirstOrDefault(i => i.Field == "fin.trs.line.dim1type")?.Value.ToString() == "PNL")/*.Take(10)*/)
            {
                Console.WriteLine("{");

                foreach (var r in h)
                {
                    Console.WriteLine("\t{0,35} {1,25} {2}", r.Field, r.Label, r.Value);
                }

                Console.WriteLine("}");
            }

            Console.WriteLine("{...}");
        }

        /// <summary>
        /// Read data from the general ledger, based on the minimum request options.
        /// </summary>
        static async Task Example10()
        {
            var list = GeneralLedgerRequestOptionsLists.GetMinimumRequestOptionsList(fromYear, fromMonth, toYear, toMonth);
            await Example9(list);
        }
        #endregion
    }
}
