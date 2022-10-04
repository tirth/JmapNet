using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapEmailQueryResponse(string AccountId) : JmapQueryResponse(AccountId)
{
    public override string Name => JmapMethods.EmailQuery;
}
