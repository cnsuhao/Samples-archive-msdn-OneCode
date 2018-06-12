# CRUD nodes in app.config (CSManipulateAppConfig)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Windows General
## Topics
* AppConfig
## IsPublished
* True
## ModifiedDate
* 2011-05-05 05:44:19
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CSManipulateAppConfig Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
CSManipulateAppConfig example demonstrates how to use ConfigurationManager to create,<br>
read, update and delete node in the config file content or use XmlDocument to update<br>
the config file content at runtime.<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
1.&nbsp;&nbsp;&nbsp;&nbsp;You just need to build this project.<br>
2.&nbsp;&nbsp;&nbsp;&nbsp;And then you can run this project. Then you will get the following result.<br>
<br>
1) Dispaly the nodes in the config file before we modify it.<br>
Original node in the config file.<br>
Key: Setting1, Value: 1<br>
Key: Setting2, Value: 2<br>
<br>
2) Create a new node(Key is &quot;Setting3&quot;, and value is &quot;3&quot;).<br>
Create a new node in the config file.<br>
Key: Setting1, Value: 1<br>
Key: Setting2, Value: 2<br>
Key: Setting3, Value: 3<br>
<br>
3) Update a node(&quot;Setting1&quot;)'s value to be &quot;New Value&quot;.<br>
Update an existing node value.<br>
Key: Setting1, Value: New Value<br>
Key: Setting2, Value: 2<br>
Key: Setting3, Value: 3<br>
<br>
4) Delete a node(Key is &quot;Setting2&quot;, and value is &quot;2&quot;).<br>
Delete an existing node.<br>
Key: Setting1, Value: New Value<br>
Key: Setting3, Value: 3<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
CreateNode<br>
1.&nbsp;&nbsp;&nbsp;&nbsp;Open the specified client configuration file as a Configuration object.<br>
&nbsp; &nbsp;To get the Configuration object that applies to all users, set userLevel to None.<br>
&nbsp;&nbsp;&nbsp;&nbsp;private static Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);<br>
2.&nbsp;&nbsp;&nbsp;&nbsp;Add an Application Setting.<br>
&nbsp;&nbsp;&nbsp;&nbsp;config.AppSettings.Settings.Add(key, value);<br>
3.&nbsp;&nbsp;&nbsp;&nbsp;Write the configuration settings contained within this Configuration object
<br>
&nbsp; &nbsp;to the current XML configuration file, even if the configuration was not modified.<br>
&nbsp;&nbsp;&nbsp;&nbsp;config.Save(ConfigurationSaveMode.Modified, true);<br>
4.&nbsp;&nbsp;&nbsp;&nbsp;Refresh the named section so the next time that it is retrieved it
<br>
&nbsp;&nbsp;&nbsp;&nbsp;will be re-read from disk.<br>
&nbsp;&nbsp;&nbsp;&nbsp;ConfigurationManager.RefreshSection(&quot;appSettings&quot;);<br>
<br>
ReadNode<br>
1.&nbsp;&nbsp;&nbsp;&nbsp;Open the specified client configuration file as a Configuration object.<br>
&nbsp; &nbsp;To get the Configuration object that applies to all users, set userLevel to None.<br>
&nbsp;&nbsp;&nbsp;&nbsp;private static Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);<br>
2.&nbsp;&nbsp;&nbsp;&nbsp;Enumerate settings information in configuration file.<br>
&nbsp;&nbsp;&nbsp;&nbsp;foreach (KeyValueConfigurationElement keyValuecfg in config.AppSettings.Settings)<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;Console.WriteLine(String.Format(&quot;Key: {0}, Value: {1}&quot;, keyValuecfg.Key, keyValuecfg.Value));<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
UpdateNode<br>
1.&nbsp;&nbsp;&nbsp;&nbsp;Because of there're some settings are read-only or cannot be modified successfully at runtime,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;in order to modify the current application settings value, we must use the XmlDocument
<br>
&nbsp;&nbsp;&nbsp;&nbsp;class to directly update the application configuration file as an XML document.<br>
2.&nbsp;&nbsp;&nbsp;&nbsp;Load the application configuration file.<br>
&nbsp;&nbsp;&nbsp;&nbsp;xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);<br>
3.&nbsp;&nbsp;&nbsp;&nbsp;Enumerate nodes in configuration file.<br>
4.&nbsp;&nbsp;&nbsp;&nbsp;Update the node value.<br>
&nbsp;&nbsp;&nbsp;&nbsp;foreach (XmlElement element in xmlDoc.DocumentElement)<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;if (element.Name.Equals(&quot;appSettings&quot;))<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;foreach (XmlNode node in element.ChildNodes)<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (node.Attributes[0].Value.Equals(key))<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Update the node value.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;node.Attributes[1].Value = value;<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
5.&nbsp;&nbsp;&nbsp;&nbsp;Save the XML document to the specified file.<br>
&nbsp;&nbsp;&nbsp;&nbsp;xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);<br>
6.&nbsp;&nbsp;&nbsp;&nbsp;Refresh the named section so the next time that it is retrieved it
<br>
&nbsp;&nbsp;&nbsp;&nbsp;will be re-read from disk.<br>
&nbsp;&nbsp;&nbsp;&nbsp;ConfigurationManager.RefreshSection(&quot;appSettings&quot;);<br>
<br>
DeleteNode<br>
1.&nbsp;&nbsp;&nbsp;&nbsp;Open the specified client configuration file as a Configuration object.<br>
&nbsp;&nbsp;&nbsp;&nbsp;To get the Configuration object that applies to all users, set userLevel to None.<br>
2.&nbsp;&nbsp;&nbsp;&nbsp;Delete node by key.<br>
&nbsp;&nbsp;&nbsp;&nbsp;config.AppSettings.Settings.Remove(key);<br>
3.&nbsp;&nbsp;&nbsp;&nbsp;Write the configuration settings contained within this Configuration object
<br>
&nbsp; &nbsp;to the current XML configuration file, even if the configuration was not modified.<br>
&nbsp;&nbsp;&nbsp;&nbsp;config.Save(ConfigurationSaveMode.Modified, true);<br>
4.&nbsp;&nbsp;&nbsp;&nbsp;Refresh the named section so the next time that it is retrieved it
<br>
&nbsp;&nbsp;&nbsp;&nbsp;will be re-read from disk.<br>
&nbsp;&nbsp;&nbsp;&nbsp;ConfigurationManager.RefreshSection(&quot;appSettings&quot;);<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
ConfigurationManager Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.configuration.configurationmanager.aspx">http://msdn.microsoft.com/en-us/library/system.configuration.configurationmanager.aspx</a><br>
<br>
ConfigurationManager.OpenExeConfiguration Method (ConfigurationUserLevel)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms134265.aspx">http://msdn.microsoft.com/en-us/library/ms134265.aspx</a><br>
<br>
Configuration.Save Method (ConfigurationSaveMode, Boolean)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms134089.aspx">http://msdn.microsoft.com/en-us/library/ms134089.aspx</a><br>
<br>
ConfigurationManager.RefreshSection Method<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.configuration.configurationmanager.refreshsection.aspx">http://msdn.microsoft.com/en-us/library/system.configuration.configurationmanager.refreshsection.aspx</a><br>
<br>
XmlDocument Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.xml.xmldocument.aspx">http://msdn.microsoft.com/en-us/library/system.xml.xmldocument.aspx</a><br>
<br>
AppDomain Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.appdomain.aspx">http://msdn.microsoft.com/en-us/library/system.appdomain.aspx</a><br>
<br>
How to Make Your .NET Windows Forms Configuration Files Dynamic<br>
<a target="_blank" href="http://www.devx.com/dotnet/Article/11616/1954">http://www.devx.com/dotnet/Article/11616/1954</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
