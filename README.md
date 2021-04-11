[![Build Status](https://soneritics.visualstudio.com/Twinfield%20API/_apis/build/status/Soneritics.Twinfield.API?branchName=master)](https://soneritics.visualstudio.com/Twinfield%20API/_build/latest?definitionId=1&branchName=master)

# Introduction 
This project contains an API for [Twinfield](https://twinfield.com/).

The API is based on the [Twinfield API specification](https://c3.twinfield.com/webservices/documentation/#/GettingStarted/WebServicesOverview).

# NuGet
The package is available via NuGet.org: Twinfield.API.TwinfieldAPI

# Remarks
* For now it's used primarily to get the data to show a balance sheet and profit & loss overview.
* Not all Twinfield API functionality is provided by this API. Only the functionalities that I need for my projects.
* BankBookService API is not included at all.

# How to use
There is a complete documentation in the code (Demo project).

An quick example of how to use below.

``` c#
// Create the TwinfieldApi
twinfieldApi = new TwinfieldApi(oauthClientSettings);

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

// Office list
var officeList = await twinfieldApi.ServiceFactory.ProcessXmlDataService.GetOfficeList();

// Balance sheet fields
var balanceSheetFields = await twinfieldApi
    .ServiceFactory
    .FinderDataService
    .GetBalanceSheetFields(company);

// General ledger data
var data = GeneralLedgerRequestOptionsHelper
    .GetRequestList(
        list,
        fromYear,
        fromMonth,
        toYear,
        toMonth,
        GeneralLedgerRequestOptionsLists.MinimalList
    );

// More examples in PRogram.cs :-)
```

# Contribute
Feel free to contribute to the project.