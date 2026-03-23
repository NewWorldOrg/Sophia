namespace Sophia.Domain.Lily;

public interface ILilyClient
{
    // Drug
    Task<DrugListResult> GetDrugsAsync(int? page = null, int? perPage = null);
    Task<DrugDetail> GetDrugAsync(int id);
    Task CreateDrugAsync(string drugName, string url);
    Task DeleteDrugAsync(int id);

    // MedicationHistory
    Task<MedicationHistoryListResult> GetMedicationHistoriesAsync(long userId, int? page = null, int? perPage = null);
    Task<MedicationHistoryDetail> GetMedicationHistoryAsync(int id);
    Task<MedicationHistoryDetail> CreateMedicationHistoryAsync(int drugId, long userId, decimal amount, string medicationDate);
}
