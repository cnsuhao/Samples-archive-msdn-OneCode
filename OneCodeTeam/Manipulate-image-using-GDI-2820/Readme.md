# Manipulate image using GDI+ (CSGDIPlusManipulateImage)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* GDI+
## Topics
* Image
## IsPublished
* True
## ModifiedDate
* 2012-09-21 12:53:22
## Description
================================================================================<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; Windows APPLICATION: CSGDIPlusManipulateImage Overview &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
===============================================================================<br>
/////////////////////////////////////////////////////////////////////////////<br>
Summary:<br>
The sample demonstrates how to to resize, scale, rotate, flip and skew the image using<br>
GDI&#43;.<br>
<br>
////////////////////////////////////////////////////////////////////////////////<br>
Demo:<br>
<br>
Step1. Build this project in VS2010. <br>
<br>
Step2. Run CSGDIPlusManipulateImage.exe. <br>
<br>
Step3. Press the button &quot;Micrify&quot;, you will see that the image size changes to the half of the
<br>
&nbsp; &nbsp; &nbsp; original value.<br>
<br>
Step4. Press the button &quot;Reset&quot;. <br>
<br>
Step5. Press the button &quot;Amplify&quot;, you will see that the image size changes to the double of the
<br>
&nbsp; &nbsp; &nbsp; original value.<br>
<br>
Step6. Press the button &quot;Reset&quot;. <br>
<br>
Step7. Press the button &quot;RotateLeft&quot;, you will see that the image was rotated to the left by &nbsp;<br>
&nbsp; &nbsp; &nbsp; 90 degree. <br>
<br>
Step8. Press the button &quot;Reset&quot;. <br>
<br>
Step9. Press the button &quot;RotateRight&quot;, you will see that the image was rotated to the right by &nbsp;<br>
&nbsp; &nbsp; &nbsp; 90 degree. <br>
<br>
Step10. Press the button &quot;Reset&quot;. <br>
<br>
Step11. Press the button &quot;FlipHorizontal&quot;, you will see that the image was flipped by
<br>
&nbsp; &nbsp; &nbsp; &nbsp;horizontal.<br>
<br>
Step12. Press the button &quot;Reset&quot;. <br>
<br>
Step13. Press the button &quot;FlipVertical&quot;, you will see that the image was flipped by
<br>
&nbsp; &nbsp; &nbsp; &nbsp;vertical.<br>
<br>
Step14. Press the button &quot;Reset&quot;. <br>
<br>
Step15. Type a value between 0 and 360 in the Rotate Angle textbox, and then Press the
<br>
&nbsp; &nbsp; &nbsp; &nbsp;button &quot;OK&quot;, you will see that the image was rotated by the specified degree.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;You can rotate the image continually without Reset.<br>
<br>
Step16. Press the button &quot;Reset&quot;. <br>
<br>
Step17. Press the button &quot;SkewLeft&quot;, you will see that the top of the image was skewed<br>
&nbsp; &nbsp; &nbsp; &nbsp;to the left. <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Press the button &quot;SkewRight&quot;, you will see that the top of the image was skewed<br>
&nbsp; &nbsp; &nbsp; &nbsp;to the right. <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;You can skew the image continually without Reset.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NOTE: Since the &quot;Skew&quot; is not a linear transform, you have to reset the image
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;after other operations in this application.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;<br>
<br>
Step16. Press the button &quot;Reset&quot;. <br>
<br>
Step17. Press the buttons &quot;MoveUp&quot;, &quot;MoveLeft&quot;, &quot;MoveDown&quot; and &quot;Moveright&quot;, you will<br>
&nbsp; &nbsp; &nbsp; &nbsp;see that the image was moved up, left, down and right.<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Code Logic:<br>
<br>
1. Design a class ImageManipulator which is used to manipulate an image using GDI&#43;.
<br>
&nbsp; It supplies methods to resize, scale, rotate and flip the image.<br>
<br>
&nbsp; 1.1 Resize<br>
&nbsp; &nbsp; &nbsp; Use the following constructor of the Bitmap class to get a resized image from<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; the original image.<br>
&nbsp;<br>
&nbsp; &nbsp; &nbsp; public Bitmap(Image original, Size newSize);<br>
&nbsp;<br>
&nbsp; 1.2 Scale<br>
&nbsp; &nbsp; &nbsp; Initializes a new instance of the Matrix class with the specified elements.
<br>
&nbsp; &nbsp; &nbsp; This Matrix is used in Transform. When draw the original image to the new bitmap,<br>
&nbsp; &nbsp; &nbsp; the Transform will take effect.<br>
<br>
&nbsp; &nbsp; &nbsp; The Matrix is like <br>
&nbsp; &nbsp; &nbsp; | xFactor &nbsp; &nbsp; &nbsp;0 |<br>
&nbsp; &nbsp; &nbsp; | 0 &nbsp; &nbsp; &nbsp;yFactor |<br>
&nbsp; &nbsp; &nbsp; | 0 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;0 |<br>
&nbsp; &nbsp; &nbsp; which means that the image will be scaled by xFactor in Width and yFactor in
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; Height.<br>
<br>
&nbsp; 1.3 Rotate and Flip<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 1.3.1 The Image clsss supplies a method RotateFlip(RotateFlipType rotateFlipType)
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; to rotate and flip the image. But this method could only rotate 90, 180 or<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 270 degree.<br>
<br>
&nbsp; &nbsp; &nbsp; 1.3.2 Use Transform. The steps are<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 1.3.2.1 Calcualte the necessary size based on the ContentSize and RotatedAngle.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 1.3.2.2 Move the image center to the point (0,0) of the new bitmap.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 1.3.2.3 Rotate the image to a specified angle.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 1.3.2.4 Move the rotated image center to the center of the new bitmap.<br>
<br>
&nbsp; 1.4 Skew<br>
&nbsp; &nbsp; &nbsp; You can skew an image by specifying destination points for the upper-left,
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; upper-right, and lower-left corners of the original image. The three destination<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; points determine an affine transformation that maps the original rectangular
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; image to a parallelogram.<br>
<br>
2. Design the UI that contains many buttons to manipulate the image.<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
References:<br>
<br>
Image Class<br>
http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx<br>
<br>
Bitmap Class<br>
http://msdn.microsoft.com/en-us/library/system.drawing.bitmap.aspx<br>
<br>
Graphics Class<br>
http://msdn.microsoft.com/en-us/library/system.drawing.graphics.aspx<br>
<br>
InterpolationMode Enumeration<br>
http://msdn.microsoft.com/en-us/library/system.drawing.drawing2d.interpolationmode.aspx<br>
<br>
Matrix Class<br>
http://msdn.microsoft.com/en-us/library/system.drawing.drawing2d.matrix.aspx<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
