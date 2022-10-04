using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapIdentityGetRequest(string AccountId) : JmapGetRequest(AccountId)
{
    public override string Name => JmapMethods.IdentityGet;
}
