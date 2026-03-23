namespace Sophia.Api.Requests.Drug;

using System.ComponentModel.DataAnnotations;

public record CreateDrugRequest
{
    [Required]
    public required string DrugName { get; init; }

    [Required]
    public required string Url { get; init; }
}
