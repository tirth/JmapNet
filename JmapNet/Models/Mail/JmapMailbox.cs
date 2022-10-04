using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapMailbox : JmapObjBase
{
    public string Name { get; init; } = null!;
    public string? ParentId { get; init; }
    public string? Role { get; init; }
    public int SortOrder { get; init; }
    public int TotalEmails { get; init; }
    public int UnreadEmails { get; init; }
    public bool IsSubscribed { get; init; }
}
