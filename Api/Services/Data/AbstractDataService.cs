using System;
using System.ServiceModel;

namespace Api.Services.Data
{
    public abstract class AbstractDataService<T> : IService, IDisposable where T : class
    {
        public abstract string ServiceEndpoint { get; }
        protected T SoapClient { get; set; }
        private readonly string _clusterUri;

        protected AbstractDataService(string clusterUri)
        {
            _clusterUri = clusterUri;
        }

        protected BasicHttpBinding GetServiceBinding()
        {
            return new BasicHttpBinding(BasicHttpSecurityMode.Transport)
            {
                MaxReceivedMessageSize = int.MaxValue,
                SendTimeout = new TimeSpan(0, 0, 900)
            };
        }

        protected EndpointAddress GetEndpoint()
        {
            return new EndpointAddress($"{_clusterUri}{ServiceEndpoint}");
        }

        protected abstract void Dispose(bool disposing);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
