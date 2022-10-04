namespace JmapNet.Models.Core;

[PublicAPI]
public abstract record JmapQueryRequest<TFilter>(string AccountId) : JmapRequestBase(AccountId)
{
    public TFilter? Filter { get; init; }

    // public JmapFilterOperator<TFilter>? FilterRe { get; init; }
    public IList<JmapComparator>? Sort { get; init; }
    public int Position { get; init; }
    public int? Limit { get; init; }
}
