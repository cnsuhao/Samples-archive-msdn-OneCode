# Silverlight 3 plane projection feature demo (VBSL3PlaneProjection)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Silverlight
## Topics
* Plane Projection
## IsPublished
* True
## ModifiedDate
* 2011-05-05 08:17:50
## Description

<p style="font-family:Courier New"></p>
<h2>SILVERLIGHT APPLICATION : VBSL3PlaneProjection Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This example illustrates how to use the new perspective 3D feature of <br>
Silverlight 3. PlaneProjection is the commonly &nbsp;used object to achieve <br>
perspective 3D effect. In this sample, you'll see how to control perspective <br>
projection by adjusting the properties of PlaneProjection object. In addition,<br>
you'll see the control's functionality remains after projection. You can <br>
confirm this by clicking a date of the Calendar control.<br>
<br>
</p>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
Silverlight 3 Tools for Visual Studio 2008 SP1<br>
<a target="_blank" href="http://www.microsoft.com/downloads/details.aspx?familyid=9442b0f2-7465-417a-88f3-5e7b5409e9dd&displaylang=en">http://www.microsoft.com/downloads/details.aspx?familyid=9442b0f2-7465-417a-88f3-5e7b5409e9dd&displaylang=en</a><br>
<br>
Silverilght 3 runtime:<br>
<a target="_blank" href="http://silverlight.net/getstarted/">http://silverlight.net/getstarted/</a><br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
A. Create the Silverlight project<br>
<br>
Step1. Create a Visual Basic Silverlight Application project named VBSL3PlaneProjection<br>
in Visual Studio 2008 SP1.<br>
<br>
B. Edit MainPage.xaml<br>
<br>
Step1. Double click MainPage.xaml in the Solution Explorer window to view the <br>
xaml code. Drag a Calendar control from toolbox and drop it in the &lt;Grid&gt;.<br>
<br>
Step2. Replace the entire &lt;Grid&gt; with the following code:<br>
<br>
&nbsp;&lt;Grid x:Name=&quot;LayoutRoot&quot; Background=&quot;AliceBlue&quot;&gt;<br>
&nbsp; &nbsp; &nbsp;&lt;Grid.RowDefinitions&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;RowDefinition Height=&quot;2*&quot;&gt;&lt;/RowDefinition&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;RowDefinition Height=&quot;4*&quot;&gt;&lt;/RowDefinition&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;RowDefinition Height=&quot;4*&quot;&gt;&lt;/RowDefinition&gt;<br>
&nbsp; &nbsp; &nbsp;&lt;/Grid.RowDefinitions&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;StackPanel Grid.Row=&quot;0&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;TextBlock x:Name=&quot;TextBlockPlaneProjectionDetails&quot;&gt;&lt;/TextBlock&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;TextBlock x:Name=&quot;TextBlockShowDate&quot; VerticalAlignment=&quot;Center&quot; HorizontalAlignment=&quot;Center&quot; FontSize=&quot;24&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/StackPanel&gt;<br>
&nbsp; &nbsp; &nbsp;&lt;controls:Calendar x:Name=&quot;CalendarPerspective3D&quot; Grid.Row=&quot;1&quot; SelectedDatesChanged=&quot;Calendar_SelectedDatesChanged&quot;&gt;<br>
&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;controls:Calendar.Projection&gt;<br>
&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;PlaneProjection x:Name=&quot;PlaneProjection&quot; CenterOfRotationX=&quot;0&quot; CenterOfRotationY=&quot;0&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/controls:Calendar.Projection&gt;&lt;/controls:Calendar&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;Grid &nbsp;Grid.Row=&quot;2&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Grid.ColumnDefinitions&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;ColumnDefinition&gt;&lt;/ColumnDefinition&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;ColumnDefinition&gt;&lt;/ColumnDefinition&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/Grid.ColumnDefinitions&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;StackPanel Grid.Column=&quot;0&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;TextBlock Height=&quot;17&quot; Margin=&quot;0&quot; Width=&quot;60&quot; Text=&quot;RotationX&quot; TextWrapping=&quot;Wrap&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Slider x:Name=&quot;SliderRotationX&quot; Minimum=&quot;-360&quot; Maximum=&quot;360&quot; Width=&quot;200&quot; Margin=&quot;0&quot; ValueChanged=&quot;SliderRotation_ValueChanged&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;TextBlock Height=&quot;17&quot; Margin=&quot;0&quot; Width=&quot;60&quot; Text=&quot;RotationY&quot; TextWrapping=&quot;Wrap&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Slider x:Name=&quot;SliderRotationY&quot; Minimum=&quot;-360&quot; Maximum=&quot;360&quot; Width=&quot;200&quot; Margin=&quot;0&quot; ValueChanged=&quot;SliderRotation_ValueChanged&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;TextBlock Height=&quot;17&quot; Margin=&quot;0&quot; Width=&quot;60&quot; Text=&quot;RotationZ&quot; TextWrapping=&quot;Wrap&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Slider x:Name=&quot;SliderRotationZ&quot; Minimum=&quot;-360&quot; Maximum=&quot;360&quot; Width=&quot;200&quot; Margin=&quot;0&quot; ValueChanged=&quot;SliderRotation_ValueChanged&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Button Content=&quot;Reset&quot; Width=&quot;200&quot; Height=&quot;25&quot; Click=&quot;ButtonResetRotation_Click&quot;&gt;&lt;/Button&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/StackPanel&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;StackPanel Grid.Column=&quot;1&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;TextBlock Height=&quot;17&quot; Margin=&quot;0&quot; Width=&quot;110&quot; Text=&quot;CenterOfRotationX&quot; TextWrapping=&quot;Wrap&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Slider x:Name=&quot;SliderCenterX&quot; Minimum=&quot;-50&quot; Maximum=&quot;50&quot; Width=&quot;200&quot; Margin=&quot;0&quot; ValueChanged=&quot;SliderCenterOfRotation_ValueChanged&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;TextBlock Height=&quot;17&quot; Margin=&quot;0&quot; Width=&quot;110&quot; Text=&quot;CenterOfRotationY&quot; TextWrapping=&quot;Wrap&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Slider x:Name=&quot;SliderCenterY&quot; Minimum=&quot;-50&quot; Maximum=&quot;50&quot; Width=&quot;200&quot; Margin=&quot;0&quot; ValueChanged=&quot;SliderCenterOfRotation_ValueChanged&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;TextBlock Height=&quot;17&quot; Margin=&quot;0&quot; Width=&quot;110&quot; Text=&quot;CenterOfRotationZ&quot; TextWrapping=&quot;Wrap&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Slider x:Name=&quot;SliderCenterZ&quot; Minimum=&quot;-50&quot; Maximum=&quot;50&quot; Width=&quot;200&quot; Margin=&quot;0&quot; ValueChanged=&quot;SliderCenterOfRotation_ValueChanged&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Button Content=&quot;Reset&quot; Width=&quot;200&quot; Height=&quot;25&quot; Click=&quot;ButtonResetCenterOfRotation_Click&quot;&gt;&lt;/Button&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/StackPanel&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/Grid&gt; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp;&lt;/Grid&gt;<br>
&nbsp; &nbsp;<br>
The above code mainly adds these controls:<br>
A Calendar control that the projection act on.<br>
Three Slider controls that control the rotation related properties of PlaneProjection.<br>
Three Slider controls that control the rotation center related properties of PlaneProjection.<br>
A TextBlock control (TextBlockPlaneProjectionDetails) that shows the current rotation and<br>
rotation center related values of PlaneProjection.<br>
A TextBlock control (TextBlockShowDate) that shows the selected date of Calendar control.<br>
<br>
C. Edit MainPage.xaml.vb<br>
<br>
Step1. Replace MainPage class with the following code:<br>
<br>
&nbsp; Partial Public Class MainPage<br>
&nbsp; &nbsp;Inherits UserControl<br>
<br>
&nbsp; &nbsp;Public Sub New()<br>
&nbsp; &nbsp; &nbsp; &nbsp;InitializeComponent()<br>
&nbsp; &nbsp;End Sub<br>
<br>
<br>
&nbsp; &nbsp;Private Sub Calendar_SelectedDatesChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp;' Get the reference of the sender Calendar, then show the selected date on TextBlockShowDate control.<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim calendar As Calendar = CType(sender, Calendar)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Me.TextBlockShowDate.Text = calendar.SelectedDate.Value.ToShortDateString()<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;Private Sub SliderRotation_ValueChanged(ByVal sender As Object, ByVal e As RoutedPropertyChangedEventArgs(Of Double))<br>
&nbsp; &nbsp; &nbsp; &nbsp;' Change the rotation center position of PlaneProjection and rotate Calendar.<br>
&nbsp; &nbsp; &nbsp; &nbsp;RefreshPlaneProjection(Me.PlaneProjection, Me.SliderRotationX.Value, Me.SliderRotationY.Value, Me.SliderRotationZ.Value, Double.NaN, Double.NaN, Double.NaN)<br>
&nbsp; &nbsp; &nbsp; &nbsp;' Refresh TextBlockPlaneProjectionDetails control to show the current value of
<br>
&nbsp; &nbsp; &nbsp; &nbsp;' RotationX, RotationY, RotationZ, CenterOfRotationX, CenterOfRotationY, CenterOfRotationZ
<br>
&nbsp; &nbsp; &nbsp; &nbsp;' of PlaneProjection.<br>
&nbsp; &nbsp; &nbsp; &nbsp;RefreshTextBlockPlaneProjectionDetails()<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;Private Sub SliderCenterOfRotation_ValueChanged(ByVal sender As Object, ByVal e As RoutedPropertyChangedEventArgs(Of Double))<br>
&nbsp; &nbsp; &nbsp; &nbsp;' Change the rotation center position of PlaneProjection and rotate Calendar.<br>
&nbsp; &nbsp; &nbsp; &nbsp;RefreshPlaneProjection(Me.PlaneProjection, Double.NaN, Double.NaN, Double.NaN, Me.SliderCenterX.Value, Me.SliderCenterY.Value, Me.SliderCenterZ.Value)<br>
&nbsp; &nbsp; &nbsp; &nbsp;' Refresh TextBlockPlaneProjectionDetails control to show the current value of
<br>
&nbsp; &nbsp; &nbsp; &nbsp;' RotationX, RotationY, RotationZ, CenterOfRotationX, CenterOfRotationY, CenterOfRotationZ
<br>
&nbsp; &nbsp; &nbsp; &nbsp;' of PlaneProjection.<br>
&nbsp; &nbsp; &nbsp; &nbsp;RefreshTextBlockPlaneProjectionDetails()<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;Private Sub RefreshPlaneProjection(ByVal planeProjection As PlaneProjection, ByVal rotationX As Double, ByVal rotationY As Double, ByVal rotationZ As Double, ByVal centerOfRotationX As Double, ByVal centerOfRotationY As Double, ByVal centerOfRotationZ
 As Double)<br>
