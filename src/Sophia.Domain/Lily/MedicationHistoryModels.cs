namespace Sophia.Domain.Lily;

public record MedicationHistoryDetail(
    int Id,
    long UserId,
    decimal Amount,
    int DrugId,
    string DrugName,
    string DrugUrl,
    string? Note,
    string CreatedAt,
    string UpdatedAt
);

public record MedicationHistoryListResult(
    int CurrentPage,
    int LastPage,
    int PerPage,
    int Total,
    List<MedicationHistoryDetail> Data
);
