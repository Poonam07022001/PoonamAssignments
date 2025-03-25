using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CoreWebApplication.Models;
using Microsoft.VisualStudio.Debugger.Contracts.HotReload;

namespace CoreWebApplication.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        HttpContext.Session.SetString("Name", "Poonam");
        HttpContext.Session.SetInt32("Age", 50);

        return View();
    }

    public IActionResult GetSessionResult()
    {
        User user = new User()
        {
            Name = HttpContext.Session.GetString("Name"),
            Age = HttpContext.Session.GetInt32("Age")

           
        };
        return View(user);
    }

    public IActionResult GetQueryString(string name,int age )
    {
        User user = new User()
        {
            Name = name,
             Age=age
        };
        return View(user);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
