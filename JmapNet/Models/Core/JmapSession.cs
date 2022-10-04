namespace JmapNet.Models.Core;

/// <summary>
///     Gives details about the data and capabilities the server can provide to the client.
/// </summary>
[PublicAPI]
public record JmapSession
{
    public string ApiUrl { get; init; } = null!;
    public string DownloadUrl { get; init; } = null!;
    public string UploadUrl { get; init; } = null!;
    public string EventSourceUrl { get; init; } = null!;
    public string UserName { get; init; } = null!;
    public string State { get; init; } = null!;

    private readonly IDictionary<string, object> _capabilities = new Dictionary<string, object>();

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
    /// A map of an account ID to an Account object for each account (see Section 1.6.2) the user has access to.
    /// </summary>
    public IDictionary<string, JmapAccount> Accounts { get; init; } = new Dictionary<string, JmapAccount>();


    public IDictionary<string, string> PrimaryAccounts { get; init; } = new Dictionary<string, string>();
}
