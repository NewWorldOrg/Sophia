namespace Sophia.Api.Controllers;

using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    [Route("/")]
    public IActionResult Index()
    {
        return Content("高田憂希しか好きじゃない");
    }
}
