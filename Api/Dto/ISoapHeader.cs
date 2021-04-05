using System.Threading.Tasks;

namespace Api.Dto
{
    public interface ISoapHeader
    {
        string ClusterUri { get; set; }
        Task<TwinfieldFinderService.Header> GetHeaderAsync(TwinfieldFinderService.Header header);
        Task<TwinfieldProcessXmlService.Header> GetHeaderAsync(TwinfieldProcessXmlService.Header header);
    }
}
