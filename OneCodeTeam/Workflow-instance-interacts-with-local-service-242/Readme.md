# Workflow instance interacts with local service (CSWFLocalService)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* WF
## Topics
* Communication
## IsPublished
* True
## ModifiedDate
* 2011-05-05 06:41:12
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CSWFLocalService</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
How to play the game:<br>
When the game start,workflow instance will generate a random number,then you <br>
input a number between 1 and 10,if your input larger than the random number,<br>
the game will ask you to input a smaller number. if your input number smaller <br>
than the random number,the game will ask you to input a larger one.Until your <br>
input number equel to the ramdon number, the game will tell you your input hit <br>
the answer - show a message:&quot;right&quot;.<br>
<br>
I create the sample to demonstrate:<br>
1. How to send a message from workflow instance to local service?<br>
&nbsp; When the game start and every time you input a number,game workflow instance
<br>
will send out a message to the player(local service),we use <br>
CallExternalMethodActivity to do it.More info about CallExternalMethodActivity<br>
please check:<br>
<a target="_blank" href="http://xhinker.com/2009/10/27/WFWhatIsCallExternalMethodActivityAndHowToUseIt.aspx">http://xhinker.com/2009/10/27/WFWhatIsCallExternalMethodActivityAndHowToUseIt.aspx</a><br>
2. How to send a message from workflow host to workflow instance?<br>
&nbsp; When you input a number,how could the host send the input number to workflow<br>
instance?We use HandleExternalEventActivity to do it,for a example usage of<br>
HandleExternalEventActivity,please check:<br>
<a target="_blank" href="http://xhinker.com/2009/10/29/WFHandleExternalEventActivity.aspx">http://xhinker.com/2009/10/29/WFHandleExternalEventActivity.aspx</a><br>
3. How to send a message from local service to workflow host?<br>
&nbsp; We use CallExternalMethodActivity to send data from the workflow to local<br>
service.In this game,send message to local service(I mean GuessNumberGameService)<br>
is not enough.To interact with player, we should let the message end at workflow<br>
host. We can use event to do it.declare a event in GuessNumberGameService,handler<br>
the event in workflow host(Program.cs),warp message with MessageEventArgs.<br>
<br>
</p>
<h3>Prerequisite</h3>
<p style="font-family:Courier New"><br>
1. Visual Studio 2008<br>
2. .NET Framework 3.5<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
1.Create a Event Arg - MessageEventArgs.cs<br>
2.Create Local Service - IGuessNumberGameService.cs;GuessNumberGameService.cs<br>
3.Create WF - GuessNumberGameWF.cs<br>
4.Host the workflow - Program.cs<br>
<br>
For more detail info, please check:<br>
<a target="_blank" href="&lt;a target=" href="http://xhinker.com/2009/11/01/WFBuildAGuessNumberGameWithWindowWorkflowFoundation35.aspx">http://xhinker.com/2009/11/01/WFBuildAGuessNumberGameWithWindowWorkflowFoundation35.aspx</a>'&gt;<a target="_blank" href="http://xhinker.com/2009/11/01/WFBuildAGuessNumberGameWithWindowWorkflowFoundation35.aspx">http://xhinker.com/2009/11/01/WFBuildAGuessNumberGameWithWindowWorkflowFoundation35.aspx</a><br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
<a target="_blank" href="&lt;a target=" href="http://xhinker.com/2009/11/01/WFBuildAGuessNumberGameWithWindowWorkflowFoundation35.aspx">http://xhinker.com/2009/11/01/WFBuildAGuessNumberGameWithWindowWorkflowFoundation35.aspx</a>'&gt;<a target="_blank" href="http://xhinker.com/2009/11/01/WFBuildAGuessNumberGameWithWindowWorkflowFoundation35.aspx">http://xhinker.com/2009/11/01/WFBuildAGuessNumberGameWithWindowWorkflowFoundation35.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
