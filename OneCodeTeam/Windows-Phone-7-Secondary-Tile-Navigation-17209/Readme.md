# Windows Phone 7 Secondary Tile Navigation
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Windows Phone 7
* Windows Phone 7.5
## Topics
* Tiles
## IsPublished
* True
## ModifiedDate
* 2012-08-22 04:49:46
## Description

<h1>Windows Phone 7 Secondary Tile Navigation</h1>
<h2>Introduction</h2>
<p>There are two kinds of Tile in Windows phone application: Application Tile and Secondary Tile. Each application has one and only one Application for users to launch the application while it is supported to create multiple secondary tiles through users&rsquo;
 certain operation. In some situations, we want to detect from which secondary tile user are navigated to the application.</p>
<p>The following points are covered in this sample:</p>
<ul>
<li>How to create secondary tile </li><li>How to get detect from which secondary tile user are navigated to the application
</li></ul>
<h2>Building the Sample</h2>
<p>This sample needs be opened with Windows phone SDK 7.1 &#43;, please download from below link.</p>
<p><a href="http://www.microsoft.com/en-us/download/details.aspx?id=27570">Windows Phone SDK 7.1</a></p>
<h2>Running the Sample</h2>
<p>1. Open the CSWP7SecondaryTile.sln file with Visual Studio or Expression Blend.</p>
<p>2. Press Ctrl &#43; F5 to run the sample.</p>
<p>3. Click &ldquo;Create 1st Secondary Tile&rdquo; button on the application.</p>
<p>4. Back to the application and Click &ldquo;Create 2nd Secondary Tile&rdquo; button.</p>
<p>5. Click on Back button of Windows Phone Device/ Windows Phone Emulator</p>
<p>6. Click on the Tile with FirstTile text.</p>
<p>7. You will see the Text shown as &ldquo;Welcome back from FirstTile.&rdquo;</p>
<p>8. Click on the Tile with SecondTile text.</p>
<p>9. You will see the Text shown as &ldquo;Welcome back from SecondTile.&rdquo;</p>
<h2>Using the Code</h2>
<p>1. How to create a Secondary Tile</p>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">Private Sub button_Click(sender As Object, e As RoutedEventArgs)
    Dim tileParameter As String = &quot;Param=&quot; &#43; DirectCast(sender, Button).Name
    Dim tile As ShellTile = CheckIfTileExist(tileParameter)
    If tile Is Nothing Then
 
        Dim secondaryTile As New StandardTileData With {
         .Title = tileParameter,
         .BackgroundImage = New Uri(&quot;Background-Secondary.png&quot;, UriKind.Relative),
         .Count = 2,
         .BackContent = &quot;Secondary Tile Test&quot;
        }
        ShellTile.Create(New Uri(&quot;/MainPage.xaml?&quot; &amp; tileParameter, UriKind.Relative), secondaryTile) 'Create SecondaryTile and pass querystring to navigation url.
    End If
End Sub
 
Private Function CheckIfTileExist(tileUri As String) As ShellTile
    Dim shellTile__1 As ShellTile = ShellTile.ActiveTiles.FirstOrDefault(Function(tile) tile.NavigationUri.ToString().Contains(tileUri))
    Return shellTile__1
