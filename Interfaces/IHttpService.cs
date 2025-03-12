
namespace ControlTowerDashboard.Interfaces;

public interface IHttpService
{
    Task<T?> GetAsync<T>(string endpoint);
    Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest data);
}
