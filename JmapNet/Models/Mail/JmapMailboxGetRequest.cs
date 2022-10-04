using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapMailboxGetRequest(string AccountId) : JmapGetRequest(AccountId)
{
    public override string Name => JmapMethods.MailboxGet;
}
