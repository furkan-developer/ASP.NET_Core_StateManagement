using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StateManagement.Models;
using StateManagement.Extensions;
using Microsoft.AspNetCore.Http;

namespace StateManagement.Controllers;

public class HomeController : Controller
{
    private const string SessionKeyPerson = "_Person";
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        Person person = new Person { Name = "furkan", Age = 23 };

        await HttpContext.Session.LoadAsync();
        HttpContext.Session.SetObject<Person>(key: SessionKeyPerson, person);

        return View();
    }

    public async Task<IActionResult> Privacy()
    {
        await HttpContext.Session.LoadAsync();
        Person? person = HttpContext.Session.GetObject<Person>(key: SessionKeyPerson);

        if (person != default)
        {
            ViewData["Name"] = person.Name;
            ViewData["Age"] = person.Age;

            return View();
        }

        ViewData["AccessPerson"] = "Don't have person";

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
