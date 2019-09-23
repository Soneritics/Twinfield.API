using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using Twinfield.API.TwinfieldAPI.Dto;
using Twinfield.API.TwinfieldAPI.Dto.ProcessXml;
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
