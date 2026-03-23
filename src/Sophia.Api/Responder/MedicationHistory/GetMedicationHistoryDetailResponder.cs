namespace Sophia.Api.Responder.MedicationHistory;

using Sophia.Domain.Lily;

public record GetMedicationHistoryDetailResponder : BaseResponder<MedicationHistoryDetail>
{
    private GetMedicationHistoryDetailResponder(MedicationHistoryDetail data)
        : base(true, "", null, data) { }

    public static GetMedicationHistoryDetailResponder Create(MedicationHistoryDetail data) => new(data);
}
