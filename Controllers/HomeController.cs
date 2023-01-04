using System.Diagnostics;
using InfoSoftAdmin.Filters;
using Microsoft.AspNetCore.Mvc;
using InfoSoftAdmin.Models;

namespace InfoSoftAdmin.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Https (RequireSecure = false)]
    public IActionResult Index()
    {
        return View();
    }

    [Https (RequireSecure = false)]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}