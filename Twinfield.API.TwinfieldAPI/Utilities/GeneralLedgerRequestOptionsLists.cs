using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twinfield.API.TwinfieldAPI.Dto.ProcessXml;

namespace Twinfield.API.TwinfieldAPI.Utilities
{
    /// <summary>
    /// Utility class for default request options.
    /// </summary>
    public static class GeneralLedgerRequestOptionsLists
    {
        /// <summary>
        /// The minimum request options list.
        /// </summary>
        public static List<GeneralLedgerRequestOption> MinimumRequestOptionsList = new List<GeneralLedgerRequestOption>()
        {
            new GeneralLedgerRequestOption()
            {
                Field = "fin.trs.head.yearperiod",
                Label = "Jaar/periode (JJJJ/PP)",
                Visible = false,
                Ask = true,
                Operator = "between"
            },
            new GeneralLedgerRequestOption()
            {
                Field = "fin.trs.line.dim1group1name",
                Label = "Groepnaam 1",
                Visible = true,
                Ask = false,
                Operator = "none"
            },
            new GeneralLedgerRequestOption()
            {
                Field = "fin.trs.line.dim1",
                Label = "Grootboekrek.",
                Visible = true,
                Ask = true,
                Operator = "between"
            },
            new GeneralLedgerRequestOption()
            {
                Field = "fin.trs.line.dim1name",
                Label = "Grootboekrek.naam",
                Visible = true,
                Ask = false,
                Operator = "none"
            },
            new GeneralLedgerRequestOption()
            {
                Field = "fin.trs.line.dim1type",
                Label = "Dimensietype 1",
                Visible = true,
                Ask = false,
                Operator = "none"
            },
            new GeneralLedgerRequestOption()
            {
                Field = "fin.trs.line.valuesigned",
                Label = "Bedrag",
                Visible = true,
                Ask = false,
                Operator = "none"
            },
            new GeneralLedgerRequestOption()
            {
                Field = "fin.trs.line.debitcredit",
                Label = "D/C",
                Visible = true,
                Ask = false,
                Operator = "none"
            },
            new GeneralLedgerRequestOption()
            {
                Field = "fin.trs.line.dim1group1",
                Label = "Groep 1",
                Visible = true,
                Ask = false,
                Operator = "none"
            },
            new GeneralLedgerRequestOption()
            {
                Field = "fin.trs.line.dim2name",
                Label = "Kpl./rel.",
                Visible = true,
                Ask = true,
                Operator = "between"
            }
        };

        /// <summary>
        /// The minimal list of fields.
        /// </summary>
        public static List<string> MinimalList => MinimumRequestOptionsList.Select(l => l.Field).ToList();

        /// <summary>
        /// Gets the minimum request options list.
        /// </summary>
        /// <param name="fromYear">From year.</param>
        /// <param name="fromMonth">From month.</param>
        /// <param name="toYear">To year.</param>
        /// <param name="toMonth">To month.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">The field 'fin.trs.head.yearperiod' must be included in the includeFields parameter.</exception>
        public static List<GeneralLedgerRequestOption> GetMinimumRequestOptionsList(int fromYear, int fromMonth, int toYear, int toMonth)
        {
            var list = new List<GeneralLedgerRequestOption>();
            list.AddRange(MinimumRequestOptionsList);

            var first = list.FirstOrDefault(o => o.Field == "fin.trs.head.yearperiod");
            if (first == null)
                throw new ArgumentException("The field 'fin.trs.head.yearperiod' must be included in the includeFields parameter.");

            PeriodValidator.Validate(fromYear, fromMonth, toYear, toMonth);

            first.From = $"{fromYear}/{fromMonth.ToString().PadLeft(2, '0')}";
            first.To = $"{toYear}/{toMonth.ToString().PadLeft(2, '0')}";

            return list;
        }
    }
}
