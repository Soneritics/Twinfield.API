using System;
using System.Collections.Generic;
using System.Text;

namespace Twinfield.API.TwinfieldAPI.Dto.ProcessXml.GeneralLedgerData
{
    /// <summary>
    /// Interface for the TwinfieldValue class.
    /// Contains holders for all the possible values, of which only one will be filled.
    /// </summary>
    public interface ITwinfieldValue
    {
        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <returns></returns>
        string GetString();

        /// <summary>
        /// Gets the number.
        /// </summary>
        /// <returns></returns>
        int GetNumber();

        /// <summary>
        /// Gets the decimal.
        /// </summary>
        /// <returns></returns>
        double GetDecimal();

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns></returns>
        double GetValue();

        /// <summary>
        /// Gets the date time.
        /// </summary>
        /// <returns></returns>
        DateTime GetDateTime();

        /// <summary>
        /// Gets the date.
        /// </summary>
        /// <returns></returns>
        DateTime GetDate();

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        string ToString();
    }
}
