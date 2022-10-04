using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

/// <summary>
///     A representation of a RFC5322 message.
/// </summary>
[PublicAPI]
public record JmapEmail : JmapObjBase
{
    public string BlobId { get; init; } = null!;
    public string ThreadId { get; init; } = null!;
    public IDictionary<string, bool> MailboxIds { get; init; } = new Dictionary<string, bool>();
    public string? Subject { get; init; }
    public IList<JmapEmailAddress>? From { get; init; }
    public IList<JmapEmailAddress>? To { get; init; }
    public IList<JmapEmailAddress>? Cc { get; init; }
    public IList<JmapEmailAddress>? Bcc { get; init; }
    public IList<JmapEmailAddress>? ReplyTo { get; init; }
    public IDictionary<string, bool>? Keywords { get; init; }
    public int? Size { get; init; }
    public DateTime? SentAt { get; init; }
    public DateTime? ReceivedAt { get; init; }
    public bool? HasAttachment { get; init; }
    public JmapEmailBodyPart BodyStructure { get; init; } = default!;
    public IDictionary<string, JmapEmailBodyValue> BodyValues { get; init; } = new Dictionary<string, JmapEmailBodyValue>();
}
