namespace JmapNet.Models.Core;

/// <summary>
///     Information on server capabilities.
/// </summary>
[PublicAPI]
public record JmapCoreCapabilities
{
    /// <summary>
    ///     The maximum file size, in octets, that the server will accept for a single file upload (for any purpose). Suggested
    ///     minimum: 50,000,000.
    /// </summary>
    public uint MaxSizeUpload { get; init; }

    /// <summary>
    ///     The maximum number of concurrent requests the server will accept to the upload endpoint. Suggested minimum: 4.
    /// </summary>
    public uint MaxConcurrentUpload { get; init; }

    /// <summary>
    ///     The maximum size, in octets, that the server will accept for a single request to the API endpoint. Suggested
    ///     minimum: 10,000,000.
    /// </summary>
    public uint MaxSizeRequest { get; init; }

    /// <summary>
    ///     The maximum number of concurrent requests the server will accept to the API endpoint. Suggested minimum: 4.
    /// </summary>
    public uint MaxConcurrentRequests { get; init; }

    /// <summary>
    ///     The maximum number of method calls the server will accept in a single request to the API endpoint. Suggested
    ///     minimum: 16.
    /// </summary>
    public uint MaxCallsInRequest { get; init; }

    /// <summary>
    ///     The maximum number of objects that the client may request in a single /get type method call. Suggested minimum:
    ///     500.
    /// </summary>
    public uint MaxObjectsInGet { get; init; }

    /// <summary>
    ///     The maximum number of objects the client may send to create, update, or destroy in a single /set type method call.
    ///     This is the combined total, e.g., if the maximum is 10, you could not create 7 objects and destroy 6, as this would
    ///     be 13 actions, which exceeds the limit. Suggested minimum: 500.
    /// </summary>
    public uint MaxObjectsInSet { get; init; }

    /// <summary>
    ///     A list of identifiers for algorithms registered in the collation registry, as defined in RFC4790, that the server
    ///     supports for sorting when querying records.
    /// </summary>
    public IList<string> CollationAlgorithms { get; init; } = new List<string>();
}
