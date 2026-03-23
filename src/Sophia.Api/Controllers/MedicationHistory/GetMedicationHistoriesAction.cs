namespace Sophia.Api.Controllers.MedicationHistory;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sophia.Api.Responder;
using Sophia.Api.Responder.MedicationHistory;
using Sophia.Api.Services;

public class GetMedicationHistoriesAction(MedicationHistoryService service) : ControllerBase
{
    [HttpGet("/api/medication-histories")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [ProducesResponseType<GetMedicationHistoriesResponder>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Invoke(
        [FromQuery] int? page = null,
        [FromQuery] int? per_page = null)
    {
        var auth0Sub = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
        var discordId = await service.ResolveDiscordUserIdAsync(auth0Sub);

        if (discordId is null)
        {
            return BadRequest(new BaseResponder<object>(false, "Discord account not linked", null, null));
        }

        var result = await service.GetListAsync(discordId.Value, page, per_page);
        return Ok(GetMedicationHistoriesResponder.Create(result));
    }
}
