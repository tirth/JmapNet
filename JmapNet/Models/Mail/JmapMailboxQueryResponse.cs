using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapMailboxQueryResponse(string AccountId) : JmapQueryResponse(AccountId)
{
    public override string Name => JmapMethods.MailboxQuery;
}
