namespace JmapNet.Models.Core;

[PublicAPI]
public abstract record JmapGetRequest(string AccountId) : JmapRequestBase(AccountId)
{
    public IList<string>? Ids { get; init; }
    public IList<string>? Properties { get; init; }
}
