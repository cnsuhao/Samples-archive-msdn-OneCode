# Save a collection to Application Storage
## Requires
* Visual Studio 2012
## License
* MS-LPL
## Technologies
* Windows 8
## Topics
* XmlSerializer
* Store List/Collection
* DataContractSeriaizer
## IsPublished
* True
## ModifiedDate
* 2015-02-08 10:37:00
## Description

<p><span><a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144425" target="_blank"><img id="79968" src="http://i1.code.msdn.s-msft.com/cswindowsstoreappadditem-a5d7fbcc/image/file/79968/1/dpe_w8_728x90_1022_v2.jpg" alt="" width="728" height="90" style="width:100%"></a></span></p>
<h1>How to save a collection of custom objects to local storage (<span>VB</span>WindowsStoreAppSaveCollection)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to save a collection of custom objects to local storage.</p>
<h2 class="MsoNormal">Video</h2>
<p><a href="http://channel9.msdn.com/Blogs/OneCode/How-to-save-a-collection-of-objects-to-application-storage-in-Windows-Store-apps" target="_blank"><img id="133568" src="https://i1.code.msdn.s-msft.com/cswinstoreappsavecollection-bed5d6e6/image/file/133568/1/how%20to%20save%20a%20data%20collection%20to%20app%20storage%20in%20windows%20store%20apps%20%20%20channel%209.png" alt="" width="640" height="360" style="border:1px solid black"></a></p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst"><span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press F5 to run the application</p>
<p class="MsoListParagraphCxSpMiddle"><span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>This page will display on your screen.</p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/73752/1/image.png" alt="" width="623" height="499" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Please fill the information and click Add button to add sample data.</p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/73753/1/image.png" alt="" width="623" height="499" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span><span>4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>After inserting some data, please click Go button to leave this page, and this page will display on your screen. Now, the collection has already been saved to the local storage.</p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/73754/1/image.png" alt="" width="623" height="499" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span><span>5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Please click Back button to back to the previous page, it will load the data which we have saved.</p>
<p class="MsoListParagraphCxSpLast"><span><span>6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>We can also press &quot;Alt&#43;F4&quot; to terminate the application and run it again later, the data will also be loaded.</p>
<h2>Using the Code</h2>
<p class="MsoNormal"><span>&lt;o:p&gt;&nbsp;Serialize objects to xml string.&lt;/o:p&gt;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">'Serialize to xml
&nbsp;&nbsp;&nbsp; Public Shared Function ToXml(value As T) As String
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim serializer As New XmlSerializer(GetType(T))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim stringBuilder As New StringBuilder()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim settings As New XmlWriterSettings()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; settings.Indent = True
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; settings.OmitXmlDeclaration = True


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using xmlWriter__1 As XmlWriter = XmlWriter.Create(stringBuilder, settings)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; serializer.Serialize(xmlWriter__1, value)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return stringBuilder.ToString()
&nbsp;&nbsp;&nbsp; End Function

</pre>
<pre id="codePreview" class="vb">'Serialize to xml
&nbsp;&nbsp;&nbsp; Public Shared Function ToXml(value As T) As String
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim serializer As New XmlSerializer(GetType(T))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim stringBuilder As New StringBuilder()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim settings As New XmlWriterSettings()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; settings.Indent = True
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; settings.OmitXmlDeclaration = True


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using xmlWriter__1 As XmlWriter = XmlWriter.Create(stringBuilder, settings)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; serializer.Serialize(xmlWriter__1, value)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return stringBuilder.ToString()
&nbsp;&nbsp;&nbsp; End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&lt;o:p&gt;&nbsp;Deserialize objects from xml string.&lt;/o:p&gt;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">'Deserialize from xml
&nbsp; Public Shared Function FromXml(xml As String) As T
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim serializer As New XmlSerializer(GetType(T))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim value As T
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using stringReader As New StringReader(xml)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim deserialized As Object = serializer.Deserialize(stringReader)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; value = DirectCast(deserialized, T)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return value
&nbsp; End Function
End Class

