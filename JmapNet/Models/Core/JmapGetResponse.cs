namespace JmapNet.Models.Core;

[PublicAPI]
public abstract record JmapGetResponse<TObj>(string AccountId) : JmapBase(AccountId) where TObj : JmapObjBase
{
    public string State { get; init; } = null!;
    public IList<TObj> List { get; init; } = new List<TObj>();
    public IList<string>? NotFound { get; init; }
}
