using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapSearchSnippetGetRequest(string AccountId) : JmapRequestBase(AccountId)
{
    public override string Name => JmapMethods.SearchSnippetGet;

    /// <summary>
    ///     The same filter as passed to Email/query; see the description of this method in Section 4.4 for details.
    /// </summary>
    public JmapEmailQueryFilter? Filter { get; init; }

    /// <summary>
    ///     The ids of the Emails to fetch snippets for.
    /// </summary>
    public IList<string>? EmailIds { get; init; }
}
