namespace JmapNet.Models.Core;

[PublicAPI]
public abstract record JmapBase(string AccountId)
{
    public abstract string Name { get; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
