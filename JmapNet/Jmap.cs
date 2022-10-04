using JmapNet.Converters;
using JmapNet.Models.Core;
using JmapNet.Models.Mail;

namespace JmapNet;

[PublicAPI]
public static class Jmap
{
    // TODO: assemble response types and request converters dynamically?
    internal static readonly Dictionary<string, Type> ResponseTypes = new()
    {
        // core
        { JmapMethods.Error, typeof(JmapError) },
        { JmapMethods.CoreEcho, typeof(JmapCoreEchoResponse) },

        // mailbox
        { JmapMethods.MailboxGet, typeof(JmapMailboxGetResponse) },
        { JmapMethods.MailboxChanges, typeof(JmapMailboxChangesResponse) },
        { JmapMethods.MailboxQuery, typeof(JmapMailboxQueryResponse) },
        { JmapMethods.MailboxSet, typeof(JmapMailboxSetResponse) },

        // thread
        { JmapMethods.ThreadGet, typeof(JmapThreadGetResponse) },
        { JmapMethods.ThreadChanges, typeof(JmapThreadChangesResponse) },

        // email
        { JmapMethods.EmailGet, typeof(JmapEmailGetResponse) },
        { JmapMethods.EmailChanges, typeof(JmapEmailChangesResponse) },
        { JmapMethods.EmailQuery, typeof(JmapEmailQueryResponse) },
        { JmapMethods.EmailSet, typeof(JmapEmailSetResponse) },

        // search snippet
        { JmapMethods.SearchSnippetGet, typeof(JmapSearchSnippetGetResponse) },

        // identity
        { JmapMethods.IdentityGet, typeof(JmapIdentityGetResponse) },
        { JmapMethods.IdentityChanges, typeof(JmapIdentityChangesResponse) },
        { JmapMethods.IdentitySet, typeof(JmapIdentitySetResponse) },

        // email submission
        { JmapMethods.EmailSubmissionGet, typeof(JmapEmailSubmissionGetResponse) },
        { JmapMethods.EmailSubmissionChanges, typeof(JmapEmailSubmissionChangesResponse) },
        { JmapMethods.EmailSubmissionQuery, typeof(JmapEmailSubmissionQueryResponse) },
        { JmapMethods.EmailSubmissionSet, typeof(JmapEmailSubmissionSetResponse) }
    };

    public static readonly JsonSerializerOptions JsonOpts = new(JsonSerializerDefaults.Web)
    {
        Converters =
        {
            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
            new JmapInvocationJsonConverter(),

            // mailbox
            new JmapRequestJsonConverter<JmapMailboxGetRequest>(),
            new JmapRequestJsonConverter<JmapMailboxChangesRequest>(),
            new JmapRequestJsonConverter<JmapMailboxQueryRequest>(),
            new JmapRequestJsonConverter<JmapMailboxSetRequest>(),

            // thread
            new JmapRequestJsonConverter<JmapThreadGetRequest>(),
            new JmapRequestJsonConverter<JmapThreadChangesRequest>(),

            // email
            new JmapRequestJsonConverter<JmapEmailGetRequest>(),
            new JmapRequestJsonConverter<JmapEmailChangesRequest>(),
            new JmapRequestJsonConverter<JmapEmailQueryRequest>(),
            new JmapRequestJsonConverter<JmapEmailSetRequest>(),

            // search snippet
            new JmapRequestJsonConverter<JmapSearchSnippetGetRequest>(),

            // identity
            new JmapRequestJsonConverter<JmapIdentityGetRequest>(),
            new JmapRequestJsonConverter<JmapIdentityChangesRequest>(),
            new JmapRequestJsonConverter<JmapIdentitySetRequest>(),

            // email submission
            new JmapRequestJsonConverter<JmapEmailSubmissionGetRequest>(),
            new JmapRequestJsonConverter<JmapEmailSubmissionChangesRequest>(),
            new JmapRequestJsonConverter<JmapEmailSubmissionQueryRequest>(),
            new JmapRequestJsonConverter<JmapEmailSubmissionSetRequest>()
        },
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
        IgnoreReadOnlyProperties = true
    };

    public static JmapInvocation Invoke(this JmapBase arguments, string methodCallId)
        => new(arguments.Name, arguments, methodCallId);

    // TODO: error response handling
    public static T? GetFirstArg<T>(this JmapResponse? response, JmapInvocation invocation) where T : JmapBase
        => response?.MethodResponses.FirstOrDefault(m =>
            m.Name == invocation.Name &&
            m.MethodCallId == invocation.MethodCallId)?.Arguments as T;

    public static IList<string>? GetIds(this JmapResponse response, JmapInvocation invocation)
        => response.GetFirstArg<JmapQueryResponse>(invocation)?.Ids;

    public static IList<T> GetItems<T>(this JmapResponse? response, JmapInvocation invocation) where T : JmapObjBase
        => response?.GetFirstArg<JmapGetResponse<T>>(invocation)?.List ?? new List<T>();

    public static JmapResultReference GetRef(this JmapInvocation invocation, string path)
        => new()
        {
            ResultOf = invocation.MethodCallId,
            Name = invocation.Name,
            Path = path
        };
}
