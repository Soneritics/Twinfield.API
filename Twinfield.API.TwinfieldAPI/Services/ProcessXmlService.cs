using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using Twinfield.API.TwinfieldAPI.Dto;
using Twinfield.API.TwinfieldAPI.Dto.ProcessXml;
using Twinfield.API.TwinfieldAPI.Dto.ProcessXml.GeneralLedgerData;
using Twinfield.API.TwinfieldAPI.Helpers;
using TwinfieldProcessXmlService;

namespace Twinfield.API.TwinfieldAPI.Services
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
            var document = XElement.Parse("<list><type>offices</type></list>");
            var officeListResult = await SoapClient.ProcessXmlDocumentAsync(
                new Header() { SessionID = Session.SessionId },
                document
            );

            var list = officeListResult.ProcessXmlDocumentResult.XPathSelectElements("office")
                .Select(o => new Office()
                {
                    Code = o.Value,
                    Name = o.Attribute("name")?.Value,
                    ShortName = o.Attribute("shortname")?.Value
                })
                .ToList();

            return list;
        }

        /// <summary>
        /// Gets the general ledger request options.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns></returns>
        public async Task<List<GeneralLedgerRequestOption>> GetGeneralLedgerRequestOptions(string companyCode)
        {
            var document = XElement.Parse($"<read><type>browse</type><code>030_2</code><office>{companyCode}</office></read>");
            var dataRequestOptions = await SoapClient.ProcessXmlDocumentAsync(
                new Header() { SessionID = Session.SessionId },
                document
            );

            return dataRequestOptions.ProcessXmlDocumentResult.LastNode.XPathSelectElements("column")
                .Select(d => new GeneralLedgerRequestOption()
                {
                    Id = d.Attribute("id")?.Value,
                    Label = d.XPathSelectElement("label").Value,
                    Field = d.XPathSelectElement("field").Value,
                    Visible = d.XPathSelectElement("visible").Value == "true",
                    Ask = d.XPathSelectElement("ask").Value == "true",
                    Operator = d.XPathSelectElement("operator").Value
                })
                .ToList();
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
                XElement.Parse(requestString)
            );

            var balanceSheetHeaders = new Dictionary<string, TwinfieldDataLineHeader>();
            var balanceSheetDataList = new List<List<TwinfieldDataLine>>();
            var firstNode = true;
            foreach (var row in balanceSheetDataResult.ProcessXmlDocumentResult.Elements())
            {
                if (firstNode)
                {
                    foreach (var el in row.XPathSelectElements("td"))
                        balanceSheetHeaders[el.Value] = new TwinfieldDataLineHeader()
                        {
                            ValueType = el.Attribute("type")?.Value,
                            Label = el.Attribute("label")?.Value
                        };

                    firstNode = false;
                }
                else
                {
                    var rowData = new List<TwinfieldDataLine>();
                    foreach (var el in row.XPathSelectElements("td"))
                    {
                        rowData.Add(new TwinfieldDataLine()
                        {
                            Field = el.Attribute("field")?.Value,
                            Label = balanceSheetHeaders[el.Attribute("field")?.Value]?.Label,
                            Value = new TwinfieldValue(balanceSheetHeaders[el.Attribute("field")?.Value]?.ValueType, el.Value)
                        });
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
