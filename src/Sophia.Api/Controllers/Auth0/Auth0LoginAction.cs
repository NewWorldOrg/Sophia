namespace Sophia.Api.Controllers.Auth0;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;

public class Auth0LoginAction(IConfiguration configuration) : Controller
{
    /// <summary>
    /// Auth0 Universal Loginへリダイレクトする。
    /// </summary>
    /// <param name="return_to">認証後のリダイレクト先パス（graceのパス）</param>
    /// <response code="302">Auth0ログインページへリダイレクト</response>
    [HttpGet("/auth0/login")]
    [ProducesResponseType(StatusCodes.Status302Found)]
    public IActionResult Invoke([FromQuery] string? return_to)
    {
        var graceOrigin = configuration["Grace:Origin"]!;

        var redirectPath = return_to is not null && return_to.StartsWith('/')
            ? return_to
            : "/";

        var properties = new AuthenticationProperties
        {
            RedirectUri = $"{graceOrigin}{redirectPath}"
        };

        return Challenge(properties, OpenIdConnectDefaults.AuthenticationScheme);
    }
}
