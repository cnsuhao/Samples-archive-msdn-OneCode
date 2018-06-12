# TIFF image <--> JPEG image converter (VBTiffImageConverter)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* GDI+
* Windows General
## Topics
* TIFF
## IsPublished
* True
## ModifiedDate
* 2011-08-08 07:31:36
## Description

<p style="font-family:Courier New"></p>
<h2>WINDOWS APPLICATION : VBTiffImageConverter Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary: </h3>
<p style="font-family:Courier New"><br>
This sample demonstrates how to convert JPEG images into TIFF images and vice versa. This<br>
sample also allows to create single multipage TIFF images from selected JPEG images.<br>
<br>
TIFF (originally standing for Tagged Image File Format) is a flexible, adaptable file
<br>
format for handling images and data within a single file, by including the header tags<br>
(size, definition, image-data arrangement, applied image compression) defining the
<br>
image's geometry. For example, a TIFF file can be a container holding compressed (lossy)<br>
JPEG and (lossless) PackBits compressed images. A TIFF file also can include a <br>
vector-based clipping path (outlines, croppings, image frames). <br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
The following steps walk through a demonstration of the TIFF image converter sample.<br>
<br>
Step 1: Build and run the sample solution in Visual Studio 2010<br>
<br>
Step 2: Check the checkbox &quot;check to create multipage tiff (single) file&quot; if
<br>
&nbsp; &nbsp; &nbsp; &nbsp;multipage tiff file is to be created.<br>
<br>
Step 3: Convert the images format from Jpeg to Tiff.<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Step 3_1. Click on the &quot;Convert to Tiff&quot; button to browse the jpeg images.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;(Multiselect supported.)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Step 3_2. Click &quot;Ok&quot; after selecting the Jpeg images, which will initiate the
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;conversion process.<br>
<br>
Step 4: Convert the images format from Tiff to Jpeg.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Step 4_1. Click on the &quot;Convert to Jpeg&quot; button to browse the tiff image.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Step 4_2. Click &quot;Ok&quot; after selecting the tiff image, which will initiate the<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;conversion process.<br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
A. Converting TIFF to JPEG<br>
(See: TiffImageConverter.ConvertTiffToJpeg)<br>
<br>
The basic code logic is as follows:<br>
<br>
&nbsp;1. load the TIFF image with Image<br>
&nbsp;2. get the number of frames in the TIFF image.<br>
&nbsp;3. select each frame, and save it as a new jpg image file.<br>
<br>
&nbsp; &nbsp;Public Shared Function ConvertTiffToJpeg(fileName As String) As String()<br>
&nbsp; &nbsp; &nbsp; &nbsp;Using imageFile As Image = Image.FromFile(fileName)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim frameDimensions As New FrameDimension(imageFile.FrameDimensionsList(0))<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Gets the number of pages from the tiff image (if multi-page)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim frameNum As Integer = imageFile.GetFrameCount(frameDimensions)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim jpegPaths As String() = New String(frameNum) {}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim frame As Integer = 0<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;While frame &lt; frameNum<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Selects one frame at a time and save as jpeg.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;imageFile.SelectActiveFrame(frameDimensions, frame)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Using bmp As New Bitmap(imageFile)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;jpegPaths(frame) = [String].Format(&quot;{0}\{1}{2}.jpeg&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Path.GetDirectoryName(fileName),<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Path.GetFileNameWithoutExtension(fileName), frame)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;bmp.Save(jpegPaths(frame), ImageFormat.Jpeg)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Using<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;System.Math.Max(System.Threading.Interlocked.Increment(frame), frame - 1)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End While<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return jpegPaths<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Using<br>
&nbsp; &nbsp;End Function<br>
<br>
B. Converting JPEG(s) to TIFF<br>
(See: TiffImageConverter.ConvertJpegToTiff)<br>
<br>
The basic code logic is as follows:<br>
<br>
&nbsp;1. if user checked &quot;check to create multipage tiff (single) file&quot;.<br>
<br>
&nbsp; &nbsp;1) initialize the first frame of the multipage tiff using the first selected
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; jpeg file.<br>
&nbsp; &nbsp;2) add additional frames from the rest jpeg files.<br>
&nbsp; &nbsp;3) when it is the last frame, flush the resources and close it.<br>
<br>
&nbsp;2. if user did not check &quot;check to create multipage tiff (single) file&quot;.<br>
<br>
&nbsp; &nbsp;1) load each jpeg file<br>
&nbsp; &nbsp;2) save it as a single-frame tiff file.<br>
<br>
&nbsp; &nbsp;Public Shared Function ConvertJpegToTiff(fileNames As String(),<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; isMultipage As Boolean) As String()<br>
&nbsp; &nbsp; &nbsp; &nbsp;Using encoderParams As New EncoderParameters(1)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim tiffCodecInfo As ImageCodecInfo = ImageCodecInfo.GetImageEncoders(). _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;First(Function(ie) ie.MimeType = &quot;image/tiff&quot;)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim tiffPaths As String() = Nothing<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If isMultipage Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tiffPaths = New String(1) {}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim tiffImg As Image = Nothing<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Try<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim i As Integer = 0<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;While i &lt; fileNames.Length<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If i = 0 Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tiffPaths(i) = [String].Format(&quot;{0}\{1}.tiff&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Path.GetDirectoryName(fileNames(i)),<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Path.GetFileNameWithoutExtension(fileNames(i)))<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Initialize the first frame of multi-page tiff.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tiffImg = Image.FromFile(fileNames(i))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;encoderParams.Param(0) = New EncoderParameter(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Encoder.SaveFlag, DirectCast(EncoderValue.MultiFrame,
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;EncoderParameterValueType))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tiffImg.Save(tiffPaths(i), tiffCodecInfo, encoderParams)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Add additional frames.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;encoderParams.Param(0) = New EncoderParameter(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Encoder.SaveFlag,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;DirectCast(EncoderValue.FrameDimensionPage,
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;EncoderParameterValueType))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Using frame As Image = Image.FromFile(fileNames(i))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tiffImg.SaveAdd(frame, encoderParams)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Using<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If i = fileNames.Length - 1 Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' When it is the last frame, flush the resources and closing.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;encoderParams.Param(0) = New EncoderParameter(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Encoder.SaveFlag,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; DirectCast(EncoderValue.Flush, EncoderParameterValueType))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tiffImg.SaveAdd(encoderParams)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End While<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Finally<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If tiffImg IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tiffImg.Dispose()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tiffImg = Nothing<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Try<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tiffPaths = New String(fileNames.Length) {}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim i As Integer = 0<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;While i &lt; fileNames.Length<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tiffPaths(i) = [String].Format(&quot;{0}\{1}.tiff&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Path.GetDirectoryName(fileNames(i)),<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Path.GetFileNameWithoutExtension(fileNames(i)))<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Save as individual tiff files.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Using tiffImg As Image = Image.FromFile(fileNames(i))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tiffImg.Save(tiffPaths(i), ImageFormat.Tiff)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Using<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End While<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return tiffPaths<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Using<br>
&nbsp; &nbsp;End Function<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Tagged Image File Format<br>
<a target="_blank" href="http://en.wikipedia.org/wiki/Tagged_Image_File_Format">http://en.wikipedia.org/wiki/Tagged_Image_File_Format</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
