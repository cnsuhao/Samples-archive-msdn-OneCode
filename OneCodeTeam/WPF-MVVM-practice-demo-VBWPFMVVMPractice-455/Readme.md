# WPF MVVM practice demo (VBWPFMVVMPractice)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* WPF
## Topics
* MVVM
## IsPublished
* True
## ModifiedDate
* 2011-05-05 10:11:42
## Description

<p style="font-family:Courier New"></p>
<h2>WPF APPLICATION: VBWPFMVVMPractice Overview </h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The sample demonstrates how to implement the MVVM pattern in a WPF application.<br>
&nbsp; </p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Step1. Build the sample project in Visual Studio 2010.<br>
<br>
Step2. Click on the cells in the grid. <br>
<br>
Step3. If one player has won the game, a messagebox pops up saying &quot;XX has won,Congratulations!&quot;.<br>
<br>
Step4. If all the cells in the grid are clicked, but no one has won, a messagebox pops up saying &quot;No winner&quot;.<br>
<br>
Step5. You can change the dimension of the game using the Game menu.<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1. Model: <br>
&nbsp;&nbsp;&nbsp;&nbsp;Cell class - represents a cell in the tic-tac-toe game grid<br>
&nbsp;&nbsp;&nbsp;&nbsp;PlayerMove class - represents a player move in the game<br>
<br>
2. ViewModel:<br>
&nbsp;&nbsp;&nbsp;&nbsp;TicTacToeViewModel - contains game's logic and data<br>
<br>
3. View:<br>
&nbsp;&nbsp;&nbsp;&nbsp;MainWindow.xaml - contains a Menu and an ItemsControl<br>
<br>
4. Others:<br>
&nbsp;&nbsp;&nbsp;&nbsp;a. Attached behavior<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ChangeDimensionBehavior - connect the MenuItem in the View to the TicTacToeViewModel in order to change the game's dimension<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShutdownBehavior - contains code to exit the application&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GameOverBehavior - listen to the GameOver event on the TicTacToeViewModel and show a messagebox reporting the game result.<br>
&nbsp;&nbsp;&nbsp;&nbsp;b. ValueConverter<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IntToBoolValueConverter - used to check/uncheck a MenItem that is used to change the dimension of the game&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;c.Command<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RelayCommand - provides an implementation of the ICommand interface<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
WPF Apps With The Model-View-ViewModel Design Pattern<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/magazine/dd419663.aspx">http://msdn.microsoft.com/en-us/magazine/dd419663.aspx</a><br>
<br>
Introduction to Attached Behaviors in WPF<br>
<a target="_blank" href="http://www.codeproject.com/KB/WPF/AttachedBehaviors.aspx">http://www.codeproject.com/KB/WPF/AttachedBehaviors.aspx</a>
<br>
</p>
<h3></h3>
<p style="font-family:Courier New"><br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
