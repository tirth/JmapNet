using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapIdentityChangesResponse(string AccountId) : JmapChangesResponse(AccountId)
{
    public override string Name => JmapMethods.IdentityChanges;
}
