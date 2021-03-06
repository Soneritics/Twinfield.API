﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dto;
using Api.Dto.Financial;
using TwinfieldFinderService;

namespace Api.Services.Data
{
    /// <summary>
    /// FinderDataService, uses the Twinfield Finder API.
    /// </summary>
    /// <seealso cref="FinderSoapClient" />
    public class FinderDataService : AbstractDataService<FinderSoapClient>
    {
        /// <summary>
        /// Gets or sets the soapHeader.
        /// </summary>
        /// <value>
        /// The soapHeader.
        /// </value>
        public ISoapHeader SoapHeader { get; set; }

        /// <summary>
        /// Gets the service endpoint.
        /// </summary>
        /// <value>
        /// The service endpoint.
        /// </value>
        public override string ServiceEndpoint { get; } = "/webservices/finder.asmx";

        /// <summary>
        /// Initializes a new instance of the <see cref="FinderDataService"/> class.
        /// Uses the SoapHeader object to authorize against the service.
        /// </summary>
        /// <param name="soapHeader">The soapHeader.</param>
        public FinderDataService(ISoapHeader soapHeader) : base(soapHeader.ClusterUri)
        {
            SoapHeader = soapHeader;
            SoapClient = new FinderSoapClient(GetServiceBinding(), GetEndpoint());
        }

        /// <summary>
        /// Gets the balance sheet fields (code & name).
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns></returns>
        public async Task<Dictionary<string, string>> GetBalanceSheetFields(string companyCode)
        {
            return await GetFields(companyCode, FinancialType.BalanceSheet);
        }

        /// <summary>
        /// Gets the profit and loss fields (code & name).
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns></returns>
        public async Task<Dictionary<string, string>> GetProfitAndLossFields(string companyCode)
        {
            return await GetFields(companyCode, FinancialType.ProfitAndLoss);
        }

        /// <summary>
        /// Gets the fields for either a Balance Sheet or Profit and Loss.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="financialType">Type of the dim. BAS for Balance Sheet, PNL for Profit and Loss</param>
        /// <returns></returns>
        private async Task<Dictionary<string, string>> GetFields(string companyCode, string financialType)
        {
            var searchRequest = new SearchRequest()
            {
                Header = await SoapHeader.GetHeaderAsync(new Header()),
                type = "DIM",
                pattern = "*",
                field = 0,
                firstRow = 1,
                maxRows = int.MaxValue,
                options = new[]
                {
                    new [] { "section", "financials" },
                    new [] { "dimtype", financialType },
                    new [] { "office", companyCode }
                }
            };
            var searchResults = await SoapClient.SearchAsync(searchRequest);

            return searchResults.data.Items
                .Select(s => new { Code = s[0], Name = s[1] })
                .ToDictionary(d => d.Code, d => d.Name);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                SoapClient.CloseAsync();
            }
        }
    }
}
