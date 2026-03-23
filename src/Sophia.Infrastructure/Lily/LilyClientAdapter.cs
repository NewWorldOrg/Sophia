namespace Sophia.Infrastructure.Lily;

using Sophia.Domain.Lily;
using Sophia.Infrastructure.Lily.Generated;
using DrugDetailDomain = Sophia.Domain.Lily.DrugDetail;
using MedicationHistoryDetailDomain = Sophia.Domain.Lily.MedicationHistoryDetail;

public sealed class LilyClientAdapter(ILilyGeneratedClient client) : ILilyClient
{
    public async Task<DrugListResult> GetDrugsAsync(int? page = null, int? perPage = null)
    {
        var result = await client.ApiDrugsGetAsync(page, perPage);
        var drugs = result.Data?.Drugs;
        return new DrugListResult(
            drugs?.CurrentPage ?? 0,
            drugs?.LastPage ?? 0,
            drugs?.PerPage ?? 0,
            drugs?.Total ?? 0,
            drugs?.Data?.Select(d => new DrugDetailDomain(d.Id, d.Name, d.Url)).ToList() ?? []
        );
    }

    public async Task<DrugDetailDomain> GetDrugAsync(int id)
    {
        var result = await client.ApiDrugsGetAsync(id);
        var drug = result.Data?.Drug;
        return new DrugDetailDomain(drug?.Id ?? 0, drug?.Name ?? "", drug?.Url ?? "");
    }

    public async Task CreateDrugAsync(string drugName, string url)
    {
        await client.ApiDrugsPostAsync(new Create_drug_request
        {
            Drug_name = drugName,
            Url = url,
        });
    }

    public async Task DeleteDrugAsync(int id)
    {
        await client.ApiDrugsDeleteAsync(id);
    }

    public async Task<MedicationHistoryListResult> GetMedicationHistoriesAsync(
        long userId, int? page = null, int? perPage = null)
    {
        var result = await client.ApiMedicationHistoriesGetAsync(userId, page, perPage);
        var histories = result.Data?.MedicationHistories;
        return new MedicationHistoryListResult(
            histories?.CurrentPage ?? 0,
            histories?.LastPage ?? 0,
            histories?.PerPage ?? 0,
            histories?.Total ?? 0,
            histories?.Data?.Select(MapMedicationHistory).ToList() ?? []
        );
    }

    public async Task<MedicationHistoryDetailDomain> GetMedicationHistoryAsync(int id)
    {
        var result = await client.ApiMedicationHistoriesGetAsync(id);
        return MapMedicationHistory(result.Data?.MedicationHistory!);
    }

    public async Task<MedicationHistoryDetailDomain> CreateMedicationHistoryAsync(
        int drugId, long userId, decimal amount, string medicationDate)
    {
        var result = await client.ApiMedicationHistoriesPostAsync(
            new Create_medication_history_request
            {
                Drug_id = drugId,
                User_id = userId,
                Amount = (double)amount,
                Medication_date = medicationDate,
            });
        // Lily returns the created history under "drug" key (spec naming)
        return MapMedicationHistory(result.Data?.Drug!);
    }

    private static MedicationHistoryDetailDomain MapMedicationHistory(Medication_history_detail h) =>
        new(h.Id, h.UserId ?? 0, (decimal)h.Amount, h.DrugId ?? 0,
            h.DrugName, h.DrugUrl, h.CreatedAt, h.UpdatedAt);
}
