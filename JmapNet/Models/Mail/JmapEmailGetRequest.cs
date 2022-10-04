using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapEmailGetRequest(string AccountId) : JmapGetRequest(AccountId)
{
    public override string Name => JmapMethods.EmailGet;
    public IList<string>? BodyProperties { get; init; }
    public bool? FetchTextBodyProperties { get; init; }
}
