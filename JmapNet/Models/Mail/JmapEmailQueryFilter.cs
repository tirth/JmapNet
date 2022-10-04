namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapEmailQueryFilter
{
    public string? InMailbox { get; init; }
    public string? From { get; init; }
    public string? To { get; init; }
    public string? Subject { get; init; }
}
