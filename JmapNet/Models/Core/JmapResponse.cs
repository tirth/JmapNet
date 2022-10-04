namespace JmapNet.Models.Core;

[PublicAPI]
public record JmapResponse
{
    public IList<JmapInvocation> MethodResponses { get; init; } = new List<JmapInvocation>();
    public IDictionary<string, string>? CreatedIds { get; init; }
    public string SessionState { get; init; } = null!;
    public string? LatestClientVersion { get; init; }
}
