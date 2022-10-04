namespace JmapNet.Models.Core;

[PublicAPI]
public abstract record JmapChangesResponse(string AccountId) : JmapBase(AccountId)
{
    public string OldState { get; init; } = null!;
    public string NewState { get; init; } = null!;
    public bool HasMoreChanges { get; init; }
    public IList<string> Created { get; init; } = new List<string>();
    public IList<string> Updated { get; init; } = new List<string>();
    public IList<string> Destroyed { get; init; } = new List<string>();
}
