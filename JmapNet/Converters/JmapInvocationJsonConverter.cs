using JmapNet.Models.Core;

namespace JmapNet.Converters;

/// <summary>
///     Converts the invocation record to and from
///     the JMAP 3-tuple: [ "name", "arguments", "methodCallId" ].
/// </summary>
public class JmapInvocationJsonConverter : JsonConverter<JmapInvocation>
{
    /// <summary>
    ///     Reads an invocation and deserializes the response arguments based on the method name.
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    public override JmapInvocation Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // name
        reader.Read();

        var name = reader.GetString() ?? throw new InvalidOperationException("couldn't parse name");

        // arguments
        reader.Read();

        var arg = Jmap.ResponseTypes.TryGetValue(name, out var responseType)
            ? JsonSerializer.Deserialize(ref reader, responseType, options) as JmapBase
            : new JmapBaseObj("") { ExtensionData = GetRawArgs(ref reader) };

        if (arg == null) throw new InvalidOperationException("couldn't parse arg");

        // method call ID
        reader.Read();

        var methodCallId = reader.GetString() ?? throw new InvalidOperationException("couldn't parse method call ID");

        // end
        reader.Read();

        return new JmapInvocation(name, arg, methodCallId);
    }

    private static Dictionary<string, JsonElement> GetRawArgs(ref Utf8JsonReader reader)
        => JsonElement.ParseValue(ref reader)
            .EnumerateObject()
            .ToDictionary(o => o.Name, o => o.Value);

    /// <summary>
    ///     Writes an invocation to a JSON array.
    /// </summary>
    public override void Write(Utf8JsonWriter writer, JmapInvocation value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();

        // name
        writer.WriteStringValue(value.Name);

        // arguments
        JsonSerializer.Serialize(writer, value.Arguments, value.Arguments.GetType(), options);

        // method call ID
        writer.WriteStringValue(value.MethodCallId);

        writer.WriteEndArray();
    }
}
