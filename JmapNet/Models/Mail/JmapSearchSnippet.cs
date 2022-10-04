using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

/// <summary>
///     When doing a search on a String property, the client may wish to show the relevant section of the body that matches
///     the search as a preview and to highlight any matching terms in both this and the subject of the Email. Search
///     snippets represent this data.
/// </summary>
[PublicAPI]
public record JmapSearchSnippet : JmapObjBase
{
    /// <summary>
    ///     The Email id the snippet applies to.
    /// </summary>
    public string EmailId { get; init; } = null!;

    /// <summary>
    ///     If text from the filter matches the subject, this is the subject of the Email with the specified transformations.
    /// </summary>
    public string? Subject { get; init; }

    /// <summary>
    ///     If text from the filter matches the plaintext or HTML body, this is the relevant section of the body (converted to
    ///     plaintext if originally HTML), with the same transformations as the subject property. It MUST NOT be bigger than
    ///     255 octets in size. If the body does not contain a match for the text from the filter, this property is null.
    /// </summary>
    public string? Preview { get; init; }
}
