namespace JmapNet.Models.Core;

[PublicAPI]
public record JmapSetError
{
    public string Type { get; init; } = null!;
    public string? Description { get; init; }
    public IList<string>? Properties { get; init; }
}
