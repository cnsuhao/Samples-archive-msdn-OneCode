# Load all Toolbox items in an Assembly in VSPackage (VBVSPackageToolbox)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* VSX
## Topics
* VSPackage
* Load Visual Studio ToolboxItems
## IsPublished
* True
## ModifiedDate
* 2012-03-01 11:46:40
## Description

<h1>Load all Toolbox items in an Assembly in VSPackage (<span class="SpellE"><span style="">VB</span>VSPackageToolbox</span>)</h1>
<h2>Introduction</h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">VSPackages are software modules that make up and extend the Visual Studio integrated development environment (IDE) by providing UI elements, services,
 projects, editors, and designers. VSPackages are the principal architectural unit of Visual Studio, and are the unit of deployment, licensing, and security also. Visual Studio itself is written mostly as a collection of VSPackages.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">This sample demonstrates how to use the Visual Studio Integration Package Wizard to create a simple VSPackage and automatically load all the
<span class="SpellE">ToolboxItem</span> items provided by its own assembly.</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">
</span></h2>
<h2>Building the Sample</h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">VS 20</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">08</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">
 SP1 SDK must be installed on the machine. You can download it from: </span></h2>
<p class="MsoNormal"><span lang="EN" style=""><a href="http://www.microsoft.com/download/en/details.aspx?id=21827">Visual Studio 2008 SDK 1.1</a></span><span lang="EN" style="">
</span></p>
<p class="MsoNormal"><span lang="EN" style="">The Package Load Failure Dialog occurs because there is no PLK (Package Load Key) specified in this package. To obtain a PLK, please to go to Website:
<a href="http://msdn.microsoft.com/en-us/vstudio/cc655795">Generate Load Keys</a>. More info:
<a href="http://msdn.microsoft.com/en-us/library/bb165395.aspx">How to: Obtain a PLK for a VSPackage</a>
</span></p>
<p class="MsoNormal">Set the Start Action and Start Options of Debug.</p>
<p class="MsoNormal">Start Action: <u>C:\Program Files\Microsoft Visual Studio </u>
<u><span style="">9</span>.0\Common7\IDE\devenv.exe</u> (32bit OS) or <u>C:\Program Files (x86)\Microsoft Visual Studio
</u><u><span style="">9</span>.0\Common7\IDE\devenv.exe</u> (64bit OS)<u> </u></p>
<p class="MsoNormal">Start Option: <u>/<span class="SpellE">ranu</span> /<span class="SpellE">rootsuffix</span>
<span class="SpellE">Exp</span></u></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53262/1/image.png" alt="" width="576" height="404" align="middle">
</span></p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press <b style="">F5</b> to debug this project.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>In the new instance of Visual Studio, <span style="">create a new Windows Forms Application.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Open the designer of the Form1<span class="GramE">,<span style="">&nbsp;
</span>you</span> will find the Tab <span class="SpellE"><b style="">LoadToolboxMemberDemo</b></span><b style="">
</b>and<b style=""> </b>Item<b style=""> <span class="SpellE">ToolboxMemberDemo</span></b> in
<span class="SpellE">ToolBox</span>.</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">You can drag the Item<b style="">
<span class="SpellE">ToolboxMemberDemo</span></b>, and drop it<b style=""> </b>
to the UI of<b style=""> </b>Form1.</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/53263/1/image.png" alt="" width="780" height="302" align="middle">
</span></p>
<p class="MsoListParagraphCxSpLast"></p>
<h2>Using the Code</h2>
<p class="MsoListParagraphCxSpFirst" style=""><b style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style="">Create a VS Package Project. </b></p>
<p class="MsoListParagraphCxSpMiddle">Use Visual Studio Integration Package Wizard to create a simple VSPackage project. You can follow the steps in
<a href="http://msdn.microsoft.com/en-us/library/cc138589.aspx">Walkthrough: Creating a VSPackage
</a><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><b style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style=""><span style="">Creating a Toolbox Control</span>.
</b></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">a.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Right-Click the Project and select &quot;Add&quot;-&gt; &quot;Add new Item&quot;, then select
<span class="SpellE"><b style="">UserControl</b></span>, type name &quot;<span class="SpellE"><b style="">MyControl</b></span>&quot;</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style=""><span style="">b.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>In the <span class="SpellE"><b style="">UserControl</b></span> designer, add a
<span class="SpellE"><b style="">TextBox</b></span> and a <span class="GramE">
<b style="">Button</b>,</span> double-click the Button, add the click event handler.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
    Dim opg As New OpenFileDialog()
    opg.Multiselect = False
    If opg.ShowDialog() = DialogResult.OK Then
        Me.tbFileName.Text = opg.FileName
    End If
