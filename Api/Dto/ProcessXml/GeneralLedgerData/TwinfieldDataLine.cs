namespace Api.Dto.ProcessXml.GeneralLedgerData
{
    /// <summary>
    /// TwinfieldDataLine, contains a line of General Ledger data.
    /// </summary>
    public class TwinfieldDataLine
    {
        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        /// <value>
        /// The field.
        /// </value>
        public string Field { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public TwinfieldValue Value { get; set; }

    }
}
