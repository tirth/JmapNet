using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapEmailSubmissionChangesResponse(string AccountId) : JmapChangesResponse(AccountId)
{
    public override string Name => JmapMethods.EmailSubmissionChanges;
}