End Sub

</pre>
<pre id="codePreview" class="vb">
Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
    Dim opg As New OpenFileDialog()
    opg.Multiselect = False
    If opg.ShowDialog() = DialogResult.OK Then
        Me.tbFileName.Text = opg.FileName
    End If
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">c.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Add attributes to the file to enable the VSPackage to query the supplied
<span class="SpellE">ToolboxItem</span> class.</span></p>
<p class="MsoListParagraphCxSpLast"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;DisplayName(&quot;ToolboxMemberDemo&quot;), _
Description(&quot;Custom toolbox item from package LoadToolboxMembers.&quot;), _
ToolboxItem(True), _
ToolboxBitmap(GetType(MyControl), &quot;MyControl.bmp&quot;)&gt; _
Public Class MyControl


��
End Class

</pre>
<pre id="codePreview" class="vb">
&lt;DisplayName(&quot;ToolboxMemberDemo&quot;), _
Description(&quot;Custom toolbox item from package LoadToolboxMembers.&quot;), _
ToolboxItem(True), _
ToolboxBitmap(GetType(MyControl), &quot;MyControl.bmp&quot;)&gt; _
Public Class MyControl


��
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">d.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Right-Click the Project and select &quot;Add&quot;-&gt; &quot;Add new Item&quot;, then select<span style="">&nbsp;
</span><b style="">Bitmap</b> add a 16*16 bitmap with the name MyControl.bmp</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"></p>
<p class="MsoListParagraphCxSpMiddle" style=""><b style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style=""><span style="">Modifying the VSPackage Implementation</span>.
</b></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style=""><span style="">a.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Register the VSPackage as a <span class="SpellE">ToolboxItem</span> class by adding an instance of
<span class="SpellE"><b style="">ProvideToolboxItemsAttribute</b></span><span style="">.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;ProvideToolboxItems(1)&gt; _
Public NotInheritable Class VBVSToolboxPackage
    Inherits Package

</pre>
<pre id="codePreview" class="vb">
&lt;ProvideToolboxItems(1)&gt; _
Public NotInheritable Class VBVSToolboxPackage
    Inherits Package

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style=""><span style="">b.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Add the following two new private fields to the <span class="SpellE">
<span style="">VB</span>VSToolboxPackage</span> class<span style="">.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' List for the toolbox items provided by this package.
Private ToolboxItemList As ArrayList


' Name for the Toolbox category tab for the package's toolbox items.
Private CategoryTab As String = &quot;LoadToolboxMemberDemo&quot;

</pre>
<pre id="codePreview" class="vb">
' List for the toolbox items provided by this package.
Private ToolboxItemList As ArrayList


' Name for the Toolbox category tab for the package's toolbox items.
Private CategoryTab As String = &quot;LoadToolboxMemberDemo&quot;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst"></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style=""><span style="">c.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Modify the Initialize method in <span class="SpellE"><span style="">VB</span>VSToolboxPackage</span> to do the following<span style="">&nbsp;
</span>things:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Add our command handlers for menu (commands must exist in the .vsct file)
Dim mcs As OleMenuCommandService = TryCast(GetService(GetType(IMenuCommandService)), OleMenuCommandService)
If Nothing IsNot mcs Then
    ' Create the command for the menu item.
    Dim menuCommandID As New CommandID(GuidList.guidVBVSToolboxCmdSet, CInt(Fix(PkgCmdIDList.cmdidInitializeToolbox)))
    Dim menuItem As New MenuCommand(MenuItemCallback, menuCommandID)
    mcs.AddCommand(menuItem)


    ' Subscribe to the toolbox intitialized and upgraded events.
    AddHandler ToolboxInitialized, AddressOf OnRefreshToolbox
    AddHandler ToolboxUpgraded, AddressOf OnRefreshToolbox
