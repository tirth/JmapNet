using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapEmailSetRequest(string AccountId) : JmapSetRequest<JmapEmail>(AccountId)
{
    public override string Name => JmapMethods.EmailSet;
}
