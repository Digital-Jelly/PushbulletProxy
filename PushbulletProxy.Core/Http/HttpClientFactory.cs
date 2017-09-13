using System.Net.Http;
using System.Net.Http.Headers;

namespace PushbulletProxy.Core.Http
{
    public class HttpClientFactory : IHttpClientFactory
    {
        private readonly ISettings settings;

        public HttpClientFactory(ISettings settings)
        {
            this.settings = settings;
        }

        public HttpClient Create()
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }
    }
}
