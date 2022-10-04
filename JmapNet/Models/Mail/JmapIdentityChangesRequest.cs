using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapIdentityChangesRequest(string AccountId) : JmapChangesRequest(AccountId)
{
    public override string Name => JmapMethods.IdentityChanges;
}
