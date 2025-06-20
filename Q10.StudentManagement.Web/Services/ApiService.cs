using System.Net.Http.Headers;
using Q10.StudentManagement.Web.Common;
using Q10.StudentManagement.Web.Interfaces;
using Q10.StudentManagement.Web.Models;

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
                _Logger.LogError($"{endpoint}: {response.ReasonPhrase}");
                throw new HttpRequestException($"{endpoint}: {response.ReasonPhrase}");
            }
        }

        public async Task<bool> DeleteAsync<TRequest>(string endpoint)
        {
            var response = await _HttpClient.DeleteAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                return response.IsSuccessStatusCode;
            }
            else
            {
                _Logger.LogError($"{endpoint}: {response.ReasonPhrase}");
                throw new HttpRequestException($"{endpoint}: {response.ReasonPhrase}");
            }
        }

        public async Task<bool> PostAsync<TRequest>(string endpoint, TRequest data)
        {
            var response = await _HttpClient.PostAsJsonAsync(endpoint, data);

            if (response.IsSuccessStatusCode)
            {
                return response.IsSuccessStatusCode;
            }
            else
            {
                ErrorResponse? objErrorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                var errorMessages = new List<string>();
                if (objErrorResponse?.Errors != null)
                {
                    errorMessages = objErrorResponse.Errors.SelectMany(e => e.Value).ToList();
                }
                _Logger.LogError($"{endpoint}: {string.Join("\n", errorMessages)}");
                throw new HttpRequestException($"{endpoint}: {string.Join("\n", errorMessages)}");
            }
        }

        public async Task<bool> PutAsync<TRequest>(string endpoint, TRequest data)
        {
            var response = await _HttpClient.PutAsJsonAsync(endpoint, data);

            if (response.IsSuccessStatusCode)
            {
                return response.IsSuccessStatusCode;
            }
            else
            {
                ErrorResponse? objErrorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                var errorMessages = new List<string>();
                if (objErrorResponse?.Errors != null)
                {
                    errorMessages = objErrorResponse.Errors.SelectMany(e => e.Value).ToList();
                }
                _Logger.LogError($"{endpoint}: {string.Join("\n", errorMessages)}");
                throw new HttpRequestException($"{endpoint}: {string.Join("\n", errorMessages)}");
            }
        }

        public void Dispose()
        {
            _HttpClient?.Dispose();
        }
    }
}
