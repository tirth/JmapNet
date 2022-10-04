using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

/// <summary>
///     Represents the submission of an Email for delivery to one or more recipients.
/// </summary>
[PublicAPI]
public record JmapEmailSubmission : JmapObjBase
{
    /// <summary>
    ///     The ID of the Identity to associate with this submission.
    /// </summary>
    public string IdentityId { get; init; } = null!;

    /// <summary>
    ///     The ID of the Email to send. The Email being sent does not have to be a draft, for example, when “redirecting” an
    ///     existing Email to a different address.
    /// </summary>
    public string EmailId { get; init; } = null!;

    /// <summary>
    ///     The Thread ID of the Email to send. This is set by the server to the threadId property of the Email referenced by
    ///     the emailId.
    /// </summary>
    public string ThreadId { get; init; } = null!;

    /// <summary>
    ///     Information for use when sending via SMTP.
    /// </summary>
    public JmapEnvelope? Envelope { get; init; }

    /// <summary>
    ///     The date the submission was/will be released for delivery.
    /// </summary>
    public DateTime SendAt { get; init; }

    /// <summary>
    ///     This represents whether the submission may be canceled.
    /// </summary>
    public JmapUndoStatus UndoStatus { get; init; }

    /// <summary>
    ///     This represents the delivery status for each of the submission’s recipients, if known.
    /// </summary>
    public IDictionary<string, JmapDeliveryStatus>? DeliveryStatus { get; init; }

    /// <summary>
    ///     A list of blob IDs for DSNs RFC3464 received for this submission, in order of receipt, oldest first. The blob is
    ///     the whole MIME message (with a top-level content-type of multipart/report), as received.
    /// </summary>
    public IList<string>? DsnBlobIds { get; init; }

    /// <summary>
    ///     A list of blob IDs for MDNs RFC8098 received for this submission, in order of receipt, oldest first. The blob is
    ///     the whole MIME message (with a top-level content-type of multipart/report), as received.
    /// </summary>
    public IList<string>? MdnBlobIds { get; init; }
}
