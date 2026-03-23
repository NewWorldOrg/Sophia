namespace Sophia.Api.Requests.Drug;

using System.ComponentModel.DataAnnotations;

public record UpdateDrugRequest
{
    [Required]
    public required string DrugName { get; init; }

    [Required]
    public required string Url { get; init; }

    public string? Note { get; init; }
}
