namespace Sophia.Api.Requests.MedicationHistory;

using System.ComponentModel.DataAnnotations;

public record CreateMedicationHistoryRequest
{
    [Required]
    public required int DrugId { get; init; }

    [Required]
    public required decimal Amount { get; init; }

    [Required]
    public required string MedicationDate { get; init; }
}
