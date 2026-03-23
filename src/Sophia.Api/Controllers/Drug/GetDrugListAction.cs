namespace Sophia.Api.Controllers.Drug;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sophia.Api.Responder.Drug;
using Sophia.Api.Services;

public class GetDrugListAction(DrugService drugService) : ControllerBase
{
    [HttpGet("/api/drugs")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [ProducesResponseType<GetDrugListResponder>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Invoke(
        [FromQuery] int? page = null,
        [FromQuery] int? per_page = null)
    {
        var result = await drugService.GetListAsync(page, per_page);
        return Ok(GetDrugListResponder.Create(result));
    }
}
