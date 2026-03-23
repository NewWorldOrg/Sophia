namespace Sophia.Api.Responder.MedicationHistory;

using Sophia.Domain.Lily;

public record GetMedicationHistoriesResponder : BaseResponder<MedicationHistoryListResult>
{
    private GetMedicationHistoriesResponder(MedicationHistoryListResult data)
        : base(true, "", null, data) { }

    public static GetMedicationHistoriesResponder Create(MedicationHistoryListResult data) => new(data);
}
