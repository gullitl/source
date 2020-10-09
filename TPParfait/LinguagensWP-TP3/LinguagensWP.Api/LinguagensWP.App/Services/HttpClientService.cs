using System.Net.Http;

namespace LinguagensWP.Application.Services {

    public interface IHttpClientService {
        HttpClient GetClient();
    }

    public class HttpClientService : IHttpClientService {
        public readonly HttpClient _apiClient;
        public HttpClientService(HttpClient apiClient) {
            _apiClient = apiClient;
        }
        public HttpClient GetClient() {
            return _apiClient;
        }
    }
}
