namespace JmapNet.Models.Core;

[PublicAPI]
public record JmapCoreEchoRequest(string AccountId) : JmapBase(AccountId)
{
    public override string Name => JmapMethods.CoreEcho;

    public object? Thing { get; init; }
}
