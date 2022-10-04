using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapThreadGetRequest(string AccountId) : JmapGetRequest(AccountId)
{
    public override string Name => JmapMethods.ThreadGet;
}
