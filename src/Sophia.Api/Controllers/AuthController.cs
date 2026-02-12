using Microsoft.AspNetCore.Mvc;

namespace Sophia.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AuthController: Controller
{
    public IActionResult Login()
    {


        return Content("Auth");
    }
}