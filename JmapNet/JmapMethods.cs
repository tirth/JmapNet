namespace JmapNet;

[PublicAPI]
public static class JmapMethods
{
    public const string Error = "error";

    // core
    public const string CoreEcho = "Core/echo";

    // mailbox
    public const string MailboxGet = "Mailbox/get";
    public const string MailboxChanges = "Mailbox/changes";
    public const string MailboxQuery = "Mailbox/query";
    public const string MailboxQueryChanges = "Mailbox/queryChanges";
    public const string MailboxSet = "Mailbox/set";

    // thread
    public const string ThreadGet = "Thread/get";
    public const string ThreadChanges = "Thread/changes";

    // email
    public const string EmailGet = "Email/get";
    public const string EmailChanges = "Email/changes";
    public const string EmailQuery = "Email/query";
    public const string EmailQueryChanges = "Email/queryChanges";
    public const string EmailSet = "Email/set";
    public const string EmailCopy = "Email/copy";
    public const string EmailImport = "Email/import";
    public const string EmailParse = "Email/parse";

    // search snippet
    public const string SearchSnippetGet = "SearchSnippet/get";

    // identity
    public const string IdentityGet = "Identity/get";
    public const string IdentityChanges = "Identity/changes";
    public const string IdentitySet = "Identity/set";

    // email submission
    public const string EmailSubmissionGet = "EmailSubmission/get";
    public const string EmailSubmissionChanges = "EmailSubmission/changes";
    public const string EmailSubmissionQuery = "EmailSubmission/query";
    public const string EmailSubmissionSet = "EmailSubmission/set";
}
