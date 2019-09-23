using System;
using System.Collections.Generic;
using System.Text;

namespace Twinfield.API.TwinfieldAPI.Utilities
{
    /// <summary>
    /// Validator class for periods.
    /// </summary>
    public static class PeriodValidator
    {
        /// <summary>
        /// Validates the specified period.
        /// </summary>
        /// <param name="fromYear">From year.</param>
        /// <param name="fromMonth">From month.</param>
        /// <param name="toYear">To year.</param>
        /// <param name="toMonth">To month.</param>
        /// <exception cref="ArgumentException">
        /// The 'fromYear' parameter must be a 4-digit, valid year.
        /// or
        /// The 'toYear' parameter must be a 4-digit, valid year.
        /// or
        /// The 'fromMonth' parameter must be a valid month (0-12)
        /// or
        /// The 'toMonth' parameter must be a valid month (0-12)
        /// </exception>
        public static void Validate(int fromYear, int fromMonth, int toYear, int toMonth)
        {
            if (fromYear < 1000 || fromYear > 2100)
                throw new ArgumentException("The 'fromYear' parameter must be a 4-digit, valid year.");

            if (toYear < 1000 || toYear > 2100)
                throw new ArgumentException("The 'toYear' parameter must be a 4-digit, valid year.");

            if (fromMonth < 0 || fromMonth > 12) // Yes, 0 is actually valid
                throw new ArgumentException("The 'fromMonth' parameter must be a valid month (0-12)");

            if (toMonth < 0 || toMonth > 12) // Yes, 0 is actually valid
                throw new ArgumentException("The 'toMonth' parameter must be a valid month (0-12)");
        }
    }
}
