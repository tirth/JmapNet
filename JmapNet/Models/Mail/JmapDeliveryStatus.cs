namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapDeliveryStatus
{
    /// <summary>
    ///     The SMTP reply string returned for this recipient when the server last tried to relay the message, or in a later
    ///     Delivery Status Notification (DSN, as defined in RFC3464) response for the message. This SHOULD be the response
    ///     to the RCPT TO stage, unless this was accepted and the message as a whole was rejected at the end of the DATA
    ///     stage, in which case the DATA stage reply SHOULD be used instead.
    /// </summary>
    public string SmtpReply { get; init; } = null!;

    /// <summary>
    ///     Represents whether the message has been successfully delivered to the recipient.
    /// </summary>
    public JmapDelivered Delivered { get; init; }

    /// <summary>
    ///     Represents whether the message has been displayed to the recipient.
    /// </summary>
    public JmapDisplayed Displayed { get; init; }
}
