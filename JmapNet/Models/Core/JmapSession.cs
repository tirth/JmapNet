namespace JmapNet.Models.Core;

/// <summary>
///     Gives details about the data and capabilities the server can provide to the client.
/// </summary>
[PublicAPI]
public record JmapSession
{
    private readonly IDictionary<string, object> _capabilities = new Dictionary<string, object>();

    /// <summary>
    ///     The URL to use for JMAP API requests.
    /// </summary>
    public string ApiUrl { get; init; } = null!;

    /// <summary>
    ///     The URL endpoint to use when downloading files, in URI Template (level 1) format (RFC6570).
    /// </summary>
    public string DownloadUrl { get; init; } = null!;

    /// <summary>
    ///     The URL endpoint to use when uploading files, in URI Template (level 1) format (RFC6570).
    /// </summary>
    public string UploadUrl { get; init; } = null!;

    /// <summary>
    ///     The URL to connect to for push events, as described in Section 7.3, in URI Template (level 1) format (RFC6570).
    /// </summary>
    public string EventSourceUrl { get; init; } = null!;

    /// <summary>
    ///     The username associated with the given credentials, or the empty string if none.
    /// </summary>
    public string UserName { get; init; } = null!;

    /// <summary>
    ///     A (preferably short) string representing the state of this object on the server. If the value of any other property
    ///     on the Session object changes, this string will change.
    /// </summary>
    public string State { get; init; } = null!;

    public IDictionary<string, object> Capabilities
    {
        get => _capabilities;
        init
        {
            _capabilities = value;

            CoreCapabilities = ((JsonElement)value[JmapConstants.JmapCoreCapability])
                .Deserialize<JmapCoreCapabilities>(Jmap.JsonOpts);
        }
    }

    public JmapCoreCapabilities? CoreCapabilities { get; private init; }

    /// <summary>
    ///     A map of an account ID to an Account object for each account (see Section 1.6.2) the user has access to.
    /// </summary>
    public IDictionary<string, JmapAccount> Accounts { get; init; } = new Dictionary<string, JmapAccount>();

    /// <summary>
    ///     A map of capability URIs (as found in accountCapabilities) to the account id that is considered to be the user’s
    ///     main or default account for data pertaining to that capability.
    /// </summary>

    public IDictionary<string, string> PrimaryAccounts { get; init; } = new Dictionary<string, string>();
}
