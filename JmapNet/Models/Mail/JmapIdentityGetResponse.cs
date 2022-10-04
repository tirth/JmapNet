using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapIdentityGetResponse(string AccountId) : JmapGetResponse<JmapIdentity>(AccountId)
{
    public override string Name => JmapMethods.IdentityGet;
}
