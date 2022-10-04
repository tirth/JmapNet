using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapMailboxChangesRequest(string AccountId) : JmapChangesRequest(AccountId)
{
    public override string Name => JmapMethods.MailboxChanges;
}
