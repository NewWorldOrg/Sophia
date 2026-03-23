namespace Sophia.Api.Responder.Drug;

using Sophia.Domain.Lily;

public record GetDrugDetailResponder : BaseResponder<DrugDetail>
{
    private GetDrugDetailResponder(DrugDetail data)
        : base(true, "", null, data) { }

    public static GetDrugDetailResponder Create(DrugDetail data) => new(data);
}
