using System.Collections.Generic;

namespace Twinfield.API.TwinfieldAPI.Dto.ProcessXml.GeneralLedgerData
{
    /// <summary>
    /// Data from the General Ledger.
    /// </summary>
    public class GeneralLedgerData
    {
        /// <summary>
        /// Gets or sets the headers.
        /// </summary>
        /// <value>
        /// The headers.
        /// </value>
        public Dictionary<string, TwinfieldDataLineHeader> Headers { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public List<List<TwinfieldDataLine>> Data { get; set; }

    }
}
