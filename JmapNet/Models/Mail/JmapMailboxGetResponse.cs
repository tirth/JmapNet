using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapMailboxGetResponse(string AccountId) : JmapGetResponse<JmapMailbox>(AccountId)
{
    public override string Name => JmapMethods.MailboxGet;
}
