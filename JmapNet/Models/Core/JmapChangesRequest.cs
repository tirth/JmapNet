namespace JmapNet.Models.Core;

[PublicAPI]
public abstract record JmapChangesRequest(string AccountId) : JmapRequestBase(AccountId)
{
    public string SinceState { get; init; } = null!;
    public uint? MaxChanges { get; init; }
}
