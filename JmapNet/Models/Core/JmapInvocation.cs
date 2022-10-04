namespace JmapNet.Models.Core;

[PublicAPI]
public record JmapInvocation(string Name, JmapBase Arguments, string MethodCallId);