End Function
</pre>
<pre class="hidden">private void button_Click(object sender, RoutedEventArgs e)
{
    string tileParameter = &quot;Param=&quot; &#43; ((Button)sender).Name;//Use Button.Name to mark Tile
    ShellTile tile = CheckIfTileExist(tileParameter);// Check if Tile's title has been used
    if (tile == null)
    {
        StandardTileData secondaryTile = new StandardTileData
        {
            Title = tileParameter,
            BackgroundImage = new Uri(&quot;Background-Secondary.png&quot;, UriKind.Relative),
            Count = 2,
            BackContent = &quot;Secondary Tile Test&quot;
 
        };
        ShellTile.Create(new Uri(&quot;/MainPage.xaml?&quot; &#43; tileParameter, UriKind.Relative), secondaryTile); // Pass tileParameter as QueryString
    }
}
 
private ShellTile CheckIfTileExist(string tileUri)
{
    ShellTile shellTile = ShellTile.ActiveTiles.FirstOrDefault(
            tile =&gt; tile.NavigationUri.ToString().Contains(tileUri));
    return shellTile;
}</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;button_Click(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;RoutedEventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;tileParameter&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Param=&quot;</span>&nbsp;&#43;&nbsp;<span class="visualBasic__keyword">DirectCast</span>(sender,&nbsp;Button).Name&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;tile&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ShellTile&nbsp;=&nbsp;CheckIfTileExist(tileParameter)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;tile&nbsp;<span class="visualBasic__keyword">Is</span>&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;secondaryTile&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;StandardTileData&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Title&nbsp;=&nbsp;tileParameter,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.BackgroundImage&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Uri(<span class="visualBasic__string">&quot;Background-Secondary.png&quot;</span>,&nbsp;UriKind.Relative),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Count&nbsp;=&nbsp;<span class="visualBasic__number">2</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.BackContent&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Secondary&nbsp;Tile&nbsp;Test&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShellTile.Create(<span class="visualBasic__keyword">New</span>&nbsp;Uri(<span class="visualBasic__string">&quot;/MainPage.xaml?&quot;</span>&nbsp;&amp;&nbsp;tileParameter,&nbsp;UriKind.Relative),&nbsp;secondaryTile)&nbsp;<span class="visualBasic__com">'Create&nbsp;SecondaryTile&nbsp;and&nbsp;pass&nbsp;querystring&nbsp;to&nbsp;navigation&nbsp;url.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;CheckIfTileExist(tileUri&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ShellTile&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;shellTile__1&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ShellTile&nbsp;=&nbsp;ShellTile.ActiveTiles.FirstOrDefault(<span class="visualBasic__keyword">Function</span>(tile)&nbsp;tile.NavigationUri.ToString().Contains(tileUri))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;shellTile__1&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
&nbsp;</div>
<p>2. Detect from which secondary tile user are navigated to the application by overriding OnNavigatedTo method</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">Protected Overrides Sub OnNavigatedTo(e As System.Windows.Navigation.NavigationEventArgs)
    MyBase.OnNavigatedTo(e)
    If Me.NavigationContext.QueryString.ContainsKey(&quot;Param&quot;) Then
        Dim param As String = Me.NavigationContext.QueryString(&quot;Param&quot;)'Get &quot;Param&quot; this query string.
        textBlock1.Text = &quot;Welcome back from &quot; &amp; param
    End If
End Sub
</pre>
<pre class="hidden">protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
{
    base.OnNavigatedTo(e);
    if (this.NavigationContext.QueryString.ContainsKey(&quot;Param&quot;))
    {
        string param = this.NavigationContext.QueryString[&quot;Param&quot;];//Get &quot;Param&quot; this QueryString.
        textBlock1.Text = &quot;Welcome back from &quot; &#43; param;
    }
}</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;OnNavigatedTo(e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.Windows.Navigation.NavigationEventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.OnNavigatedTo(e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Me</span>.NavigationContext.QueryString.ContainsKey(<span class="visualBasic__string">&quot;Param&quot;</span>)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;param&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.NavigationContext.QueryString(<span class="visualBasic__string">&quot;Param&quot;</span>)<span class="visualBasic__com">'Get&nbsp;&quot;Param&quot;&nbsp;this&nbsp;query&nbsp;string.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBlock1.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Welcome&nbsp;back&nbsp;from&nbsp;&quot;</span>&nbsp;&amp;&nbsp;param&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p><a href="http://msdn.microsoft.com/en-us/library/hh202948(v=vs.92).aspx">Tiles Overview for Windows Phone</a></p>
<p><br>
<br>
<br>
</p>
<div></div>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
