namespace JmapNet.Models.Core;

[PublicAPI]
public record JmapCoreEchoResponse(string AccountId) : JmapBase(AccountId)
{
    public override string Name => JmapMethods.CoreEcho;

    public object? Thing { get; init; }
}
