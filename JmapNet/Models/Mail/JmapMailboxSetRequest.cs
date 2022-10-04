using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapMailboxSetRequest(string AccountId) : JmapSetRequest<JmapMailbox>(AccountId)
{
    public override string Name => JmapMethods.MailboxSet;

    public bool OnDestroyRemoveEmails { get; init; }
}
