namespace Sophia.Api.Services;

using Sophia.Domain.Lily;

public sealed class DrugService(ILilyClient lilyClient)
{
    public async Task<DrugListResult> GetListAsync(int? page = null, int? perPage = null)
    {
        return await lilyClient.GetDrugsAsync(page, perPage);
    }

    public async Task<DrugDetail> GetDetailAsync(int id)
    {
        return await lilyClient.GetDrugAsync(id);
    }

    public async Task CreateAsync(string drugName, string url)
    {
        await lilyClient.CreateDrugAsync(drugName, url);
    }

    public async Task UpdateAsync(int id, string drugName, string url, string? note)
    {
        await lilyClient.UpdateDrugAsync(id, drugName, url, note);
    }

    public async Task DeleteAsync(int id)
    {
        await lilyClient.DeleteDrugAsync(id);
    }
}
