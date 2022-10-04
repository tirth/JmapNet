namespace JmapNet.Models.Core;

/// <summary>
///     A JMAP request object.
/// </summary>
[PublicAPI]
public record JmapRequest
{
    /// <summary>
    ///     The set of capabilities the client wishes to use.
    /// </summary>
    public IList<string> Using { get; init; } = new List<string>();

    /// <summary>
    ///     An array of method calls to process on the server.
    /// </summary>
    public IList<JmapInvocation> MethodCalls { get; init; } = new List<JmapInvocation>();

    /// <summary>
    ///     A map of a (client-specified) creation id to the id the server assigned when a record was successfully created.
    /// </summary>
    public IDictionary<string, string>? CreatedIds { get; init; }
}
