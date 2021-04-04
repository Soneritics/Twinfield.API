using System.Threading.Tasks;
using Twinfield.API.TwinfieldAPI.Dto;
using Twinfield.API.TwinfieldAPI.Exceptions;
using TwinfieldLoginSessionService;

namespace Twinfield.API.TwinfieldAPI.Services
{
    /// <summary>
    /// LoginSessionService, used for login on to Twinfield and getting the Session object,
    /// which is used throughout the user's session.
    /// </summary>
    /// <seealso cref="Twinfield.API.TwinfieldAPI.Services.AbstractService{TwinfieldLoginSessionService.SessionSoapClient}" />
    public class LoginSessionService : AbstractService<SessionSoapClient>
    {
        /// <summary>
        /// Gets the service endpoint.
        /// </summary>
        /// <value>
        /// The service endpoint.
        /// </value>
        public override string ServiceEndpoint { get; } = "/webservices/session.asmx";

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginSessionService"/> class.
        /// Also instantiates a new SessionSoapClient instance.
        /// </summary>
        /// <param name="clusterUri">The cluster URI.</param>
        public LoginSessionService(string clusterUri) : base(clusterUri)
        {
            SoapClient = new SessionSoapClient(GetServiceBinding(), GetEndpoint());
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

        /// <summary>
        /// Login using user, pass & organization combination.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <param name="organization">The organization.</param>
        /// <returns>Session</returns>
        /// <exception cref="InvalidLoginException">Could not login, logon result: {logonResult.LogonResult}</exception>
        public async Task<Session> PasswordLogin(string user, string password, string organization)
        {
            var logonRequest = new LogonRequest(user, password, organization);
            var logonResult = await SoapClient.LogonAsync(logonRequest);

            if (logonResult.LogonResult != LogonResult.Ok)
                throw new InvalidLoginException($"Could not login. Logon result: {logonResult.LogonResult}");

            return new Session()
            {
                SessionId = logonResult.Header.SessionID,
                ClusterUri = logonResult.cluster
            };
        }
    }
}
