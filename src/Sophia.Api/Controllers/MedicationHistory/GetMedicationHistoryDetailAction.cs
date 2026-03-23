namespace Sophia.Api.Controllers.MedicationHistory;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sophia.Api.Responder.MedicationHistory;
using Sophia.Api.Services;

public class GetMedicationHistoryDetailAction(MedicationHistoryService service) : ControllerBase
{
    [HttpGet("/api/medication-histories/{id}")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [ProducesResponseType<GetMedicationHistoryDetailResponder>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Invoke(int id)
    {
        var result = await service.GetDetailAsync(id);
        return Ok(GetMedicationHistoryDetailResponder.Create(result));
    }
}
