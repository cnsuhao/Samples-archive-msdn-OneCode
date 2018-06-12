# Office managed COM addIn shim (CppOfficeManagedCOMAddInShim)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Office
## Topics
* Shim
* Office Addin
## IsPublished
* True
## ModifiedDate
* 2011-05-05 04:31:51
## Description

<p style="font-family:Courier New"></p>
<h2>Class Library APPLICATION : CppOfficeManagedCOMAddInShim Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Overview:</h3>
<p style="font-family:Courier New"><br>
When we build a managed Office extension of any kind, we should ensure that<br>
our extension is isolated from other extensions that might be loaded into <br>
the application. The standard way to isolate our extension is to build a <br>
custom COM shim by using the COM Shim Wizard, a set of Visual Studio project<br>
wizards that helps you construct shims quickly and easily.<br>
<br>
</p>
<h3>Project Relation:</h3>
<p style="font-family:Courier New"><br>
CppOfficeManagedCOMAddInShim -&gt; CSOfficeSharedAddIn<br>
CppOfficeManagedCOMAddInShim shims the managed COM AddIn CSOfficeSharedAddIn<br>
<br>
ManagedAggregator -&gt; CppOfficeManagedCOMAddInShim<br>
ManagedAggregator loads and instantiates the add-in object, so that it can <br>
correctly aggregate this with the shim.<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
Step1. Download the COM Shim Wizard template from the Microsoft download<br>
site, and install it so we can find the Shim AddIn template in Visual Studio,<br>
<a target="_blank" href="&lt;a target=" href="http://www.microsoft.com/downloads/details.aspx?FamilyId=3E43BF08-5008-4BB6-AA85-93C1D902470E&displaylang=en">http://www.microsoft.com/downloads/details.aspx?FamilyId=3E43BF08-5008-4BB6-AA85-93C1D902470E&displaylang=en</a>'&gt;<a target="_blank" href="http://www.microsoft.com/downloads/details.aspx?FamilyId=3E43BF08-5008-4BB6-AA85-93C1D902470E&displaylang=en">http://www.microsoft.com/downloads/details.aspx?FamilyId=3E43BF08-5008-4BB6-AA85-93C1D902470E&displaylang=en</a><br>
<br>
Step2. Create an Office COM Addin(Shared AddIn) to be shimed, and compile it. <br>
In this example, we use CSOfficeSharedAddIn as the target managed COM AddIn.<br>
It's a good practice to sign the managed COM AddIn dll with strong name.<br>
<br>
Step3. Create a new project. In the New Project dialog, navigate to the <br>
Visual C&#43;&#43; / COMShims node. Select the AddIn Shim project in right panel, <br>
name it as CppOfficeManagedCOMAddInShim and click OK.<br>
<br>
Step4. The COM Shim Wizard pops up. In the first page of the wizard, specify <br>
the output assembly of the managed COM AddIn project, and press Next button. <br>
(We may receive a warning dialog saying that the assembly needs to be signed <br>
as strong name if the target assembly was not signed. Just click Yes to <br>
ignore it)<br>
<br>
Step5. The second page is for configuration when our AddIn implements a <br>
secondary extensibility interface. We do not need this in this sample. Just <br>
press Next<br>
<br>
Step6. The third page is about Shared Add-in Details. In the page we can <br>
specify:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Add-in Description<br>
&nbsp;&nbsp;&nbsp;&nbsp;Add-in Friendly Name<br>
&nbsp;&nbsp;&nbsp;&nbsp;Whether to load the Add-in when the host Office application starts<br>
&nbsp;&nbsp;&nbsp;&nbsp;Whether to install the Add-in to all users<br>
&nbsp;&nbsp;&nbsp;&nbsp;Add-in's host Office application<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
In this example, we check the Microsoft Word, Visio, Publisher, Project, <br>
PowerPoint, Outlook, FrontPage, Excel, and Access checkboxes and, press Next <br>
to go on.<br>
<br>
Step7. The last is a summary page. Click Finish to create the AddIn Shim <br>
project. Accompanied with CppOfficeManagedCOMAddInShim, the wizard creates a <br>
.NET class library project named ManagedAggregator. The generated project <br>
also includes a final build task that runs Regsvr32.exe on the target DLL to <br>
register the shim, so you do not need to register it manually. The final <br>
build task copies the ManagedAggregator.dll into the target folder for the <br>
shim. It also copies the managed add-in assembly that you specified into the <br>
target folder for the shim, along with the configuration file for the add-in. <br>
The project dependencies are set so that the ManagedAggregator is built first, <br>
before the shim. If you add a shim project to an existing add-in solution, <br>
you should adjust the build dependencies, as appropriate. <br>
<br>
Step8. After the creation, compile the solution. You will find <br>
CSOfficeSharedAddIn in Office applications' COM Addins Dialog. And the <br>
location points to CppOfficeManagedCOMAddInShim.dll instead of mscoree.dll.<br>
<br>
</p>
<h3>Deployment:</h3>
<p style="font-family:Courier New"><br>
Step1. Navigate to the output folder of the CppOfficeManagedCOMAddInShim <br>
project. We can see the generated files:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;CppOfficeManagedCOMAddInShim.dll<br>
&nbsp;&nbsp;&nbsp;&nbsp;ManagedAggregator.dll<br>
&nbsp;&nbsp;&nbsp;&nbsp;CSOfficeSharedAddIn.dll<br>
<br>
Step2. Copy the above three files to the target computer where you want to <br>
deploy the Add-in.<br>
<br>
Step3. On the target computer, start a command prompt as administrator.<br>
<br>
Step4. Enter the command &quot;regsvr32 CppOfficeManagedCOMAddInShim.dll&quot; to
<br>
register the shim dll.<br>
<br>
Step5. Open an Office application to verify the AddIn is shimed by <br>
CppOfficeManagedCOMAddInShim.dll.<br>
<br>
<br>
If you build a setup project for your add-in, you should add the primary <br>
output of both the shim and the ManagedAggregator projects to your setup. You <br>
should also change the value of the Register property for all three project <br>
outputs. Set this to vsdrpCOM for the shim DLL, and vsdrpDoNotRegister for <br>
both the original add-in DLL and the ManagedAggregator DLL. <br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: Isolating Microsoft Office Extensions with the COM Shim Wizard Version <br>
2.3.1<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb508939.aspx">http://msdn.microsoft.com/en-us/library/bb508939.aspx</a><br>
<br>
COM Shim Wizard Author's blog:<br>
<a target="_blank" href="http://blogs.msdn.com/andreww/archive/2007/07/05/updated-com-shim-wizards.aspx">http://blogs.msdn.com/andreww/archive/2007/07/05/updated-com-shim-wizards.aspx</a><br>
<br>
COM Shim Wizard download page:<br>
<a target="_blank" href="&lt;a target=" href="http://www.microsoft.com/downloads/details.aspx?FamilyId=3E43BF08-5008-4BB6-AA85-93C1D902470E&displaylang=en">http://www.microsoft.com/downloads/details.aspx?FamilyId=3E43BF08-5008-4BB6-AA85-93C1D902470E&displaylang=en</a>'&gt;<a target="_blank" href="http://www.microsoft.com/downloads/details.aspx?FamilyId=3E43BF08-5008-4BB6-AA85-93C1D902470E&displaylang=en">http://www.microsoft.com/downloads/details.aspx?FamilyId=3E43BF08-5008-4BB6-AA85-93C1D902470E&displaylang=en</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
