# Introduction 
This project contains an API for [Twinfield](https://twinfield.com/).

The API is based on the [Twinfield API specification](https://c3.twinfield.com/webservices/documentation/#/GettingStarted/WebServicesOverview).

# Remarks
* Not all Twinfield API functionality is provided by this API. Only the functionalities that I need for my projects.
* BankBookService API is not included at all.

# How to use
The following code example should help.
``` c#
// Authentication
var session = await Authentication.PasswordLogin(user, password, organization);

// Creating the factory using the session obtained by logging in
var factory = new ServiceFactory(session);


// Example #1: Get offices list
var officeList = await factory.ProcessXmlService.GetOfficeList();
Console.WriteLine($"List of all {officeList.Count} offices:");
foreach (var o in officeList)
{
	Console.WriteLine("{0,10} {1,20} {2}", o.Code, o.ShortName, o.Name);
}


// Example #2: Switch company
await factory.SessionService.SelectCompany(company);


// Example #3: Get the fields for the balance sheet
var balanceSheetFields = await factory.FinderService.GetBalanceSheetFields(company);
Console.WriteLine("Balance sheet fields:");
foreach (var field in balanceSheetFields)
{
	Console.WriteLine("{0,10} {1}", field.Key, field.Value);
}


// Example #4: Get the fields for profit and loss
var pnlFields = await factory.FinderService.GetProfitAndLossFields(company);
Console.WriteLine("Profit & Loss fields:");
foreach (var field in pnlFields)
{
	Console.WriteLine("{0,10} {1}", field.Key, field.Value);
}


// Example #5: Get the general ledger request options
var data = await factory.ProcessXmlService.GetGeneralLedgerRequestOptions(company);
Console.WriteLine("General Ledger request options:");
foreach (var d in data)
{
	Console.WriteLine("{0,10} {1,35} {2,10} {3,10} {4,10} {5}", d.Id, d.Field, d.Operator, d.Ask, d.Visible, d.Label);
}


// Example 6: Narrowing down the general ledger request data to a valid request, using a time range
// This uses the data from the request of Example #5
var requestData = GeneralLedgerRequestOptionsHelper.GetRequestList(data, fromYear, fromMonth, toYear, toMonth);
Console.WriteLine("General Ledger request:");
foreach (var d in data)
{
	Console.WriteLine("{0,10} {1,35} {2,10} {3,10}", d.Id, d.Field, d.From, d.To);
}


// Example 7: Narrowing down the result of Example #6 even more
// This uses the data from the request of Example #5
var requestData = GeneralLedgerRequestOptionsHelper.GetRequestList(
	data,
	fromYear,
	fromMonth,
	toYear,
	toMonth,
	GeneralLedgerRequestOptionsHelper.MinimalList
);
Console.WriteLine("General Ledger request:");
foreach (var d in data)
{
	Console.WriteLine("{0,10} {1,35} {2,10} {3,10}", d.Id, d.Field, d.From, d.To);
}





// Log off
await Authentication.Logout(session);
```

# Contribute
Feel free to contribute to the project.