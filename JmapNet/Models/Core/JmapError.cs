namespace JmapNet.Models.Core;

[PublicAPI]
public record JmapError(string Type, string? Description) : JmapBase("")
{
    public override string Name => JmapMethods.Error;
}
