namespace Sophia.Api.Responder.Drug;

using Sophia.Domain.Lily;

public record GetDrugListResponder : BaseResponder<DrugListResult>
{
    private GetDrugListResponder(DrugListResult data)
        : base(true, "", null, data) { }

    public static GetDrugListResponder Create(DrugListResult data) => new(data);
}
