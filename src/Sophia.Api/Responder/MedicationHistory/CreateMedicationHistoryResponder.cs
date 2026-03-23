namespace Sophia.Api.Responder.MedicationHistory;

using Sophia.Domain.Lily;

public record CreateMedicationHistoryResponder : BaseResponder<MedicationHistoryDetail>
{
    private CreateMedicationHistoryResponder(MedicationHistoryDetail data)
        : base(true, "", null, data) { }

    public static CreateMedicationHistoryResponder Create(MedicationHistoryDetail data) => new(data);
}
