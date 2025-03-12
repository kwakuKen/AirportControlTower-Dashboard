using ControlTowerDashboard.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControlTowerDashboard.Controllers;

public class HomeController(
    ILogger<HomeController> logger,
    IDashboardService dashboardService
    ) : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Dashboard()
    {
        var result = await dashboardService.DashboardView();
        return View(result);
    }

    public async Task<IActionResult> AircraftList()
    {
        var result = await dashboardService.AircraftListWithDataShared();
        return View(result);
    }

    public async Task<IActionResult> HistoricalLogs()
    {
        var result = await dashboardService.AircraftLog();
        return View(result);
    }

}
