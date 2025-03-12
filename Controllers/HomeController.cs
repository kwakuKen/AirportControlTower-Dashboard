using Microsoft.AspNetCore.Mvc;

namespace ControlTowerDashboard.Controllers;

public class HomeController(ILogger<HomeController> logger) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Dashboard()
    {
        return View();
    }

    public IActionResult AircraftList()
    {
        return View();
    }

    public IActionResult HistoricalLogs()
    {
        return View();
    }

}
