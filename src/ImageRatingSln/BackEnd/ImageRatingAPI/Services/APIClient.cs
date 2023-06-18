using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ImageRatingAPI.Services
{
    internal class APIClient : IHttpClientFactory
    {
        public HttpClient CreateClient(string? name = "APIClient")
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, errors) => true;

            HttpClient httpClient = new HttpClient(handler);

            return httpClient;
        }
    }
    // string uri, string postBody = null, string authorization = null, uri, postBody, mediaType, authorization
    public static class APIRequestServices<T>
    {
        private static HttpClient? _client;

        private static void Setup(string? _baseURL, string? _endpointURL, string _mediaType)
        {
            _client = new APIClient().CreateClient();
            _client.BaseAddress = new Uri(_baseURL + _endpointURL);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_mediaType));

            _client.Timeout = TimeSpan.FromMinutes(30);
        }

        public static async Task<T> Get(string? _baseURL, string? _endpointURL = "", string? _authorizationType = null, string? _authorization = null, string _mediaType = "application/json")
        {
            try
            {
                // Setup Client
                Setup(_baseURL, _endpointURL, _mediaType);

                // Setup this Request
                HttpRequestMessage requestMessage = new HttpRequestMessage();
                //requestMessage.RequestUri = new Uri(_endpointURL);
                if (string.IsNullOrWhiteSpace(_authorizationType))
                {
                    requestMessage.Headers.TryAddWithoutValidation("", _authorization);
                }
                else
                {
                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue(_authorizationType, _authorization); //***
                }
                requestMessage.Method = HttpMethod.Get;

                // Get and Return Response
                HttpResponseMessage responseMessage = await _client.SendAsync(requestMessage);

                string responseString = responseMessage.Content.ReadAsStringAsync().Result;
                T responseData = JsonConvert.DeserializeObject<T>(responseString);


                return responseData;
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        public static async Task<T> Post(string? _baseURL, string? _endpointURL = "", string? _postBody = null, string? _authorizationType = null, string? _authorization = null, string _mediaType = "application/json")
        {
            try
            {
                // Setup Client
                Setup(_baseURL, _endpointURL, _mediaType);

                // Setup this Request
                HttpRequestMessage requestMessage = new HttpRequestMessage();
                if (string.IsNullOrWhiteSpace(_authorizationType))
                {
                    requestMessage.Headers.TryAddWithoutValidation("Authorization", _authorization);
                }
                else
                {
                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue(_authorizationType, _authorization); //***
                }
                requestMessage.Method = HttpMethod.Post;

                if (!string.IsNullOrWhiteSpace(_postBody))
                {
                    requestMessage.Content = new StringContent(_postBody, Encoding.UTF8, _mediaType);
                }

                // Get and Return Response
                HttpResponseMessage responseMessage = await _client.SendAsync(requestMessage);

                string responseString = responseMessage.Content.ReadAsStringAsync().Result;
                T responseData = JsonConvert.DeserializeObject<T>(responseString);


                return responseData;
            }
            catch (Exception ex)
            {
                return default;
            }
        }
    }
}
