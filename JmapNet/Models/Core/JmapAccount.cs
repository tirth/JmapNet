using JmapNet.Models.Mail;

namespace JmapNet.Models.Core;

/// <summary>
///     An account is a collection of data. A single account may contain an arbitrary set of data types, for example, a
///     collection of mail, contacts, and calendars. Most JMAP methods take a mandatory accountId argument that specifies
///     on which account the operations are to take place.
/// </summary>
[PublicAPI]
public record JmapAccount
{
    private readonly IDictionary<string, object> _accountCapabilities = new Dictionary<string, object>();

    /// <summary>
    ///     A user-friendly string to show when presenting content from this account, e.g., the email address representing the
    ///     owner of the account.
    /// </summary>
    public string Name { get; init; } = null!;

    /// <summary>
    ///     This is true if the account belongs to the authenticated user rather than a group account or a personal account of
    ///     another user that has been shared with them.
    /// </summary>
    public bool IsPersonal { get; init; }

    /// <summary>
    ///     This is true if the entire account is read-only.
    /// </summary>
    public bool IsReadOnly { get; init; }

    /// <summary>
    ///     The set of capability URIs for the methods supported in this account. Each key is a URI for a capability that has
    ///     methods you can use with this account. The value for each of these keys is an object with further information about
    ///     the account’s permissions and restrictions with respect to this capability, as defined in the capability’s
    ///     specification.
    /// </summary>
    public IDictionary<string, object> AccountCapabilities
    {
        get => _accountCapabilities;
        init
        {
            _accountCapabilities = value;

            MailCapabilities = ((JsonElement)value[JmapConstants.JmapMailCapability])
                .Deserialize<JmapMailCapabilities>(Jmap.JsonOpts);

            if (value.TryGetValue(JmapConstants.JmapSubmissionCapability, out var submissionElement))
                SubmissionCapabilities = ((JsonElement)submissionElement)
                    .Deserialize<JmapSubmissionCapabilities>(Jmap.JsonOpts);
        }
    }

    public JmapMailCapabilities? MailCapabilities { get; init; }

    public JmapSubmissionCapabilities? SubmissionCapabilities { get; init; }
}
