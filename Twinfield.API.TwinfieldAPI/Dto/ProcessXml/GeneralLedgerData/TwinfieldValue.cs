using System;
using System.Globalization;
using Twinfield.API.TwinfieldAPI.Exceptions;

namespace Twinfield.API.TwinfieldAPI.Dto.ProcessXml.GeneralLedgerData
{
    /// <summary>
    /// TwinfieldValue class, contains the value of a General Ledger data row.
    /// </summary>
    /// <seealso cref="Twinfield.API.TwinfieldAPI.Dto.ProcessXml.GeneralLedgerData.ITwinfieldValue" />
    public class TwinfieldValue : ITwinfieldValue
    {
        /// <summary>
        /// Gets the type of the value.
        /// </summary>
        /// <value>
        /// The type of the value.
        /// </value>
        public string ValueType { get; }

        /// <summary>
        /// The string value
        /// </summary>
        private readonly string _stringValue;

        /// <summary>
        /// The number value
        /// </summary>
        private readonly int _numberValue;

        /// <summary>
        /// The decimal value
        /// </summary>
        private readonly decimal _decimalValue;

        /// <summary>
        /// The value value
        /// </summary>
        private readonly decimal _valueValue;

        /// <summary>
        /// The datetime value
        /// </summary>
        private readonly DateTime _datetimeValue;

        /// <summary>
        /// The date value
        /// </summary>
        private readonly DateTime _dateValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="TwinfieldValue"/> class.
        /// Sets the value based on the Value Type.
        /// </summary>
        /// <param name="valueType">Type of the value.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="UnknownValueTypeException">Unknown value type {valueType}</exception>
        public TwinfieldValue(string valueType, string value)
        {
            ValueType = valueType;

            switch (valueType.ToLower())
            {
                case "string":
                    _stringValue = value;
                    break;

                case "number":
                    _numberValue = string.IsNullOrEmpty(value) ? 0 : int.Parse(value);
                    break;

                case "decimal":
                    _decimalValue = string.IsNullOrEmpty(value) ? 0 : decimal.Parse(value, CultureInfo.InvariantCulture);
                    break;

                case "value":
                    _valueValue = string.IsNullOrEmpty(value) ? 0 : decimal.Parse(value, CultureInfo.InvariantCulture);
                    break;

                case "datetime":
                    var dateTime =
                        $"{value.Substring(0, 4)}-{value.Substring(4, 2)}-{value.Substring(6, 2)} {value.Substring(8, 2)}:{value.Substring(10, 2)}:{value.Substring(12, 2)}";
                    _datetimeValue = DateTime.Parse(dateTime);
                    break;

                case "date":
                    var date = $"{value.Substring(0, 4)}-{value.Substring(4, 2)}-{value.Substring(6, 2)} 10:00:00";
                    _dateValue = DateTime.Parse(date);
                    break;

                default:
                    throw new UnknownValueTypeException($"Unknown value type {valueType}");
            }
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        /// <exception cref="Exception">No value set</exception>
        public override string ToString()
        {
            switch (ValueType.ToLower())
            {
                case "string": return _stringValue;
                case "number": return _numberValue.ToString();
                case "decimal": return _decimalValue.ToString(CultureInfo.InvariantCulture);
                case "value": return _valueValue.ToString(CultureInfo.InvariantCulture);
                case "datetime": return _datetimeValue.ToString(CultureInfo.InvariantCulture);
                case "date": return _dateValue.ToString(CultureInfo.InvariantCulture);
                default: throw new Exception("No value set");
            }
        }

        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <returns></returns>
        public string GetString()
        {
            return _stringValue;
        }

        /// <summary>
        /// Gets the number.
        /// </summary>
        /// <returns></returns>
        public int GetNumber()
        {
            return _numberValue;
        }

        /// <summary>
        /// Gets the decimal.
        /// </summary>
        /// <returns></returns>
        public decimal GetDecimal()
        {
            return _decimalValue;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns></returns>
        public decimal GetValue()
        {
            return _valueValue;
        }

        /// <summary>
        /// Gets the date time.
        /// </summary>
        /// <returns></returns>
        public DateTime GetDateTime()
        {
            return _datetimeValue;
        }

        /// <summary>
        /// Gets the date.
        /// </summary>
        /// <returns></returns>
        public DateTime GetDate()
        {
            return _dateValue;
        }
    }
}
