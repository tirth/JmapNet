namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapEmailBodyValue
{
    public string Value { get; init; } = null!;
    public bool IsEncodingProblem { get; init; }
    public bool IsTruncated { get; init; }
}
