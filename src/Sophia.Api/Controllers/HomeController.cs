namespace Sophia.Api.Controllers;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Models;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
}
