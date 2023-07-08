using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StateManagement.Models;
using Microsoft.AspNetCore.Http;

namespace StateManagement.Controllers;

public class HomeController : Controller
{
    private const string SessionKeyName = "_Name";
    private const string SessionKeyAge = "_Age";
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        HttpContext.Session.SetString(SessionKeyName,"furkan");
        HttpContext.Session.SetInt32(SessionKeyAge,23);

        return View();
    }

    public IActionResult Privacy()
    {
        ViewData["Name"] = HttpContext.Session.GetString(SessionKeyName);
        ViewData["Age"]= HttpContext.Session.GetInt32(SessionKeyAge);

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
