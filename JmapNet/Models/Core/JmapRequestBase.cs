namespace JmapNet.Models.Core;

[PublicAPI]
public abstract record JmapRequestBase(string AccountId) : JmapBase(AccountId)
{
    public IDictionary<string, JmapResultReference>? References { get; init; }
}
