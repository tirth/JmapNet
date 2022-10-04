using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapEmailSubmissionSetResponse(string AccountId) : JmapSetResponse<JmapEmailSubmission>(AccountId)
{
    public override string Name => JmapMethods.EmailSubmissionSet;
}
