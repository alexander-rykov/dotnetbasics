UsingAppConfig
--------------

This solution shows how to use an App.config file to store configuration data:

1) Use appSettings section for storing major application settings.
2) use connectionStrings section for storing connection strings to databases and other external systems.
3) Use custom section to store hierarchal configurations in very convenient way.
4) Add XSD schema in order to enable IntelliSense when editing an App.config in Visual Studio.

MyApplication.PluginConfiguration assembly contains all classes for custom section and it has strong name.

Custom section in App.config contains information about plugins, that the application should use.

How to: Sign an Assembly with a Strong Name
https://msdn.microsoft.com/en-us/library/xc31ft41(v=vs.110).aspx

How to: Create Custom Configuration Sections Using ConfigurationSection
https://msdn.microsoft.com/en-us/library/2tw134k3.aspx

StyleCop (https://stylecop.codeplex.com/) is enabled for both projects.