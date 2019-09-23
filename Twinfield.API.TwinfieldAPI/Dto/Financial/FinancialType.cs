using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Twinfield.API.TwinfieldAPI.Dto.Financial
{
    /// <summary>
    /// Financial type, as used within Twinfield.
    /// </summary>
    public class FinancialType
    {
        /// <summary>
        /// The balance sheet
        /// </summary>
        public const string BalanceSheet = "BAS";

        /// <summary>
        /// The profit & loss
        /// </summary>
        public const string ProfitAndLoss = "PNL";

        // @todo: Not sure what the names of these types are, but can be included as constants as well
        // DEB CRD KPL PRJ AST ACT
    }
}
