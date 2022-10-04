using JmapNet.Models.Core;

namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapEmailSubmissionSetRequest(string AccountId) : JmapSetRequest<JmapEmailSubmission>(AccountId)
{
    public override string Name => JmapMethods.EmailSubmissionSet;

    public IDictionary<string, object>? OnSuccessUpdateEmail { get; init; }

    public IList<string>? OnSuccessDestroyEmail { get; init; }
}
