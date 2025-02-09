namespace JmapNet.Models.Mail;

/// <summary>
///     This represents support for the Identity and EmailSubmission data types and associated API methods.
/// </summary>
[PublicAPI]
public record JmapSubmissionCapabilities
{
    /// <summary>
    ///     The number in seconds of the maximum delay the server supports in sending (see the EmailSubmission object
    ///     description). This is 0 if the server does not support delayed send.
    /// </summary>
    public uint MaxDelayedSend { get; init; }

    /// <summary>
    ///     The set of SMTP submission extensions supported by the server, which the client may use when creating an
    ///     EmailSubmission object (see Section 7). Each key in the object is the ehlo-name, and the value is a list of
    ///     ehlo-args.
    /// </summary>
    public IDictionary<string, IList<string>> SubmissionExtensions { get; init; } = new Dictionary<string, IList<string>>();
}
