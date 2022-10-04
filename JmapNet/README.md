# JmapNet

Functionality to interact with the JMAP data model.

Along with the core and mail models, it contains JSON converters that map the C# objects to and from the JMAP JSON representation. 

Specifically, there is one to convert C# invocation objects to and from the 3-tuple array expected by JMAP, and a generic one for mapping requests that contain references to previous method calls.

These converters are registered in a default instance of `JsonSerializerOptions` (`Jmap.JsonOpts`) used throughout the library.
