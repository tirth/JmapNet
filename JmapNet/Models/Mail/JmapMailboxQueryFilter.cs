namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapMailboxQueryFilter
{
    public string? ParentId { get; init; }
    public string? Name { get; init; }
    public string? Role { get; init; }
    public bool? HasAnyRole { get; init; }
    public bool? IsSubscribed { get; init; }
}