End If


' Use reflection to get the toolbox items provided in this assembly.
ToolboxItemList = CreateItemList(Me.GetType().Assembly)
If Nothing Is ToolboxItemList Then
    ' Unable to generate the list.
    ' Add error handling code here.
End If

</pre>
<pre id="codePreview" class="vb">
' Add our command handlers for menu (commands must exist in the .vsct file)
Dim mcs As OleMenuCommandService = TryCast(GetService(GetType(IMenuCommandService)), OleMenuCommandService)
If Nothing IsNot mcs Then
    ' Create the command for the menu item.
    Dim menuCommandID As New CommandID(GuidList.guidVBVSToolboxCmdSet, CInt(Fix(PkgCmdIDList.cmdidInitializeToolbox)))
    Dim menuItem As New MenuCommand(MenuItemCallback, menuCommandID)
    mcs.AddCommand(menuItem)


    ' Subscribe to the toolbox intitialized and upgraded events.
    AddHandler ToolboxInitialized, AddressOf OnRefreshToolbox
    AddHandler ToolboxUpgraded, AddressOf OnRefreshToolbox
End If


' Use reflection to get the toolbox items provided in this assembly.
ToolboxItemList = CreateItemList(Me.GetType().Assembly)
If Nothing Is ToolboxItemList Then
    ' Unable to generate the list.
    ' Add error handling code here.
End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style=""><span style="">d.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Add two methods, <span class="SpellE"><b style="">CreateItemList</b></span> and
<span class="SpellE"><b style="">CreateToolboxItem</b></span>, to construct, by using metadata, instances of the
<span class="SpellE">ToolboxItem</span> objects that are available in the <span class="SpellE">
<span style="">VBVSPackageToolbox</span></span><span style=""> </span>assembly, as follows:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Scan for toolbox items in the assembly and return the list of
' toolbox items.
Private Function CreateItemList(ByVal [assembly] As System.Reflection.Assembly) As ArrayList
    Dim list As New ArrayList()
    For Each possibleItem As Type In [assembly].GetTypes()
        Dim item As ToolboxItem = CreateToolboxItem(possibleItem)
        If item IsNot Nothing Then
            list.Add(item)
        End If
    Next possibleItem
    Return list
End Function


