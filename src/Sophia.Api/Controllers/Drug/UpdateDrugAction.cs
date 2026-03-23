namespace Sophia.Api.Controllers.Drug;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sophia.Api.Responder;
using Sophia.Api.Services;

public class UpdateDrugAction(DrugService drugService) : ControllerBase
{
    [HttpPut("/api/drugs/{id}")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [ProducesResponseType<BaseResponder<object>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Invoke(int id, [FromBody] Requests.Drug.UpdateDrugRequest request)
    {
        await drugService.UpdateAsync(id, request.DrugName, request.Url, request.Note);
        return Ok(BaseResponder<object>.Success(null!));
    }
}
