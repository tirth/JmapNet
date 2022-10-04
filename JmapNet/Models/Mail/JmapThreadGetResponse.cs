using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapThreadGetResponse(string AccountId) : JmapGetResponse<JmapThread>(AccountId)
{
    public override string Name => JmapMethods.ThreadGet;
}