' If the type represents a toolbox item, return an instance of the type;
' otherwise, return null.
Private Function CreateToolboxItem(ByVal possibleItem As Type) As ToolboxItem
    ' A toolbox item must implement IComponent and must not be abstract.
    If (Not GetType(IComponent).IsAssignableFrom(possibleItem)) OrElse possibleItem.IsAbstract Then
        Return Nothing
    End If


    ' A toolbox item must have a constructor that takes a parameter of
    ' type Type or a constructor that takes no parameters.
    If Nothing Is possibleItem.GetConstructor(New Type() { GetType(Type) }) AndAlso Nothing Is possibleItem.GetConstructor(New Type(){}) Then
        Return Nothing
    End If


    Dim item As ToolboxItem = Nothing


    ' Check the custom attributes of the candidate type and attempt to
    ' create an instance of the toolbox item type.
    Dim attribs As AttributeCollection = TypeDescriptor.GetAttributes(possibleItem)
    Dim tba As ToolboxItemAttribute = TryCast(attribs(GetType(ToolboxItemAttribute)), ToolboxItemAttribute)
    If tba IsNot Nothing AndAlso (Not tba.Equals(ToolboxItemAttribute.None)) Then
        If Not tba.IsDefaultAttribute() Then
            ' This type represents a custom toolbox item implementation.
            Dim itemType As Type = tba.ToolboxItemType
            Dim ctor As ConstructorInfo = itemType.GetConstructor(New Type() { GetType(Type) })
            If ctor IsNot Nothing AndAlso itemType IsNot Nothing Then
                item = CType(ctor.Invoke(New Object() { possibleItem }), ToolboxItem)
            Else
                ctor = itemType.GetConstructor(New Type(){})
                If ctor IsNot Nothing Then
                    item = CType(ctor.Invoke(New Object(){}), ToolboxItem)
                    item.Initialize(possibleItem)
                End If
            End If
        Else
            ' This type represents a default toolbox item.
            item = New ToolboxItem(possibleItem)
        End If
    End If
    If item Is Nothing Then
        Throw New ApplicationException(&quot;Unable to create a ToolboxItem &quot; & &quot;object from &quot; & possibleItem.FullName & &quot;.&quot;)
    End If


    ' Update the display name of the toolbox item and add the item to
    ' the list.
    Dim displayName As DisplayNameAttribute = TryCast(attribs(GetType(DisplayNameAttribute)), DisplayNameAttribute)
    If displayName IsNot Nothing AndAlso (Not displayName.IsDefaultAttribute()) Then
        item.DisplayName = displayName.DisplayName
    End If


    Return item
End Function

</pre>
<pre id="codePreview" class="vb">
' Scan for toolbox items in the assembly and return the list of
' toolbox items.
Private Function CreateItemList(ByVal [assembly] As System.Reflection.Assembly) As ArrayList
    Dim list As New ArrayList()
    For Each possibleItem As Type In [assembly].GetTypes()
        Dim item As ToolboxItem = CreateToolboxItem(possibleItem)
        If item IsNot Nothing Then
            list.Add(item)
        End If
    Next possibleItem
    Return list
End Function


' If the type represents a toolbox item, return an instance of the type;
' otherwise, return null.
Private Function CreateToolboxItem(ByVal possibleItem As Type) As ToolboxItem
    ' A toolbox item must implement IComponent and must not be abstract.
    If (Not GetType(IComponent).IsAssignableFrom(possibleItem)) OrElse possibleItem.IsAbstract Then
        Return Nothing
    End If


    ' A toolbox item must have a constructor that takes a parameter of
    ' type Type or a constructor that takes no parameters.
    If Nothing Is possibleItem.GetConstructor(New Type() { GetType(Type) }) AndAlso Nothing Is possibleItem.GetConstructor(New Type(){}) Then
        Return Nothing
    End If


    Dim item As ToolboxItem = Nothing


    ' Check the custom attributes of the candidate type and attempt to
    ' create an instance of the toolbox item type.
    Dim attribs As AttributeCollection = TypeDescriptor.GetAttributes(possibleItem)
    Dim tba As ToolboxItemAttribute = TryCast(attribs(GetType(ToolboxItemAttribute)), ToolboxItemAttribute)
    If tba IsNot Nothing AndAlso (Not tba.Equals(ToolboxItemAttribute.None)) Then
        If Not tba.IsDefaultAttribute() Then
            ' This type represents a custom toolbox item implementation.
            Dim itemType As Type = tba.ToolboxItemType
            Dim ctor As ConstructorInfo = itemType.GetConstructor(New Type() { GetType(Type) })
            If ctor IsNot Nothing AndAlso itemType IsNot Nothing Then
                item = CType(ctor.Invoke(New Object() { possibleItem }), ToolboxItem)
            Else
                ctor = itemType.GetConstructor(New Type(){})
                If ctor IsNot Nothing Then
                    item = CType(ctor.Invoke(New Object(){}), ToolboxItem)
                    item.Initialize(possibleItem)
                End If
            End If
        Else
            ' This type represents a default toolbox item.
            item = New ToolboxItem(possibleItem)
        End If
    End If
    If item Is Nothing Then
        Throw New ApplicationException(&quot;Unable to create a ToolboxItem &quot; & &quot;object from &quot; & possibleItem.FullName & &quot;.&quot;)
    End If


    ' Update the display name of the toolbox item and add the item to
    ' the list.
    Dim displayName As DisplayNameAttribute = TryCast(attribs(GetType(DisplayNameAttribute)), DisplayNameAttribute)
    If displayName IsNot Nothing AndAlso (Not displayName.IsDefaultAttribute()) Then
        item.DisplayName = displayName.DisplayName
    End If


    Return item
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style=""><span style="">e.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Implement the <span class="SpellE"><b style="">OnRefreshToolbox</b></span> method to handle the
<span class="SpellE"><b style="">ToolboxInitialized</b></span> and <span class="SpellE">
<b style="">ToolboxUpgraded</b></span> events.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Sub OnRefreshToolbox(ByVal sender As Object, ByVal e As EventArgs)
    ' Add new instances of all ToolboxItems contained in ToolboxItemList.
    Dim service As IToolboxService = TryCast(GetService(GetType(IToolboxService)), IToolboxService)
    Dim toolbox As IVsToolbox = TryCast(GetService(GetType(IVsToolbox)), IVsToolbox)


    'Remove target tab and all controls under it.
    For Each oldItem As ToolboxItem In service.GetToolboxItems(CategoryTab)
        service.RemoveToolboxItem(oldItem)
    Next oldItem
    toolbox.RemoveTab(CategoryTab)


    For Each itemFromList As ToolboxItem In ToolboxItemList
        service.AddToolboxItem(itemFromList, CategoryTab)
    Next itemFromList
    service.SelectedCategory = CategoryTab


    service.Refresh()
