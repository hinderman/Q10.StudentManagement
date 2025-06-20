namespace Q10.StudentManagement.Web.Interfaces
{
    public interface IApiService
    {
        Task<TResponse> GetAsync<TResponse>(string endpoint);
        Task<bool> PostAsync<TRequest>(string endpoint, TRequest data);
        Task<bool> PutAsync<TRequest>(string endpoint, TRequest data);
        Task<bool> DeleteAsync<TResponse>(string endpoint);
    }
}
