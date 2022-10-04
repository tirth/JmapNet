namespace JmapNet.Models.Mail;

[PublicAPI]
public enum JmapUndoStatus
{
    /// <summary>
    ///     It may be possible to cancel this submission.
    /// </summary>
    Pending,

    /// <summary>
    ///     The message has been relayed to at least one recipient in a manner that cannot be recalled. It is no longer
    ///     possible to cancel this submission.
    /// </summary>
    Final,

    /// <summary>
    ///     The submission was canceled and will not be delivered to any recipient.
    /// </summary>
    Canceled
}
