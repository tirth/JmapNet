using JmapNet.Models.Core;

namespace JmapNet.Converters;

/// <summary>
///     Converts request references to the JMAP reference format.
/// </summary>
/// <typeparam name="T">The type of the request.</typeparam>
public class JmapRequestJsonConverter<T> : JsonConverter<T> where T : JmapRequestBase
{
    /// <summary>
    ///     Not implemented.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => throw new NotImplementedException();

    /// <summary>
    ///     Writes a standard JSON object, converting references to JSON pointer properties.
    /// </summary>
    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        foreach (var property in value.GetType().GetProperties())
        {
            if (!property.CanRead || !property.CanWrite) // ignore read only
                continue;

            // references
            if (property.Name == nameof(JmapGetRequest.References) && value.References != null)
            {
                foreach (var (refProp, refStuff) in value.References)
                {
                    writer.WritePropertyName(refProp);
                    JsonSerializer.Serialize(writer, refStuff, options);
                }

                continue;
            }

            var propValue = property.GetValue(value);
            if (propValue == default) // ignore null and default
                continue;

            // standard properties
            writer.WritePropertyName(Util.ToCamelCase(property.Name));
            JsonSerializer.Serialize(writer, propValue, options);
        }

        writer.WriteEndObject();
    }
}