End Sub

</pre>
<pre id="codePreview" class="vb">
Private Sub OnRefreshToolbox(ByVal sender As Object, ByVal e As EventArgs)
    ' Add new instances of all ToolboxItems contained in ToolboxItemList.
    Dim service As IToolboxService = TryCast(GetService(GetType(IToolboxService)), IToolboxService)
    Dim toolbox As IVsToolbox = TryCast(GetService(GetType(IVsToolbox)), IVsToolbox)


    'Remove target tab and all controls under it.
    For Each oldItem As ToolboxItem In service.GetToolboxItems(CategoryTab)
        service.RemoveToolboxItem(oldItem)
    Next oldItem
    toolbox.RemoveTab(CategoryTab)


    For Each itemFromList As ToolboxItem In ToolboxItemList
        service.AddToolboxItem(itemFromList, CategoryTab)
    Next itemFromList
    service.SelectedCategory = CategoryTab


    service.Refresh()
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style=""><span style="">f.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Change the menu item command handler method, <span class="SpellE">
MenuItemCallBack</span>, as follows.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Sub MenuItemCallback(ByVal sender As Object, ByVal e As EventArgs)
    Dim pkg As IVsPackage = TryCast(GetService(GetType(Package)), Package)
    pkg.ResetDefaults(CUInt(__VSPKGRESETFLAGS.PKGRF_TOOLBOXITEMS))
End Sub

</pre>
<pre id="codePreview" class="vb">
Private Sub MenuItemCallback(ByVal sender As Object, ByVal e As EventArgs)
    Dim pkg As IVsPackage = TryCast(GetService(GetType(Package)), Package)
    pkg.ResetDefaults(CUInt(__VSPKGRESETFLAGS.PKGRF_TOOLBOXITEMS))
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:72.0pt"></p>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/bb164725.aspx">How to: Create VSPackages (C# and Visual Basic)</a><span style="">
</span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/bb166544.aspx">How to: Register a VSPackage (C#)</a><span style="">
</span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/cc138589.aspx">VSPackage Tutorial 1: How to Create a VSPackage</a><span style="">
</span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/bb165325.aspx">Managing the Toolbox</a><span style="">
</span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/bb166364.aspx">Toolbox (Visual Studio SDK)</a><span style="">
</span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/bb166364.aspx">Walkthrough:
<span class="SpellE">Autoloading</span> Toolbox Items</a><span style=""> </span>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
