namespace JmapNet.Models.Core;

[PublicAPI]
public record JmapResultReference
{
    public string ResultOf { get; init; } = null!;
    public string Name { get; init; } = null!;
    public string Path { get; init; } = null!;
}
