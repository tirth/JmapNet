using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapMailboxSetResponse(string AccountId) : JmapSetResponse<JmapMailbox>(AccountId)
{
    public override string Name => JmapMethods.MailboxSet;
}
