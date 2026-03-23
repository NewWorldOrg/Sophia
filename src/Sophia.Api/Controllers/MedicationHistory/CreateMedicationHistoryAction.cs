namespace Sophia.Api.Controllers.MedicationHistory;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sophia.Api.Responder;
using Sophia.Api.Responder.MedicationHistory;
using Sophia.Api.Services;

public class CreateMedicationHistoryAction(MedicationHistoryService service) : ControllerBase
{
    [HttpPost("/api/medication-histories")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [ProducesResponseType<CreateMedicationHistoryResponder>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Invoke(
        [FromBody] Requests.MedicationHistory.CreateMedicationHistoryRequest request)
    {
        var auth0Sub = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
        var discordId = await service.ResolveDiscordUserIdAsync(auth0Sub);

        if (discordId is null)
        {
            return BadRequest(new BaseResponder<object>(false, "Discord account not linked", null, null));
        }

        var result = await service.CreateAsync(
            discordId.Value, request.DrugId, request.Amount, request.MedicationDate);
        return Ok(CreateMedicationHistoryResponder.Create(result));
    }
}
