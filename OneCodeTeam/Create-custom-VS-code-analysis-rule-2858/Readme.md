# Create custom VS code analysis rule (VBCustomCodeAnalysisRule)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* VSX
## Topics
* Code Analysis
## IsPublished
* False
## ModifiedDate
* 2011-05-05 09:51:21
## Description

<p style="font-family:Courier New"></p>
<h2>Windows APPLICATION: VBCustomCodeAnalysisRule </h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New">The sample demonstrates how to create, deploy and run custom Code Analysis rules.<br>
<br>
You can use Code Analysis in Visual Studio 2010 Premium and Visual Studio 2010 Ultimate<br>
to discover potential issues in your code. The rules in this sample are used to check<br>
the names of fields, properties and methods.<br>
</p>
<h3>Setup and Removal:</h3>
<p style="font-family:Courier New"><br>
--------------------------------------<br>
In the Development Environment<br>
<br>
A. Setup<br>
<br>
Navigate to the output folder<br>
1. Copy VBCustomCodeAnalysisRule.dll to<br>
C:\Program Files (x86)\Microsoft Visual Studio 10.0\Team Tools\Static Analysis Tools\<br>
FxCop\Rules [For 64bit OS] or C:\Program Files\Microsoft Visual Studio 10.0\Team Tools\<br>
Static Analysis Tools\FxCop\Rules [For 32 bit OS]<br>
<br>
2. Copy VBCustomCodeAnalysisRule.ruleset to <br>
C:\Program Files (x86)\Microsoft Visual Studio 10.0\Team Tools\Static Analysis Tools\<br>
Rule Sets [For 64bit OS] or C:\Program Files (x86)\Microsoft Visual Studio 10.0\Team Tools\<br>
Static Analysis Tools\Rule Sets [For 32 bit OS]<br>
<br>
B. Removal<br>
<br>
Delete above 2 files.<br>
<br>
<br>
--------------------------------------<br>
In the Deployment Environment<br>
<br>
A. Setup<br>
<br>
Install VBCustomCodeAnalysisRuleSetup.msi, the output of the VBCustomCodeAnalysisRuleSetup
<br>
setup project.<br>
<br>
<br>
B. Removal<br>
<br>
Uninstall VBCustomCodeAnalysisRuleSetup.msi, the output of the VBCustomCodeAnalysisRuleSetup<br>
setup project. <br>
<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Step1. Open this project in &nbsp;Visual Studio 2010 Premium or Visual Studio 2010 Ultimate.
<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
Step2. Build the solution. <br>
<br>
Step3. Right click the project VBCustomCodeAnalysisRuleSetup in Solution Explorer,
<br>
&nbsp; &nbsp; &nbsp; and choose &quot;Install&quot;.<br>
<br>
&nbsp; &nbsp; &nbsp; NOTE: You can also copy the files follow the steps in the &quot;Setup and Removal&quot; section.<br>
<br>
Step4. Open another VS2010 instance, create a VB class library project TestCA.vbproj,
<br>
&nbsp; &nbsp; &nbsp; add following class.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;Public Class ClassA<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Private WrongFieldName As Integer<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Private rightFieldName As Integer<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Public Property wrongPropertyName() As Integer<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Public Property RightPropertyName() As Integer<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Public Sub wrongMethodName()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Public Sub RightMethodName()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Class<br>
<br>
Step5. Open the properties page of the project TestCA, in the Code Analysis tab, select<br>
&nbsp; &nbsp; &nbsp; VBCustomCodeAnalysisRule.<br>
<br>
Step6. In the VS, click Analyze=&gt; Run Code Analysis on TestCA. You will get following
<br>
&nbsp; &nbsp; &nbsp; warnings in the Error List Window.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; CCAR0001 : Naming : The name of the field WrongFieldName in class TestCA.ClassA
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; should start with a lowercase character.&nbsp;&nbsp;&nbsp;&nbsp;<br>
<br>
&nbsp; &nbsp; &nbsp; CCAR0002 : Naming : The name of the method wrongMethodName in class TestCA.ClassA<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; should start with a uppercase character.&nbsp;&nbsp;&nbsp;&nbsp;<br>
<br>
&nbsp; &nbsp; &nbsp; CCAR0003 : Naming : The name of the property wrongPropertyName in class TestCA.ClassA
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; should start with a uppercase character.&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp; &nbsp; &nbsp; <br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
A. Create the project and add references<br>
<br>
In Visual Studio 2010, create a Visual C# / Windows / Class Library project <br>
named &quot;VBCustomCodeAnalysisRule&quot;. <br>
<br>
Add references FxCopSdk.dll and Microsoft.Cci.dll. These two assemblies are located in<br>
the FxCop folder. FxCop 10.0 is included in Windows SDK 7.1. You can download it in the
<br>
following link.<br>
<a target="_blank" href="http://www.microsoft.com/downloads/en/details.aspx?FamilyID=35aeda01-421d-4ba5-b44b-543dc8c33a20&displaylang=en">http://www.microsoft.com/downloads/en/details.aspx?FamilyID=35aeda01-421d-4ba5-b44b-543dc8c33a20&displaylang=en</a><br>
<br>
B. Implement Code Analysis Rules FieldNamingRule, MethodNamingRule, and PropertyNamingRule.<br>
<br>
A custom Code Analysis rule is a sealed class which inherits the class <br>
Microsoft.FxCop.Sdk.BaseIntrospectionRule. Override the method <br>
public ProblemCollection Check(Member member) to check the members.<br>
<br>
&nbsp; &nbsp;sealed class PropertyNamingRule : BaseIntrospectionRule<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;public PropertyNamingRule()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;: base( &quot;PropertyNamingRule&quot;, &quot;VBCustomCodeAnalysisRule.Rules&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;typeof(FieldNamingRule).Assembly)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{}<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public override ProblemCollection Check(Member member)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{ &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (member is PropertyNode)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;PropertyNode property = member as PropertyNode;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (property.Name.Name[0] &lt; 'A' || property.Name.Name[0] &gt; 'Z')<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.Problems.Add(new Problem(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; this.GetNamedResolution(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot;UppercaseProperty&quot;,
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; property.Name.Name,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; property.DeclaringType.FullName)));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return this.Problems;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;}<br>
<br>
<br>
C. Define the rule in Rules.xml. <br>
&nbsp; <br>
&nbsp; This file defines metadata for all of the rules in the assembly. In Visual Studio, add<br>
&nbsp; a file named Rules.xml and then mark the file as an &quot;Embedded Resource&quot; in the properties<br>
&nbsp; window. The xml is like <br>
<br>
&lt;Rules&gt;<br>
&nbsp;&lt;Rule TypeName=&quot;FieldNamingRule&quot; Category=&quot;Naming&quot; CheckId=&quot;CCAR0001&quot;&gt;<br>
&nbsp; &nbsp;&lt;Name&gt;Field name should start with a lowercase character&lt;/Name&gt;<br>
&nbsp; &nbsp;&lt;Description&gt; The name of a field in a class should start with a lowercase character. &nbsp;&lt;/Description&gt;<br>
&nbsp; &nbsp;&lt;Resolution Name=&quot;LowercaseField&quot;&gt; The name of the field {0} in class {1} should start with a lowercase character. &lt;/Resolution&gt;<br>
&nbsp; &nbsp;&lt;MessageLevel Certainty=&quot;99&quot;&gt;Warning&lt;/MessageLevel&gt;<br>
&nbsp; &nbsp;&lt;Message Certainty=&quot;99&quot;&gt;Warning&lt;/Message&gt;<br>
&nbsp; &nbsp;&lt;FixCategories&gt;NonBreaking&lt;/FixCategories&gt;<br>
&nbsp; &nbsp;&lt;Owner&gt;&lt;/Owner&gt;<br>
&nbsp; &nbsp;&lt;Url&gt;&lt;/Url&gt;<br>
&nbsp; &nbsp;&lt;Email&gt;&lt;/Email&gt;<br>
&nbsp;&lt;/Rule&gt;<br>
&nbsp;...<br>
<br>
&nbsp; <br>
D. Define a new Rule Set.<br>
A new feature in Visual Studio 2010 is called rule sets. Rule sets are a new way of
<br>
configuring which rules should be run during analysis. A rule set is like <br>
<br>
&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;<br>
&lt;RuleSet Name=&quot;VBCustomCodeAnalysisRule&quot; Description=&quot; &quot; ToolsVersion=&quot;10.0&quot;&gt;<br>
&nbsp;&lt;Rules AnalyzerId=&quot;Microsoft.Analyzers.ManagedCodeAnalysis&quot; RuleNamespace=&quot;Microsoft.Rules.Managed&quot;&gt;<br>
&nbsp; &nbsp;&lt;Rule Id=&quot;CCAR0001&quot; Action=&quot;Warning&quot; /&gt;<br>
&nbsp; &nbsp;&lt;Rule Id=&quot;CCAR0002&quot; Action=&quot;Warning&quot; /&gt;<br>
&nbsp; &nbsp;&lt;Rule Id=&quot;CCAR0003&quot; Action=&quot;Warning&quot; /&gt;<br>
&nbsp;&lt;/Rules&gt;<br>
&lt;/RuleSet&gt;<br>
<br>
E. Deploying the Rule with a setup project.<br>
<br>
&nbsp;To add a deployment project, on the File menu, point to Add, and then click New Project.
<br>
&nbsp;In the Add New Project dialog box, expand the Other Project Types node, expand the Setup<br>
&nbsp;and Deployment Projects, click Visual Studio Installer, and then click Setup Project. In<br>
&nbsp;the Name box, type VBCustomCodeAnalysisRuleSetup. Click OK to create the project.
<br>
&nbsp;<br>
&nbsp;1 Right-click the setup project, and choose View / File System. <br>
&nbsp;<br>
&nbsp;2 In the File System window, right click the File System on Target Machine, and choose Add<br>
&nbsp; &nbsp;Special Folder=&gt; Program Files Folder<br>
&nbsp;<br>
&nbsp;3 Create folder &quot;Microsoft Visual Studio 10.0\Team Tools\Static Analysis Tools\Rule Sets&quot;
<br>
&nbsp; &nbsp;under Program Files Folder. Add the Primry output from CSCustomCodeAnalysis to the folder.<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;4 Create folder &quot;Microsoft Visual Studio 10.0\Team Tools\Static Analysis Tools\FxCop\Rules&quot;<br>
&nbsp; &nbsp;under Program Files Folder. Add VBCustomCodeAnalysisRule.ruleset to the folder.<br>
&nbsp;<br>
&nbsp;Build the setup project. If the build succeeds, you will get a .msi file and a Setup.exe file.<br>
&nbsp;You can distribute them to your users to install or uninstall these rules. </p>
<h3>References:</h3>
<p style="font-family:Courier New"><a target="_blank" href="http://msdn.microsoft.com/en-us/library/microsoft.build.evaluation.project.aspx">http://msdn.microsoft.com/en-us/library/microsoft.build.evaluation.project.aspx</a><br>
<a target="_blank" href="http://www.binarycoder.net/fxcop/html/doccomments.html">http://www.binarycoder.net/fxcop/html/doccomments.html</a><br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
