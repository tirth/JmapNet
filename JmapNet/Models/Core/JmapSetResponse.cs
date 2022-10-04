namespace JmapNet.Models.Core;

/// <summary>
///     The base class representing set responses.
/// </summary>
/// <typeparam name="TObj">The object type</typeparam>
/// <param name="AccountId">Account ID</param>
[PublicAPI]
public abstract record JmapSetResponse<TObj>(string AccountId) : JmapBase(AccountId) where TObj : JmapObjBase
{
    public string? OldState { get; init; }
    public string NewState { get; init; } = null!;
    public IDictionary<string, TObj>? Created { get; init; }
    public IDictionary<string, TObj?>? Updated { get; init; }
    public IList<string>? Destroyed { get; init; }
    public IDictionary<string, JmapSetError>? NotCreated { get; init; }
    public IDictionary<string, JmapSetError>? NotUpdated { get; init; }
    public IDictionary<string, JmapSetError>? NotDestroyed { get; init; }
}
