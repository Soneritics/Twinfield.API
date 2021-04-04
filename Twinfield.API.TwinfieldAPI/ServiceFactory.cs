using Twinfield.API.TwinfieldAPI.Dto;
using Twinfield.API.TwinfieldAPI.Services;

namespace Twinfield.API.TwinfieldAPI
{
    /// <summary>
    /// Factory class for creating clients to call the Twinfield services.
    /// </summary>
    public class ServiceFactory
    {
        /// <summary>
        /// The session
        /// </summary>
        private Session _session;

        /// <summary>
        /// The session service
        /// </summary>
        private SessionService _sessionService;

        /// <summary>
        /// Gets the session service.
        /// </summary>
        /// <value>
        /// The session service.
        /// </value>
        public SessionService SessionService => _sessionService ??= new SessionService(_session);

        /// <summary>
        /// The process XML service
        /// </summary>
        private ProcessXmlService _processXmlService;

        /// <summary>
        /// Gets the process XML service.
        /// </summary>
        /// <value>
        /// The process XML service.
        /// </value>
        public ProcessXmlService ProcessXmlService => _processXmlService ??= new ProcessXmlService(_session);

        /// <summary>
        /// The finder service
        /// </summary>
        private FinderService _finderService;

        /// <summary>
        /// Gets the finder service.
        /// </summary>
        /// <value>
        /// The finder service.
        /// </value>
        public FinderService FinderService => _finderService ??= new FinderService(_session);

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceFactory"/> class.
        /// Requires a session, as all of the services created by this factory require a logged in user.
        /// </summary>
        /// <param name="session">The session.</param>
        public ServiceFactory(Session session)
        {
            _session = session;
        }
    }
}
