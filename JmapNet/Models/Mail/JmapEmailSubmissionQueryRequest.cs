using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapEmailSubmissionQueryRequest(string AccountId) : JmapQueryRequest<JmapEmailSubmissionQueryFilter>(AccountId)
{
    public override string Name => JmapMethods.EmailSubmissionQuery;
}
