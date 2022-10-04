namespace JmapNet.Models.Core;

[PublicAPI]
public record JmapComparator
{
    public string Property { get; init; } = null!;
    public bool? IsAscending { get; init; }
    public string? Collation { get; init; }
    public string? Keyword { get; init; }

    public static JmapComparator Asc(string prop)
        => new() { Property = Util.ToCamelCase(prop), IsAscending = true };

    public static JmapComparator Desc(string prop)
        => new() { Property = Util.ToCamelCase(prop), IsAscending = false };
}
