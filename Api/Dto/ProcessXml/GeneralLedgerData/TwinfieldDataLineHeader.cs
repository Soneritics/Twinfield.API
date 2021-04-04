namespace Api.Dto.ProcessXml.GeneralLedgerData
{
    /// <summary>
    /// Header line for the General Ledger data.
    /// </summary>
    public class TwinfieldDataLineHeader
    {
        /// <summary>
        /// Gets or sets the type of the value.
        /// </summary>
        /// <value>
        /// The type of the value.
        /// </value>
        public string ValueType { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        public string Label { get; set; }
    }
}
