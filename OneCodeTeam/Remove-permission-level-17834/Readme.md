# Remove permission level (VBSharePointRemovePermissionLevel)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* SharePoint
## Topics
* SharePoint
* Permission
## IsPublished
* True
## ModifiedDate
* 2012-07-22 07:37:55
## Description

<h1><span style="">Remove specific permission level from group </span>(<span class="SpellE"><span class="GramE"><span style="">VBSharePointRemovePermissionLevel</span></span></span><span class="GramE"><span style="">
</span>)</span></h1>
<h2>Introduction </h2>
<p class="MsoNormal" style=""><span style="">This sample code demonstrates how to programmatically remove specific permission level from group in SharePoint 2010. Generally, we can remove a specific permission level by removing the group's role assignments
 from the target web, list, or item.<span style="">&nbsp; </span>Also, this sample shows you how to assign specific permission level to the group.<span style="">&nbsp;
</span></span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow the steps below. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Open the VBSharePointRemovePermissionLevel.sln file. </span>
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Open the <span class="SpellE">Program.vb</span> file to modify the Site URL and the Group Title. The Site URL is the URL of SharePoint Site which you want to connect. After that you can press &quot;Ctrl&#43;F5&quot; to run the sample.<br>
The permission level of my custom group as shown below: </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/61949/1/image.png" alt="" width="528" height="193" align="middle">
</span><span style=""><br>
After removing the &quot;Contribute&quot; permission level, the permission level of my custom group as shown below:<br>
<span style=""><img src="/site/view/file/61950/1/image.png" alt="" width="568" height="209" align="middle">
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 3: Validation is completed. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Create a </span><span style="">VB</span><span style=""> &quot;Console Application&quot; in Visual Studio 2010 and named it as &quot;VBSharePointRemovePermissionLevel&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal"><span style="">Step 2:<span style="">&nbsp; </span>Add the following assembly reference:<br>
<span style="">&nbsp;</span><span style="color:black">Project-&gt; References -&gt;…</span></span>
<span style="color:black">Microsoft.</span><span style="">SharePoint.dll </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 3: Add the following namespace in <span class="SpellE">Program.vb</span>.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Imports Microsoft.SharePoint

</pre>
<pre id="codePreview" class="vb">
Imports Microsoft.SharePoint

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 4: Specify the URL and group.<br style="">
<br style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Connect to Sharepoint Site
       Dim siteUrl As String = &quot;http://win-2ed380lbo8e/&quot;
       ' group Title
       Dim groupTitle As String = &quot;test123&quot;

</pre>
<pre id="codePreview" class="vb">
' Connect to Sharepoint Site
       Dim siteUrl As String = &quot;http://win-2ed380lbo8e/&quot;
       ' group Title
       Dim groupTitle As String = &quot;test123&quot;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 5: Remove the specific permission level from group. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Shared Sub SetPermissionsToGroup(ByVal siteUrl As String, ByVal groupTitle As String)


        Using site = New SPSite(siteUrl)
            'Connect to Sharepoint Site
            Using web = site.OpenWeb()
                'Get group and group roles 
                Dim group = web.SiteGroups(groupTitle)
                Dim roles = web.RoleAssignments.GetAssignmentByPrincipal(group)


                'Get the SPRoleDefinition
                Dim sprd As SPRoleDefinition = web.RoleDefinitions.GetByType(SPRoleType.Contributor)
                'Remove the SPRoleDefinition
                roles.RoleDefinitionBindings.Remove(sprd)
                'Updates the Role Assignment
                roles.Update()
…
            End Using
        End Using


    End Sub

</pre>
<pre id="codePreview" class="vb">
Shared Sub SetPermissionsToGroup(ByVal siteUrl As String, ByVal groupTitle As String)


        Using site = New SPSite(siteUrl)
            'Connect to Sharepoint Site
            Using web = site.OpenWeb()
                'Get group and group roles 
                Dim group = web.SiteGroups(groupTitle)
                Dim roles = web.RoleAssignments.GetAssignmentByPrincipal(group)


                'Get the SPRoleDefinition
                Dim sprd As SPRoleDefinition = web.RoleDefinitions.GetByType(SPRoleType.Contributor)
                'Remove the SPRoleDefinition
                roles.RoleDefinitionBindings.Remove(sprd)
                'Updates the Role Assignment
                roles.Update()
…
            End Using
        End Using


    End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""><br>
As you know, the various definitions can be fetched from the [SPWeb].RoleDefinitions collection such as Contribute and Full Control. We can also use RoleDefinitions.GetByType method. The mapping of SPRoleType and RoleDefinition as shown below:
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="text-autospace:none"><span style="">Administrator&gt;&gt;Full Control
<br>
WebDesigner&gt;&gt;Design <br>
Contributor&gt;&gt;Contribute<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
<br>
Reader&gt;&gt;Read <br>
Guest&gt;&gt;Limited Access <br>
None&gt;&gt;View Only </span></p>
<p class="MsoNormal" style="text-autospace:none"><span style="">Step 6: You can debug and test it.
</span></p>
<h2>More Information</h2>
<p class="MsoNormal">SPRoleDefinitionBindingCollection Class<span style=""><br>
<a href="http://msdn.microsoft.com/en-us/library/ms463181">http://msdn.microsoft.com/en-us/library/ms463181</a><br>
</span>SPWeb.RoleAssignments Property<br>
<span style=""><a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spweb.roleassignments(v=office.12).aspx">http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spweb.roleassignments(v=office.12).aspx</a><br>
</span>SPWeb<span>.</span>RoleDefinitions Property<span style=""><br>
<a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spweb.roledefinitions.aspx">http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spweb.roledefinitions.aspx</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
