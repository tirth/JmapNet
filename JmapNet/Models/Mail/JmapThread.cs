using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapThread : JmapObjBase
{
    public IList<string> EmailIds { get; init; } = new List<string>();
}
