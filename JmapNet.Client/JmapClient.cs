using System.Net.Http.Headers;
using System.Net.Http.Json;
using JmapNet.Models.Core;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace JmapNet.Client;

/// <summary>
///     The main client class for interacting with a JMAP API.
///     Once initialized, it provides access to the JMAP Session and a SendRequest method.
///     All additional functionality is implemented as extension methods on top.
/// </summary>
public sealed class JmapClient : IDisposable
{
    private readonly HttpClient _httpClient;

    private readonly ILogger<JmapClient> _logger;

    /// <summary>
    ///     The JMAP session object.
    /// </summary>
    public JmapSession Session { get; }

    /// <summary>
    ///     The default account ID for this session, obtained from the core primary account.
    /// </summary>
    public string DefaultAccountId { get; }

    /// <summary>
    ///     The default capabilities used for requests, all that were returned for the session.
    /// </summary>
    public List<string> DefaultCapabilities { get; }

    private JmapClient(HttpClient httpClient, JmapSession session, ILogger<JmapClient>? logger = null)
    {
        _httpClient = httpClient;

        Session = session;
        DefaultAccountId = Session.PrimaryAccounts[JmapConstants.JmapCoreCapability];
        DefaultCapabilities = Session.Capabilities.Keys.ToList();

        _logger = logger ?? new NullLogger<JmapClient>();

        _logger.LogInformation("Client created: {}, for {}", session.ApiUrl, session.UserName);
    }

    /// <summary>
    ///     Disposes the underlying HttpClient.
    /// </summary>
    public void Dispose()
        => _httpClient.Dispose();

    /// <summary>
    ///     Initializes an instance backed by a new HttpClient at the base address,
    ///     configured for bearer authentication with the provided token.
    /// </summary>
    /// <param name="baseAddress">The base address of the JMAP API.</param>
    /// <param name="authToken">An authentication token with sufficient access, acquired elsewhere.</param>
    /// <param name="logger">A JmapClient logger.</param>
    /// <returns>A new instance of the JmapClient, or null if there was an error.</returns>
    public static async Task<JmapClient?> Init(Uri baseAddress, string authToken, ILogger<JmapClient>? logger = null)
    {
        var http = new HttpClient
        {
            BaseAddress = baseAddress,
            DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", authToken) }
        };

        return await Init(http, logger);
    }

    /// <summary>
    ///     Initializes an instance backed by the provided HttpClient.
    /// </summary>
    /// <param name="httpClient">An HttpClient preconfigured for API access.</param>
    /// <param name="logger">A JmapClient logger.</param>
    /// <returns>A new instance of the JmapClient, or null if there was an error.</returns>
    public static async Task<JmapClient?> Init(HttpClient httpClient, ILogger<JmapClient>? logger = null)
    {
        try
        {
            var session = await httpClient.GetFromJsonAsync<JmapSession>("jmap/session");
            if (session == null)
            {
                logger?.LogError("couldn't get session information");
                return null;
            }

            return new JmapClient(httpClient, session, logger);
        }
        catch (Exception e)
        {
            logger?.LogError(e, "error getting client: {message}", e.Message);
            return null;
        }
    }

    /// <summary>
    ///     Sends a JMAP request to the server.
    /// </summary>
    /// <param name="request">The request to send.</param>
    /// <returns>A JmapResponse if the request was successful, otherwise null.</returns>
    public async Task<JmapResponse?> SendRequest(JmapRequest request)
    {
        _logger.LogDebug("sending request: {request}", Util.Joined(request.MethodCalls.Select(m => m.Name)));

        var response = await _httpClient.PostAsJsonAsync(Session.ApiUrl, request, Jmap.JsonOpts);
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<JmapResponse>(Jmap.JsonOpts);

        // TODO: JSON problem details?
        // TODO: encapsulate in response object?
        var errorStr = await response.Content.ReadAsStringAsync();

        _logger.LogError("request error: {code}, {message}", response.StatusCode, errorStr);

        return null;
    }

    /// <summary>
    ///     Sends binary data to the server.
    /// </summary>
    /// <param name="data">Some data.</param>
    /// <param name="accountId">The account ID to use.</param>
    /// <returns></returns>
    public async Task<JmapBinaryUploadResponse?> UploadBinaryData(string accountId, Stream data)
    {
        _logger.LogDebug("uploading binary data");

        var uploadUrl = Session.UploadUrl.Replace("{accountId}", accountId);

        var response = await _httpClient.PostAsync(uploadUrl, new StreamContent(data));
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<JmapBinaryUploadResponse>();

        var errorStr = await response.Content.ReadAsStringAsync();

        _logger.LogError("binary upload error: {code}, {message}", response.StatusCode, errorStr);

        return null;
    }

    /// <summary>
    ///     Downloads binary data from the server.
    /// </summary>
    /// <param name="accountId">The account ID to use.</param>
    /// <param name="blobId">The blob ID.</param>
    /// <param name="type">The content-type to set.</param>
    /// <param name="name">The file name to set.</param>
    /// <returns>The requested data.</returns>
    public async Task<Stream?> DownloadBinaryData(string accountId, string blobId, string type, string name)
    {
        _logger.LogDebug("downloading {blobId} as {type}, {name}", blobId, type, name);

        var downloadUrl = Session.DownloadUrl
            .Replace("{accountId}", accountId)
            .Replace("{blobId}", blobId)
            .Replace("{type}", type)
            .Replace("{name}", name);

        var response = await _httpClient.GetAsync(downloadUrl);
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadAsStreamAsync();

        var errorStr = await response.Content.ReadAsStringAsync();

        _logger.LogError("binary download error: {code}, {message}", response.StatusCode, errorStr);

        return null;
    }
}
