using JmapNet.Models.Core;
using JmapNet.Models.Mail;

namespace JmapNet.Client;

/// <summary>
///     Extensions providing most of the key functionality for the JMAP client.
/// </summary>
public static class JmapClientExtensions
{
    /// <summary>
    ///     A set of properties expected to be fast to retrieve from
    ///     a quality server implementation.
    /// </summary>
    private static readonly List<string> DefaultEmailProperties = new()
    {
        "id", "blobId", "threadId", "mailboxIds",
        "subject", "sentAt", "receivedAt", "from",
        "size", "keywords", "hasAttachment"
    };

    /// <summary>
    ///     Sends a request with the default using capabilities, assembled from the
    ///     given invocations.
    /// </summary>
    /// <param name="jmap">The JMAP client.</param>
    /// <param name="invocations">Invocations to send.</param>
    /// <returns>The response, or null if error.</returns>
    public static Task<JmapResponse?> SendRequest(this JmapClient jmap, params JmapInvocation[] invocations)
        => jmap.SendRequest(new JmapRequest
        {
            Using = jmap.DefaultCapabilities,
            MethodCalls = invocations.ToList()
        });

    /// <summary>
    ///     Uploads binary data with the default account.
    /// </summary>
    /// <param name="jmap">The JMAP client.</param>
    /// <param name="data">Some data to upload.</param>
    /// <returns>The response if successful, else null.</returns>
    public static Task<JmapBinaryUploadResponse?> UploadBinaryData(this JmapClient jmap, Stream data)
        => jmap.UploadBinaryData(jmap.DefaultAccountId, data);

    /// <summary>
    ///     Downloads binary data with the default account.
    /// </summary>
    /// <param name="jmap">The JMAP client.</param>
    /// <param name="blobId">The blob ID.</param>
    /// <param name="type">The content-type to set.</param>
    /// <param name="name">The file name to set.</param>
    /// <returns>The data if successful, else null.</returns>
    public static Task<Stream?> DownloadBinaryData(this JmapClient jmap, string blobId, string type = "application/octet-stream", string name = "file_download")
        => jmap.DownloadBinaryData(jmap.DefaultAccountId, blobId, type, name);

    /// <summary>
    ///     Sends a query and subsequent get request for mailboxes.
    /// </summary>
    /// <param name="jmap">The JMAP client.</param>
    /// <param name="filter">The mailbox query filter.</param>
    /// <param name="sort">The sort.</param>
    /// <param name="count">The maximum number of results.</param>
    /// <returns>The resulting mailboxes.</returns>
    public static async Task<IList<JmapMailbox>> GetMailboxes(this JmapClient jmap,
        JmapMailboxQueryFilter? filter = null, List<JmapComparator>? sort = null, int count = 10)
    {
        var mailboxQuery = new JmapMailboxQueryRequest(jmap.DefaultAccountId)
        {
            Filter = filter,
            Sort = sort,
            Limit = count
        }.Invoke("a");

        var mailboxGet = new JmapMailboxGetRequest(jmap.DefaultAccountId)
        {
            References = new Dictionary<string, JmapResultReference>
            {
                { "#ids", mailboxQuery.GetRef("/ids/*") }
            }
        }.Invoke("b");

        var mailboxResponse = await jmap.SendRequest(mailboxQuery, mailboxGet);

        return mailboxResponse.GetItems<JmapMailbox>(mailboxGet);
    }

    /// <summary>
    ///     Sends a query and subsequent get request for emails.
    /// </summary>
    /// <param name="jmap">The JMAP client.</param>
    /// <param name="filter">The email query filter.</param>
    /// <param name="sort">The sort.</param>
    /// <param name="properties">The properties to retrieve.</param>
    /// <param name="count">The maximum number of results.</param>
    /// <returns>The resulting emails.</returns>
    public static async Task<IList<JmapEmail>> GetEmails(this JmapClient jmap,
        JmapEmailQueryFilter? filter = null, IList<JmapComparator>? sort = null,
        List<string>? properties = null, int count = 10)
    {
        var emailQuery = new JmapEmailQueryRequest(jmap.DefaultAccountId)
        {
            Filter = filter,
            Sort = sort,
            Limit = count
        }.Invoke("a");

        var emailGet = new JmapEmailGetRequest(jmap.DefaultAccountId)
        {
            References = new Dictionary<string, JmapResultReference>
            {
                { "#ids", emailQuery.GetRef("/ids/*") }
            },
            Properties = properties ?? DefaultEmailProperties
        }.Invoke("b");

        var emailResponse = await jmap.SendRequest(emailQuery, emailGet);

        return emailResponse.GetItems<JmapEmail>(emailGet);
    }
}
