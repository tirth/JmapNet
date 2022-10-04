# JmapNet

Core functionality to interact with the JMAP data model.

Along with the core models, it contains JSON converters that map the C# objects to and from the JMAP JSON representation. 

Specifically, there is one to convert C# invocation objects to and from the 3-tuple array expected by JMAP, and a generic one for mapping requests that reference previous method calls.
