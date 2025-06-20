namespace Q10.StudentManagement.Web.Interfaces
{
    public interface IApiService
    {
        Task<TResponse> GetAsync<TResponse>(string endpoint);
        Task<bool> PostAsync<TRequest>(string endpoint, TRequest data);
        bool Put<TRequest>(string endpoint, TRequest data);
        bool Delete<TResponse>(string endpoint);
    }
}
