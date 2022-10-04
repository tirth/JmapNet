using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapEmailSubmissionQueryResponse(string AccountId) : JmapQueryResponse(AccountId)
{
    public override string Name => JmapMethods.EmailSubmissionQuery;
}
