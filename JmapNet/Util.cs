namespace JmapNet;

public static class Util
{
    private static readonly JsonSerializerOptions PrintOpt = new(Jmap.JsonOpts)
    {
        WriteIndented = true
    };

    public static string JsonStr(object? obj, JsonSerializerOptions? options = null)
        => JsonSerializer.Serialize(obj, options ?? PrintOpt);

    public static string Joined<T>(IEnumerable<T>? values, string separator = ", ")
        => string.Join(separator, values ?? []);

    // from System.Text.Json JsonCamelCaseNamingPolicy
    public static string ToCamelCase(string str)
        => string.Create(str.Length, str, (chars, name) =>
        {
            name.AsSpan().CopyTo(chars);
            FixCasing(chars);
        });

    private static void FixCasing(Span<char> chars)
    {
        for (var i = 0; i < chars.Length; i++)
        {
            if (i == 1 && !char.IsUpper(chars[i]))
                break;

            var hasNext = i + 1 < chars.Length;

            // Stop when next char is already lowercase.
            if (i > 0 && hasNext && !char.IsUpper(chars[i + 1]))
            {
                // If the next char is a space, lowercase current char before exiting.
                if (chars[i + 1] == ' ')
                    chars[i] = char.ToLowerInvariant(chars[i]);

                break;
            }

            chars[i] = char.ToLowerInvariant(chars[i]);
        }
    }
}
