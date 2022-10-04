using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapMailboxChangesResponse(string AccountId) : JmapChangesResponse(AccountId)
{
    public override string Name => JmapMethods.MailboxChanges;

    public IList<string>? UpdatedProperties { get; init; }
}
