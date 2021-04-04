using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api;
using Api.Dto;
using Api.Dto.ProcessXml;
using Api.Helpers;
using Api.Utilities;

namespace Demo
{
    class Program
    {
        private static Session session;
        private static ServiceFactory factory;

        // Demo data
        private static string user = "jordi";
        private static string password = "welkom123";
        private static string organization = "fhc";
        private static string company = "80281"; // Vital gerard
        //private static string company = "1090"; // Family Ijburg
        private static int fromMonth = 0;
        private static int fromYear = DateTime.Now.Year;
        private static int toMonth = 2;
        private static int toYear = DateTime.Now.Year;

        static async Task Main(string[] args)
        {
            // Authentication
            session = await Authentication.PasswordLogin(user, password, organization);

            // Creating the factory using the session obtained by logging in
            factory = new ServiceFactory(session);

            // Examples
            await Example1();
            await Example2();
            await Example3();
            await Example4();

            var requestOptions = await Example5();
            var minimalRequestOptions = Example6(requestOptions);
            await Example8(minimalRequestOptions);

            minimalRequestOptions = Example7(requestOptions);
            await Example8(minimalRequestOptions);

            await Example9();

            // Log off
            await Authentication.Logout(session);
        }

        #region Examples
        static async Task Example1()
        {
            // Example #1: Get offices list
            var officeList = await factory.ProcessXmlService.GetOfficeList();
            Console.WriteLine($"List of all {officeList.Count} offices:");
            foreach (var o in officeList)
            {
                Console.WriteLine("{0,10} {1,20} {2}", o.Code, o.ShortName, o.Name);
            }
        }

        static async Task Example2()
        {
            // Example #2: Switch company
            await factory.SessionService.SelectCompany(company);
        }

        static async Task Example3()
        {
            // Example #3: Get the fields for the balance sheet
            var balanceSheetFields = await factory.FinderService.GetBalanceSheetFields(company);
            Console.WriteLine("Balance sheet fields:");
            foreach (var field in balanceSheetFields)
            {
                Console.WriteLine("{0,10} {1}", field.Key, field.Value);
            }
        }

        static async Task Example4()
        {
            // Example #4: Get the fields for profit and loss
            var pnlFields = await factory.FinderService.GetProfitAndLossFields(company);
            Console.WriteLine("Profit & Loss fields:");
            foreach (var field in pnlFields)
            {
                Console.WriteLine("{0,10} {1}", field.Key, field.Value);
            }
        }

        static async Task<List<GeneralLedgerRequestOption>> Example5()
        {
            // Example #5: Get the general ledger request options
            var data = await factory.ProcessXmlService.GetGeneralLedgerRequestOptions(company);
            Console.WriteLine("General Ledger request options:");
            foreach (var d in data)
            {
                Console.WriteLine("{0,10} {1,35} {2,10} {3,10} {4,10} {5}", d.Id, d.Field, d.Operator, d.Ask, d.Visible, d.Label);
            }

            return data;
        }

        static List<GeneralLedgerRequestOption> Example6(List<GeneralLedgerRequestOption> list)
        {
            // Example #6: Get a valid request, including range
            var data = GeneralLedgerRequestOptionsHelper.GetRequestList(list, fromYear, fromMonth, toYear, toMonth);
            Console.WriteLine("General Ledger request:");
            foreach (var d in data)
            {
                Console.WriteLine("{0,10} {1,35} {2,10} {3,10}", d.Id, d.Field, d.From, d.To);
            }

            return data;
        }

        static List<GeneralLedgerRequestOption> Example7(List<GeneralLedgerRequestOption> list)
        {
            // Example #7: Narrowing down the result of Example #6 even more
            var data = GeneralLedgerRequestOptionsHelper.GetRequestList(list, fromYear, fromMonth, toYear, toMonth, GeneralLedgerRequestOptionsLists.MinimalList);
            Console.WriteLine("General Ledger request with minimum fields:");
            foreach (var d in data)
            {
                Console.WriteLine("{0,10} {1,35} {2,10} {3,10}", d.Id, d.Field, d.From, d.To);
            }

            return data;
        }

        static async Task Example8(List<GeneralLedgerRequestOption> list)
        {
            // Example #8: Reading data from the general ledger
            var glData = await factory.ProcessXmlService.GetGeneralLedgerData(list);
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
                    Console.WriteLine("\t{0,35} {1,25} {2}", r.Field, r.Label, r.Value.ToString());
                }

                Console.WriteLine("}");
            }

            Console.WriteLine("{...}");
        }

        static async Task Example9()
        {
            var list = GeneralLedgerRequestOptionsLists.GetMinimumRequestOptionsList(fromYear, fromMonth, toYear, toMonth);
            await Example8(list);
        }
        #endregion
    }
}
