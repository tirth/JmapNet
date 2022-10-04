using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapEmailSubmissionGetRequest(string AccountId) : JmapGetRequest(AccountId)
{
    public override string Name => JmapMethods.EmailSubmissionGet;
}
