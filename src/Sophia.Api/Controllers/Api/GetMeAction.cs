namespace Sophia.Api.Controllers.Api;

using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sophia.Api.Responder;

public class GetMeAction : Controller
{
    /// <summary>
    /// 認証済みユーザーの情報を返す。
    /// </summary>
    /// <response code="200">ユーザー情報</response>
    /// <response code="401">未認証</response>
    [HttpGet("/api/me")]
    [Authorize]
    [ProducesResponseType(typeof(BaseResponder<MeResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult Invoke()
    {
        var data = new MeResponse(
            Id: User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "",
            Name: User.FindFirstValue("name") ?? "",
            Email: User.FindFirstValue(ClaimTypes.Email) ?? ""
        );

        return Ok(BaseResponder<MeResponse>.Success(data));
    }
}

public record MeResponse(string Id, string Name, string Email);