&nbsp; &nbsp; &nbsp; &nbsp;' Change rotation and rotation center related properties of PlaneProjection.<br>
&nbsp; &nbsp; &nbsp; &nbsp;If (Not Double.IsNaN(rotationX)) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;planeProjection.RotationX = rotationX<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;If (Not Double.IsNaN(rotationY)) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;planeProjection.RotationY = rotationY<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;If (Not Double.IsNaN(rotationZ)) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;planeProjection.RotationZ = rotationZ<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;If (Not Double.IsNaN(centerOfRotationX)) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;planeProjection.CenterOfRotationX = centerOfRotationX<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;If (Not Double.IsNaN(centerOfRotationY)) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;planeProjection.CenterOfRotationY = centerOfRotationY<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;If (Not Double.IsNaN(centerOfRotationZ)) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;planeProjection.CenterOfRotationZ = centerOfRotationZ<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;Private Sub RefreshTextBlockPlaneProjectionDetails()<br>
&nbsp; &nbsp; &nbsp; &nbsp;Me.TextBlockPlaneProjectionDetails.Text = String.Format(&quot;RotationX:{0}, RotationY:{1}, RotationZ:{2}&quot; & ControlChars.CrLf & &quot;CenterOfRotationX:{3}, CenterOfRotationY:{4}, CenterOfRotationZ:{5}&quot;, Me.PlaneProjection.RotationX,
 Me.PlaneProjection.RotationY, Me.PlaneProjection.RotationZ, Me.PlaneProjection.CenterOfRotationX, Me.PlaneProjection.CenterOfRotationY, Me.PlaneProjection.CenterOfRotationZ)<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;Private Sub ButtonResetRotation_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp;' Reset the value of roation related Sliders.<br>
&nbsp; &nbsp; &nbsp; &nbsp;Me.SliderRotationX.Value = 0<br>
&nbsp; &nbsp; &nbsp; &nbsp;Me.SliderRotationY.Value = 0<br>
&nbsp; &nbsp; &nbsp; &nbsp;Me.SliderRotationZ.Value = 0<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;Private Sub ButtonResetCenterOfRotation_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp;' Reset the value of roation center related Sliders.<br>
&nbsp; &nbsp; &nbsp; &nbsp;Me.SliderCenterX.Value = 0<br>
&nbsp; &nbsp; &nbsp; &nbsp;Me.SliderCenterY.Value = 0<br>
&nbsp; &nbsp; &nbsp; &nbsp;Me.SliderCenterZ.Value = 0<br>
&nbsp; &nbsp;End Sub<br>
End Class<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
3-D Effects (Perspective Transforms)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/dd470131(VS.95).aspx">http://msdn.microsoft.com/en-us/library/dd470131(VS.95).aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
