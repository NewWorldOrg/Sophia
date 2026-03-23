namespace Sophia.Infrastructure.Lily.Generated;

using System.Text.Json.Serialization;

public partial class Drug_detail
{
    // Lily API returns drugId/drugName/drugUrl but the OpenAPI spec defines id/name/url.
    // These properties handle the actual serialized field names.
    [JsonPropertyName("drugId")]
    public int DrugId { set => Id = value; }

    [JsonPropertyName("drugName")]
    public string DrugName { set => Name = value; }

    [JsonPropertyName("drugUrl")]
    public string DrugUrl { set => Url = value; }
}
