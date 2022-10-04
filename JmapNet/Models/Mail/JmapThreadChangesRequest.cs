using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapThreadChangesRequest(string AccountId) : JmapChangesRequest(AccountId)
{
    public override string Name => JmapMethods.ThreadChanges;
}
