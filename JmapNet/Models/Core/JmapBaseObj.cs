namespace JmapNet.Models.Core;

[PublicAPI]
public record JmapBaseObj(string AccountId) : JmapBase(AccountId)
{
    public override string Name => "";
}
