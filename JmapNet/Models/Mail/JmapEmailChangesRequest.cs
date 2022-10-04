using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapEmailChangesRequest(string AccountId) : JmapChangesRequest(AccountId)
{
    public override string Name => JmapMethods.EmailChanges;
}
