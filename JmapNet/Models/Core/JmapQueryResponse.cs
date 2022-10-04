namespace JmapNet.Models.Core;

[PublicAPI]
public abstract record JmapQueryResponse(string AccountId) : JmapBase(AccountId)
{
    public string QueryState { get; init; } = null!;
    public bool CanCalculateChanges { get; init; }
    public int Position { get; init; }
    public int? Total { get; init; }
    public int? Limit { get; init; }
    public IList<string> Ids { get; init; } = new List<string>();
}
