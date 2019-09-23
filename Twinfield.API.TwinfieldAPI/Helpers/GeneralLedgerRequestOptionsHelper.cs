using System;
using System.Collections.Generic;
using System.Linq;
using Twinfield.API.TwinfieldAPI.Dto.ProcessXml;
using Twinfield.API.TwinfieldAPI.Utilities;

namespace Twinfield.API.TwinfieldAPI.Helpers
{
    /// <summary>
    /// Helper class to help with the 
    /// </summary>
    public static class GeneralLedgerRequestOptionsHelper
    {
        /// <summary>
        /// Gets a valid request list from the full set. Also providing methods to help with date ranges.
        /// </summary>
        /// <param name="optionsList">The options list.</param>
        /// <param name="fromYear">From year.</param>
        /// <param name="fromMonth">From month.</param>
        /// <param name="toYear">To year.</param>
        /// <param name="toMonth">To month.</param>
        /// <returns></returns>
        /// <exception cref="Exception">dunno..</exception>
        public static List<GeneralLedgerRequestOption> GetRequestList(List<GeneralLedgerRequestOption> optionsList, int fromYear, int fromMonth, int toYear, int toMonth)
        {
            var includeFields = optionsList.Where(i => i.Visible).Select(i => i.Field).ToList();
            includeFields.Add("fin.trs.head.yearperiod");
            return GetRequestList(optionsList, fromYear, fromMonth, toYear, toMonth, includeFields);
        }

        /// <summary>
        /// Gets the request list, based on a list of items that need to be included.
        /// </summary>
        /// <param name="optionsList">The options list.</param>
        /// <param name="fromYear">From year.</param>
        /// <param name="fromMonth">From month.</param>
        /// <param name="toYear">To year.</param>
        /// <param name="toMonth">To month.</param>
        /// <param name="includeFields">The include fields.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">The field 'fin.trs.head.yearperiod' must be included in the includeFields parameter.</exception>
        public static List<GeneralLedgerRequestOption> GetRequestList(List<GeneralLedgerRequestOption> optionsList, int fromYear, int fromMonth, int toYear, int toMonth, List<string> includeFields)
        {
            var minimalList = optionsList.Where(o => includeFields.Contains(o.Field)).ToList();

            var first = minimalList.FirstOrDefault(o => o.Field == "fin.trs.head.yearperiod");
            if (first == null)
                throw new ArgumentException("The field 'fin.trs.head.yearperiod' must be included in the includeFields parameter.");

            PeriodValidator.Validate(fromYear, fromMonth, toYear, toMonth);

            first.From = $"{fromYear}/{fromMonth.ToString().PadLeft(2, '0')}";
            first.To = $"{toYear}/{toMonth.ToString().PadLeft(2, '0')}";

            return minimalList;
        }
    }
}
