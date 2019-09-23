using Twinfield.API.TwinfieldAPI.Dto;
using TwinfieldFinderService;

namespace Twinfield.API.TwinfieldAPI.Services
{
    /// <summary>
    /// FinderService, uses the Twinfield Finder API.
    /// </summary>
    /// <seealso cref="FinderSoapClient" />
    public class FinderService : AbstractService<FinderSoapClient>
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
        public override string ServiceEndpoint { get; } = "/webservices/finder.asmx";

        /// <summary>
        /// Initializes a new instance of the <see cref="FinderService"/> class.
        /// Uses the Session object to authorize against the service.
        /// </summary>
        /// <param name="session">The session.</param>
        public FinderService(Session session) : base(session.ClusterUri)
        {
            Session = session;
            SoapClient = new FinderSoapClient(GetServiceBinding(), GetEndpoint());
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
