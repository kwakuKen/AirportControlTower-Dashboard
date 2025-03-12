using ControlTowerDashboard.Interfaces;
using ControlTowerDashboard.Models;

namespace ControlTowerDashboard.Services;

public class DashboardService(
    IHttpService httpService,
    ILogger<DashboardService> logger
    )
    : IDashboardService
{
    public async Task<AircraftListViewModel[]> AircraftListWithDataShared()
    {
        try
        {
            var result = await httpService.GetAsync<AircraftListViewModel[]>("list-aircraft");
            if (result is null) return [];
            return result;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error in DashboardService");
        }
        return [];
    }

    public async Task<AircraftLogViewModel[]> AircraftLog()
    {
        try
        {
            var result = await httpService.GetAsync<AircraftLogViewModel[]>("aircraft-logs");
            if (result is null) return [];
            return result;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error in DashboardService");
        }
        return [];
    }

    public async Task<DashboardViewModel> DashboardView()
    {
        try
        {
            var weatherTask = httpService.GetAsync<WeatherDetailsViewModel>("weather");
            var parkingTask = httpService.GetAsync<ParkingSpotViewModel[]>("parking-spot");
            var flightTask = httpService.GetAsync<FlightLogsViewModel[]>("flight-logs");

            await Task.WhenAll(weatherTask, parkingTask, flightTask);

            var weatherResult = await weatherTask;
            var parkingResult = await parkingTask;
            var flightResult = await flightTask;

            return new DashboardViewModel()
            {
                Weather = weatherResult ?? new WeatherDetailsViewModel(),
                Parking = parkingResult ?? [],
                Logs = flightResult ?? []
            };
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error in DashboardService");
        }
        return default!;
    }

    public async Task<LoginResponse?> Login(LoginViewModel loginViewModel)
    {
        try
        {
            var result = await httpService.PostAsync<LoginViewModel, LoginResponse>("login", loginViewModel);
            if (result is null) return default;
            return result;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error in DashboardService");
        }
        return default!;
    }
}
