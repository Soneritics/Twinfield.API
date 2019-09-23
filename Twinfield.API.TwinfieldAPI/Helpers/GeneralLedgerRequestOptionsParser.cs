using System.Collections.Generic;
using System.Text;
using Twinfield.API.TwinfieldAPI.Dto.ProcessXml;

namespace Twinfield.API.TwinfieldAPI.Helpers
{
    internal static class GeneralLedgerRequestOptionsParser
    {
        public static string Parse(List<GeneralLedgerRequestOption> list)
        {
            var balanceSheetDataRequest = new StringBuilder();
            balanceSheetDataRequest.Append($"<columns code=\"030_2\">");
            foreach (var item in list)
            {
                var visibility = item.Visible ? "true" : "false";

                if (item.Operator == "between" && !string.IsNullOrEmpty(item.From) && !string.IsNullOrEmpty(item.To))
                    balanceSheetDataRequest.Append($"<column><field>{item.Field}</field><label>{item.Label}</label><visible>{visibility}</visible><operator>{item.Operator}</operator><from>{item.From}</from><to>{item.To}</to></column>");
                else
                    balanceSheetDataRequest.Append($"<column><field>{item.Field}</field><label>{item.Label}</label><visible>{visibility}</visible></column>");
            }
            balanceSheetDataRequest.Append($"</columns>");

            return balanceSheetDataRequest.ToString();
        }
    }
}
