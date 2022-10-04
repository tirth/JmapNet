namespace JmapNet.Models.Core;

[PublicAPI]
public abstract record JmapObjBase
{
    public string Id { get; init; } = null!;

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
