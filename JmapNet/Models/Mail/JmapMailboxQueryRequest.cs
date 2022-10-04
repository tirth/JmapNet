using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapMailboxQueryRequest(string AccountId) : JmapQueryRequest<JmapMailboxQueryFilter>(AccountId)
{
    public override string Name => JmapMethods.MailboxQuery;
    public bool SortAsTree { get; init; }
    public bool FilterAsTree { get; init; }
}
