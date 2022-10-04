using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

/// <summary>
///     Stores information about an email address or domain the user may send from.
/// </summary>
[PublicAPI]
public record JmapIdentity : JmapObjBase
{
    /// <summary>
    ///     The “From” name the client SHOULD use when creating a new Email from this Identity.
    /// </summary>
    public string Name { get; init; } = string.Empty;

    /// <summary>
    ///     The “From” email address the client MUST use when creating a new Email from this Identity. If the mailbox part of
    ///     the address (the section before the “@”) is the single character * (e.g., *@example.com) then the client may use
    ///     any valid address ending in that domain (e.g., foo@example.com).
    /// </summary>
    public string Email { get; init; } = null!;

    /// <summary>
    ///     The Reply-To value the client SHOULD set when creating a new Email from this Identity.
    /// </summary>
    public IList<JmapEmailAddress>? ReplyTo { get; init; }

    /// <summary>
    ///     The Bcc value the client SHOULD set when creating a new Email from this Identity.
    /// </summary>
    public IList<JmapEmailAddress>? Bcc { get; init; }

    /// <summary>
    ///     A signature the client SHOULD insert into new plaintext messages that will be sent from this Identity. Clients MAY
    ///     ignore this and/or combine this with a client-specific signature preference.
    /// </summary>
    public string TextSignature { get; init; } = string.Empty;

    /// <summary>
    ///     A signature the client SHOULD insert into new HTML messages that will be sent from this Identity. This text MUST be
    ///     an HTML snippet to be inserted into the <body></body> section of the HTML. Clients MAY ignore this and/or combine
    ///     this with a client-specific signature preference.
    /// </summary>
    public string HtmlSignature { get; init; } = string.Empty;

    /// <summary>
    ///     Is the user allowed to delete this Identity? Servers may wish to set this to false for the user’s username or other
    ///     default address. Attempts to destroy an Identity with mayDelete: false will be rejected with a standard forbidden
    ///     SetError.
    /// </summary>
    public bool MayDelete { get; init; }
}
