using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapEmailQueryRequest(string AccountId) : JmapQueryRequest<JmapEmailQueryFilter>(AccountId)
{
    public override string Name => JmapMethods.EmailQuery;
    public bool CollapseThreads { get; init; }
}
