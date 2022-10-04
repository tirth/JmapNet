namespace JmapNet.Models.Core;

[PublicAPI]
public record JmapBinaryUploadResponse
{
    /// <summary>
    ///     The id of the account used for the call.
    /// </summary>
    public string AccountId { get; init; } = null!;

    /// <summary>
    ///     The id representing the binary data uploaded. The data for this id is immutable. The id only refers to the binary
    ///     data, not any metadata.
    /// </summary>
    public string BlobId { get; init; } = null!;

    /// <summary>
    ///     The media type of the file (as specified in RFC6838, Section 4.2) as set in the Content-Type header of the upload
    ///     HTTP request.
    /// </summary>
    public string Type { get; init; } = null!;

    /// <summary>
    ///     The size of the file in octets.
    /// </summary>
    public uint Size { get; init; }
}
