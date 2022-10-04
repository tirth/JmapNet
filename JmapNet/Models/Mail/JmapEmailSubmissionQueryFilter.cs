namespace JmapNet.Models.Mail;

[PublicAPI]
public record JmapEmailSubmissionQueryFilter
{
    public IList<string>? IdentityIds { get; init; }
    public IList<string>? EmailIds { get; init; }
    public IList<string>? ThreadIds { get; init; }
    public JmapUndoStatus? UndoStatus { get; init; }
    public DateTime? Before { get; init; }
    public DateTime? After { get; init; }
}
