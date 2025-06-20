using System.Net.Http.Headers;
using Q10.StudentManagement.Web.Common;
using Q10.StudentManagement.Web.Interfaces;

namespace Q10.StudentManagement.Web.Services
{
    public class ApiService : IApiService, IDisposable
    {
        private readonly HttpClient _HttpClient;
        private readonly ILogger<ApiService> _Logger;
        private readonly ApiSettings _ApiSettings;

        public ApiService(HttpClient pHttpClient, ILogger<ApiService> pILogger, ApiSettings pApiSettings)
        {
            _HttpClient = pHttpClient ?? throw new ArgumentNullException(nameof(pHttpClient));
            _Logger = pILogger ?? throw new ArgumentNullException(nameof(pILogger));
            _ApiSettings = pApiSettings ?? throw new ArgumentNullException(nameof(pApiSettings));
            ConfigureHttpClient();
        }

        private void ConfigureHttpClient()
        {
            _HttpClient.BaseAddress = new Uri(_ApiSettings.BaseUrl!);
            _HttpClient.DefaultRequestHeaders.Accept.Clear();
            _HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<TResponse> GetAsync<TResponse>(string endpoint)
        {
            var response = await _HttpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TResponse>() ?? throw new InvalidOperationException("Response content is null.");
            }
            else
            {
                _Logger.LogError($"Error fetching data from {endpoint}: {response.ReasonPhrase}");
                throw new HttpRequestException($"Error fetching data from {endpoint}: {response.ReasonPhrase}");
            }
        }

        public bool Delete<TRequest>(string endpoint)
        {
            var response = _HttpClient.DeleteAsync(endpoint);

            if (response.Result.IsSuccessStatusCode)
            {
                return response.Result.IsSuccessStatusCode;
            }
            else
            {
                _Logger.LogError($"Error posting data to {endpoint}: {response.Result.ReasonPhrase}");
                throw new HttpRequestException($"Error posting data to {endpoint}: {response.Result.ReasonPhrase}");
            }
        }

        public bool Post<TRequest>(string endpoint, TRequest data)
        {
            var response = _HttpClient.PostAsJsonAsync(endpoint, data);

            if (response.Result.IsSuccessStatusCode)
            {
                return response.Result.IsSuccessStatusCode;
            }
            else
            {
                _Logger.LogError($"Error posting data to {endpoint}: {response.Result.ReasonPhrase}");
                throw new HttpRequestException($"Error posting data to {endpoint}: {response.Result.ReasonPhrase}");
            }
        }

        public bool Put<TRequest>(string endpoint, TRequest data)
        {
            var response = _HttpClient.PutAsJsonAsync(endpoint, data);

            if (response.Result.IsSuccessStatusCode)
            {
                return response.Result.IsSuccessStatusCode;
            }
            else
            {
                _Logger.LogError($"Error posting data to {endpoint}: {response.Result.ReasonPhrase}");
                throw new HttpRequestException($"Error posting data to {endpoint}: {response.Result.ReasonPhrase}");
            }
        }

        public void Dispose()
        {
            _HttpClient?.Dispose();
        }
    }
}
