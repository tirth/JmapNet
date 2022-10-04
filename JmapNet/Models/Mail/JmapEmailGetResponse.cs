using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapEmailGetResponse(string AccountId) : JmapGetResponse<JmapEmail>(AccountId)
{
    public override string Name => JmapMethods.EmailGet;
}
