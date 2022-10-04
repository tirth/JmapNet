using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapIdentitySetRequest(string AccountId) : JmapSetRequest<JmapIdentity>(AccountId)
{
    public override string Name => JmapMethods.IdentitySet;
}
