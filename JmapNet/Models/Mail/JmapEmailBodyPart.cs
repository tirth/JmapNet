namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapEmailBodyPart
{
    public string? PartId { get; init; }
    public string? BlobId { get; init; }
    public uint Size { get; init; }
    public IList<JmapEmailHeaders>? Headers { get; init; }
    public string? Name { get; init; }
    public string Type { get; init; } = null!;
    public string? Charset { get; init; }
    public string? Disposition { get; init; }
    public string? Cid { get; init; }
    public IList<string>? Language { get; init; }
    public string? Location { get; init; }
    public IList<JmapEmailBodyPart>? SubParts { get; init; }
}