</pre>
<pre id="codePreview" class="vb">'Deserialize from xml
&nbsp; Public Shared Function FromXml(xml As String) As T
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim serializer As New XmlSerializer(GetType(T))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim value As T
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using stringReader As New StringReader(xml)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim deserialized As Object = serializer.Deserialize(stringReader)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; value = DirectCast(deserialized, T)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return value
&nbsp; End Function
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&lt;o:p&gt;&nbsp;Save data to local storage.&lt;/o:p&gt;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Protected Overrides Async Sub SaveState(pageState As Dictionary(Of String, Object))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim localData As String = ObjectSerializer(Of ObservableCollection(Of Person)).ToXml(itemCollection)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Not String.IsNullOrEmpty(localData) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim localFile As StorageFile = Await ApplicationData.Current.LocalFolder.CreateFileAsync(&quot;localData.xml&quot;, CreationCollisionOption.ReplaceExisting)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Await FileIO.WriteTextAsync(localFile, localData)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Catch ex As Exception
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NotifyUser(ex.ToString())
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Try


&nbsp;&nbsp;&nbsp; End Sub

</pre>
<pre id="codePreview" class="vb">Protected Overrides Async Sub SaveState(pageState As Dictionary(Of String, Object))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim localData As String = ObjectSerializer(Of ObservableCollection(Of Person)).ToXml(itemCollection)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Not String.IsNullOrEmpty(localData) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim localFile As StorageFile = Await ApplicationData.Current.LocalFolder.CreateFileAsync(&quot;localData.xml&quot;, CreationCollisionOption.ReplaceExisting)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Await FileIO.WriteTextAsync(localFile, localData)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Catch ex As Exception
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NotifyUser(ex.ToString())
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Try


&nbsp;&nbsp;&nbsp; End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&lt;o:p&gt;&nbsp;Load data from local storage.&lt;/o:p&gt;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Protected Overrides Async Sub LoadState(navigationParameter As Object, pageState As Dictionary(Of String, Object))
&nbsp;&nbsp;&nbsp; Dim localFile As StorageFile
&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; localFile = Await ApplicationData.Current.LocalFolder.GetFileAsync(&quot;localData.xml&quot;)
&nbsp;&nbsp;&nbsp; Catch ex As FileNotFoundException
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; localFile = Nothing
&nbsp;&nbsp;&nbsp; End Try
&nbsp;&nbsp;&nbsp; If localFile IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim localData As String = Await FileIO.ReadTextAsync(localFile)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; itemCollection = ObjectSerializer(Of ObservableCollection(Of Person)).FromXml(localData)
&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; gvData.ItemsSource = itemCollection
End Sub

</pre>
<pre id="codePreview" class="vb">Protected Overrides Async Sub LoadState(navigationParameter As Object, pageState As Dictionary(Of String, Object))
&nbsp;&nbsp;&nbsp; Dim localFile As StorageFile
&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; localFile = Await ApplicationData.Current.LocalFolder.GetFileAsync(&quot;localData.xml&quot;)
&nbsp;&nbsp;&nbsp; Catch ex As FileNotFoundException
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; localFile = Nothing
&nbsp;&nbsp;&nbsp; End Try
&nbsp;&nbsp;&nbsp; If localFile IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim localData As String = Await FileIO.ReadTextAsync(localFile)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; itemCollection = ObjectSerializer(Of ObservableCollection(Of Person)).FromXml(localData)
&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; gvData.ItemsSource = itemCollection
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&nbsp;</p>
<h2>More Information</h2>
<p class="MsoNormal">ApplicationData.LocalFolder | localFolder property (Windows)</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.applicationdata.localfolder">http://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.applicationdata.localfolder</a></p>
<p class="MsoNormal">Quickstart: Local application data (Windows Store apps using C#/VB/C&#43;&#43; and XAML) (Windows)</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh700361">http://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh700361</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
