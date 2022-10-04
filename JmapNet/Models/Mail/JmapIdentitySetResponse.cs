using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapIdentitySetResponse(string AccountId) : JmapSetResponse<JmapIdentity>(AccountId)
{
    public override string Name => JmapMethods.IdentitySet;
}
