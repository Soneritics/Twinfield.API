using Api.Dto;
using Api.Services.Data;

namespace Api.Services
{
    /// <summary>
    /// Factory class for creating clients to call the Twinfield services.
    /// </summary>
    public class ServiceFactory
    {
        /// <summary>
        /// The soapHeader
        /// </summary>
        private readonly ISoapHeader _soapHeader;

        /// <summary>
        /// The process XML service
        /// </summary>
        private ProcessXmlDataService _processXmlDataService;

        /// <summary>
        /// Gets the process XML service.
        /// </summary>
        /// <value>
        /// The process XML service.
        /// </value>
        public ProcessXmlDataService ProcessXmlDataService => _processXmlDataService ??= new ProcessXmlDataService(_soapHeader);

        /// <summary>
        /// The finder service
        /// </summary>
        private FinderDataService _finderDataService;

        /// <summary>
        /// Gets the finder service.
        /// </summary>
        /// <value>
        /// The finder service.
        /// </value>
        public FinderDataService FinderDataService => _finderDataService ??= new FinderDataService(_soapHeader);

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceFactory"/> class.
        /// Requires a soapHeader, as all of the services created by this factory require a logged in user.
        /// </summary>
        /// <param name="soapHeader">The soapHeader.</param>
        public ServiceFactory(ISoapHeader soapHeader)
        {
            _soapHeader = soapHeader;
        }
    }
}
