using ControlTowerDashboard.Interfaces;
using ControlTowerDashboard.Models;
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

    [HttpPost]
    public async Task<IActionResult> Index(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);
        var result = await dashboardService.Login(model);
        if (result is null)
        {
            ViewData["Error"] = "Invalid username or password.";
            return View(model);
        }
        else
        {
            HttpContext.Session.SetString("Username", result?.username);
            return RedirectToAction("Dashboard", "Home");
        }
    }

    public async Task<IActionResult> Dashboard()
    {
        if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
        {
            return RedirectToAction("Index", "Home");
        }
        var result = await dashboardService.DashboardView();
        return View(result);
    }

    public async Task<IActionResult> AircraftList()
    {
        if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
        {
            return RedirectToAction("Index", "Home");
        }
        var result = await dashboardService.AircraftListWithDataShared();
        return View(result);
    }

    public async Task<IActionResult> HistoricalLogs()
    {
        if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
        {
            return RedirectToAction("Index", "Home");
        }
        var result = await dashboardService.AircraftLog();
        return View(result);
    }

}
