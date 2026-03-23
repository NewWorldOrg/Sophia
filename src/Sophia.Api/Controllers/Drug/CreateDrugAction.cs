namespace Sophia.Api.Controllers.Drug;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sophia.Api.Responder;
using Sophia.Api.Services;

public class CreateDrugAction(DrugService drugService) : ControllerBase
{
    [HttpPost("/api/drugs")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [ProducesResponseType<BaseResponder<object>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Invoke([FromBody] Requests.Drug.CreateDrugRequest request)
    {
        await drugService.CreateAsync(request.DrugName, request.Url);
        return Ok(BaseResponder<object>.Success(null!));
    }
}
