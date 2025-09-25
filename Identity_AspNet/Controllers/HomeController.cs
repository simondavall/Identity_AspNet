using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Identity_AspNet.Models;
using Microsoft.AspNetCore.Authorization;

namespace Identity_AspNet.Controllers;

public class HomeController : Controller {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger) {
        _logger = logger;
    }

    public IActionResult Index() {
        return View();
    }

    [Authorize(Roles = "PegasusUser")]
    public IActionResult PegasusUser() {
        return View();
    }
    
    [Authorize(Roles = "Admin")]
    public IActionResult Admin() {
        return View();
    }
    
    public IActionResult Privacy() {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}