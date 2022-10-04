namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapAddress
{
    /// <summary>
    ///     The email address being represented by the object. This is a “Mailbox” as used in the Reverse-path or Forward-path
    ///     of the MAIL FROM or RCPT TO command in RFC5321.
    /// </summary>
    public string Email { get; init; } = null!;

    /// <summary>
    ///     Any parameters to send with the email address (either mail-parameter or rcpt-parameter as appropriate, as specified
    ///     in RFC5321.
    /// </summary>
    public object? Parameters { get; init; }
}
