using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

/// <summary>
///     The response from an email set request.
/// </summary>
/// <param name="AccountId">Account ID</param>
[PublicAPI]
public record JmapEmailSetResponse(string AccountId) : JmapSetResponse<JmapEmail>(AccountId)
{
    public override string Name => JmapMethods.EmailSet;
}
