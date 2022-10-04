namespace JmapNet.Models.Core;

/// <summary>
///     The base class representing set requests.
/// </summary>
/// <typeparam name="TObj">The object type</typeparam>
/// <param name="AccountId">Account ID</param>
[PublicAPI]
public abstract record JmapSetRequest<TObj>(string AccountId) : JmapRequestBase(AccountId) where TObj : JmapObjBase
{
    public string? IfInState { get; init; }
    public IDictionary<string, TObj>? Create { get; init; }
    public IDictionary<string, object>? Update { get; init; }
    public IList<string>? Destroy { get; init; }
}
