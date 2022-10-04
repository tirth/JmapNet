using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapEmailChangesResponse(string AccountId) : JmapChangesResponse(AccountId)
{
    public override string Name => JmapMethods.EmailChanges;
}
