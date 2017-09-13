using System.Net.Http;

namespace PushbulletProxy.Core.Http
{
    public interface IHttpClientFactory
    {
        HttpClient Create();
    }
}
