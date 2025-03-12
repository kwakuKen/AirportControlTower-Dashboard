using ControlTowerDashboard.Models;

namespace ControlTowerDashboard.Interfaces;

public interface IDashboardService
{
    Task<AircraftListViewModel[]> AircraftListWithDataShared();
    Task<AircraftLogViewModel[]> AircraftLog();
    Task<DashboardViewModel> DashboardView();
    Task<LoginResponse?> Login(LoginViewModel loginViewModel);
}
