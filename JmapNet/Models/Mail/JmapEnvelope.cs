namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapEnvelope
{
    /// <summary>
    ///     The email address to use as the return address in the SMTP submission, plus any parameters to pass with the MAIL
    ///     FROM address. The JMAP server MAY allow the address to be the empty string.
    /// </summary>
    public JmapAddress MailFrom { get; init; } = null!;

    /// <summary>
    ///     The email addresses to send the message to, and any RCPT TO parameters to pass with the recipient.
    /// </summary>
    public IList<JmapAddress> RcptTo { get; init; } = new List<JmapAddress>();
}
