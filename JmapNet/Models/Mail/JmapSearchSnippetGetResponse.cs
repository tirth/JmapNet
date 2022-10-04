using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapSearchSnippetGetResponse(string AccountId) : JmapGetResponse<JmapSearchSnippet>(AccountId)
{
    public override string Name => JmapMethods.SearchSnippetGet;
}
