using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Api.Dto;
using Api.Dto.ProcessXml;
using Api.Dto.ProcessXml.GeneralLedgerData;
using Api.Extensions;
using Api.Helpers;
using TwinfieldProcessXmlService;

namespace Api.Services
{
    /// <summary>
    /// ProcessXmlService, uses the Twinfield ProcessXml API.
    /// </summary>
    /// <seealso cref="ProcessXmlSoapClient" />
    public class ProcessXmlService : AbstractService<ProcessXmlSoapClient>
    {
        /// <summary>
        /// Gets or sets the session.
        /// </summary>
        /// <value>
        /// The session.
        /// </value>
        public Session Session { get; set; }

        /// <summary>
        /// Gets the service endpoint.
        /// </summary>
        /// <value>
        /// The service endpoint.
        /// </value>
        public override string ServiceEndpoint { get; } = "/webservices/processxml.asmx";

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessXmlService"/> class.
        /// Uses the Session object to authorize against the service.
        /// </summary>
        /// <param name="session">The session.</param>
        public ProcessXmlService(Session session) : base(session.ClusterUri)
        {
            Session = session;
            SoapClient = new ProcessXmlSoapClient(GetServiceBinding(), GetEndpoint());
        }

        /// <summary>
        /// Gets the office list from Twinfield.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Office>> GetOfficeList()
        {
            var document = "<list><type>offices</type></list>";
            var officeListResult = await SoapClient.ProcessXmlDocumentAsync(
                new Header() { SessionID = Session.SessionId },
                document.ToXmlNode()
            );

            var result = new List<Office>();
            foreach (XmlNode node in officeListResult.ProcessXmlDocumentResult.ChildNodes)
            {
                result.Add(new Office()
                {
                    Code = node.InnerText,
                    Name = node.Attributes["name"]?.Value,
                    ShortName = node.Attributes["shortname"]?.Value
                });
            }

            return result;
        }

        /// <summary>
        /// Gets the general ledger request options.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns></returns>
        public async Task<List<GeneralLedgerRequestOption>> GetGeneralLedgerRequestOptions(string companyCode)
        {
            var document = $"<read><type>browse</type><code>030_2</code><office>{companyCode}</office></read>";
            var dataRequestOptions = await SoapClient.ProcessXmlDocumentAsync(
                new Header() { SessionID = Session.SessionId },
                document.ToXmlNode()
            );

            var result = new List<GeneralLedgerRequestOption>();
            foreach (XmlNode node in dataRequestOptions.ProcessXmlDocumentResult.LastChild.ChildNodes)
            {
                var glro = new GeneralLedgerRequestOption()
                {
                    Id = node.Attributes["id"]?.Value
                };

                foreach (XmlNode childElement in node.ChildNodes)
                {
                    switch (childElement.Name)
                    {
                        case "label": glro.Label = childElement.InnerText; break;
                        case "field": glro.Field = childElement.InnerText; break;
                        case "operator": glro.Operator = childElement.InnerText; break;
                        case "visible": glro.Visible = childElement.InnerText.Equals("true"); break;
                        case "ask": glro.Ask = childElement.InnerText.Equals("true"); break;
                    }
                }

                result.Add(glro);
            }

            return result;
        }

        /// <summary>
        /// Read data from the the general ledger.
        /// </summary>
        /// <param name="requestOptions">The request options.</param>
        /// <returns></returns>
        public async Task<GeneralLedgerData> GetGeneralLedgerData(List<GeneralLedgerRequestOption> requestOptions)
        {
            var requestString = GeneralLedgerRequestOptionsParser.Parse(requestOptions);
            var balanceSheetDataResult = await SoapClient.ProcessXmlDocumentAsync(
                new Header() { SessionID = Session.SessionId },
                requestString.ToXmlNode()
            );

            var balanceSheetHeaders = new Dictionary<string, TwinfieldDataLineHeader>();
            var balanceSheetDataList = new List<List<TwinfieldDataLine>>();
            var firstNode = true;
            foreach (XmlNode row in balanceSheetDataResult.ProcessXmlDocumentResult)
            {
                if (firstNode)
                {
                    foreach (XmlNode el in row.ChildNodes)
                    {
                        if (el.Name.Equals("td"))
                        {
                            balanceSheetHeaders[el.InnerText] = new TwinfieldDataLineHeader()
                            {
                                ValueType = el.Attributes["type"]?.Value,
                                Label = el.Attributes["label"]?.Value
                            };
                        }
                    }

                    firstNode = false;
                }
                else
                {
                    var rowData = new List<TwinfieldDataLine>();
                    foreach (XmlNode el in row)
                    {
                        if (el.Name.Equals("td"))
                        {
                            rowData.Add(new TwinfieldDataLine()
                            {
                                Field = el.Attributes["field"]?.Value,
                                Label = balanceSheetHeaders[el.Attributes["field"]?.Value]?.Label,
                                Value = new TwinfieldValue(balanceSheetHeaders[el.Attributes["field"]?.Value]?.ValueType, el.InnerText)
                            });
                        }
                    }

                    balanceSheetDataList.Add(rowData);
                }
            }

            return new GeneralLedgerData()
            {
                Headers = balanceSheetHeaders,
                Data = balanceSheetDataList
            };
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
