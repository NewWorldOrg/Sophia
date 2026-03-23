namespace Sophia.Domain.Lily;

public record DrugDetail(int Id, string Name, string Url);

public record DrugListResult(
    int CurrentPage,
    int LastPage,
    int PerPage,
    int Total,
    List<DrugDetail> Data
);
