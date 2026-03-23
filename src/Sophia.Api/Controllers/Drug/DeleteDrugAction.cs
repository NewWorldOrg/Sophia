namespace Sophia.Api.Controllers.Drug;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sophia.Api.Responder;
using Sophia.Api.Services;

public class DeleteDrugAction(DrugService drugService) : ControllerBase
{
    [HttpDelete("/api/drugs/{id}")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [ProducesResponseType<BaseResponder<object>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Invoke(int id)
    {
        await drugService.DeleteAsync(id);
        return Ok(BaseResponder<object>.Success(null!));
    }
}
