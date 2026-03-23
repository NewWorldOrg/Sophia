namespace Sophia.Api.Controllers.Drug;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sophia.Api.Responder.Drug;
using Sophia.Api.Services;

public class GetDrugDetailAction(DrugService drugService) : ControllerBase
{
    [HttpGet("/api/drugs/{id}")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [ProducesResponseType<GetDrugDetailResponder>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Invoke(int id)
    {
        var result = await drugService.GetDetailAsync(id);
        return Ok(GetDrugDetailResponder.Create(result));
    }
}
