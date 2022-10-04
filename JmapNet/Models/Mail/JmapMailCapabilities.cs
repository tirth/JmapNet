namespace JmapNet.Models.Mail;

/// <summary>
///     This represents support for the Mailbox, Thread, Email, and SearchSnippet data types and associated API methods.
/// </summary>
[PublicAPI]
public record JmapMailCapabilities
{
    /// <summary>
    ///     The maximum number of Mailboxes (see Section 2) that can be can assigned to a single Email object (see Section 4).
    ///     This MUST be an integer >= 1, or null for no limit (or rather, the limit is always the number of Mailboxes in the
    ///     account).
    /// </summary>
    public uint? MaxMailboxesPerEmail { get; init; }

    /// <summary>
    ///     The maximum depth of the Mailbox hierarchy (i.e., one more than the maximum number of ancestors a Mailbox may
    ///     have), or null for no limit.
    /// </summary>
    public uint? MaxMailboxDepth { get; init; }

    /// <summary>
    ///     The maximum length, in (UTF-8) octets, allowed for the name of a Mailbox. This MUST be at least 100, although it is
    ///     recommended servers allow more.
    /// </summary>
    public uint MaxSizeMailboxName { get; init; }

    /// <summary>
    ///     The maximum total size of attachments, in octets, allowed for a single Email object.
    /// </summary>
    public uint MaxSizeAttachmentsPerEmail { get; init; }

    /// <summary>
    ///     A list of all the values the server supports for the “property” field of the Comparator object in an Email/query
    ///     sort (see Section 4.4.2). This MAY include properties the client does not recognise (for example, custom properties
    ///     specified in a vendor extension). Clients MUST ignore any unknown properties in the list.
    /// </summary>
    public IList<string> EmailQuerySortOptions { get; init; } = new List<string>();

    /// <summary>
    ///     If true, the user may create a Mailbox (see Section 2) in this account with a null parentId. (Permission for
    ///     creating a child of an existing Mailbox is given by the myRights property on that Mailbox.)
    /// </summary>
    public bool MayCreateTopLevelMailbox { get; init; }
}
