using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapThreadChangesResponse(string AccountId) : JmapChangesResponse(AccountId)
{
    public override string Name => JmapMethods.ThreadChanges;
}
