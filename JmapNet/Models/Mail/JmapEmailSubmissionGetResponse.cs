using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapEmailSubmissionGetResponse(string AccountId) : JmapGetResponse<JmapEmailSubmission>(AccountId)
{
    public override string Name => JmapMethods.EmailSubmissionGet;
}
