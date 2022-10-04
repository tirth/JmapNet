using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapEmailSubmissionChangesRequest(string AccountId) : JmapChangesRequest(AccountId)
{
    public override string Name => JmapMethods.EmailSubmissionChanges;
}
