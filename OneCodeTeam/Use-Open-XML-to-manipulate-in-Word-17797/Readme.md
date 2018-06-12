# Use Open XML to manipulate images in Word (VBManipulateImagesInWordDocument)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* Office
## Topics
* Image
* Open XML
## IsPublished
* True
## ModifiedDate
* 2012-07-22 06:52:19
## Description
================================================================================<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Windows APPLICATION: VBManipulateImagesInWordDocument &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
===============================================================================<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Summary:<br>
The sample demonstrates how to export, delete or replace the images in a word document<br>
using Open XML SDK. <br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Prerequisite<br>
<br>
Open XML SDK 2.0<br>
<br>
You can download it in the following link:<br>
http://www.microsoft.com/downloads/en/details.aspx?FamilyId=C6E744E5-36E9-45F5-8D8C-331DF206E0D0&displaylang=en<br>
<br>
<br>
////////////////////////////////////////////////////////////////////////////////<br>
Demo:<br>
<br>
Step1. Open this project in &nbsp;Visual Studio 2008. <br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
Step2. Build the solution. <br>
<br>
Step3. Run VBManipulateImagesInWordDocument.exe.<br>
<br>
Step4. Click &quot;Open the word doc&quot; button, and in the OpenFileDialog , select a Word 2007/2010<br>
&nbsp; &nbsp; &nbsp; document(*.docx file). The listbox will show all images reference ID.<br>
<br>
Step5. Click an item in the listbox, you will see the image in the right panel.<br>
<br>
Step6. Click the &quot;Export&quot; button, it will show a SaveFileDialog and you can save it
<br>
&nbsp; &nbsp; &nbsp; to a local file.<br>
<br>
Step7. Click the &quot;Delete&quot; button, it will show an alert. If you confirm it, this application<br>
&nbsp; &nbsp; &nbsp; will delete the image. Close this application, and open the document in Word, you
<br>
&nbsp; &nbsp; &nbsp; will find that the image has been deleted.<br>
<br>
Step7. Run Step3, Step4 and Step5 again. Click the &quot;Replace&quot; button, it will show an<br>
&nbsp; &nbsp; &nbsp; OpenFileDialog. Choose a local image and confirm the alert, this application<br>
&nbsp; &nbsp; &nbsp; will replace the image. Close this application, and open the document in Word, you
<br>
&nbsp; &nbsp; &nbsp; will find that the image has been replaced.<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Code Logic:<br>
<br>
The image data in a document are stored as a ImagePart, and the Blip element<br>
in a Drawing element will refers to the ImagePart, like following structure<br>
<br>
&lt;w:drawing&gt;<br>
&nbsp;&lt;wp:inline&gt; &nbsp;<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;pic:pic&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;pic:blipFill&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;a14:useLocalDpi val=&quot;0&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/pic:blipFill&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/pic:pic&gt;<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp;<br>
&nbsp;&lt;/wp:inline&gt;<br>
&lt;/w:drawing&gt;<br>
<br>
A. To list all images in the document, we can get all Drawing elements first, and then get the Blip<br>
&nbsp; element in the Drawing element.<br>
<br>
&nbsp; &nbsp; &nbsp; Public Function GetAllImages() As IEnumerable(Of Blip)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ' Get the drawing elements in the document.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Dim drawingElements = From run In Document.MainDocumentPart.Document.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Descendants(Of DocumentFormat.OpenXml.Wordprocessing.Run)()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Where run.Descendants(Of Drawing)().Count() &lt;&gt; 0<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Select run.Descendants(Of Drawing)().First()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ' Get the blip elements in the drawing elements.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Dim blipElements = From drawing In drawingElements<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Where drawing.Descendants(Of Blip)().Count() &gt; 0<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Select drawing.Descendants(Of Blip)().First()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Return blipElements<br>
&nbsp; &nbsp; &nbsp;End Function<br>
<br>
B. To delete the image, we can delete the Drawing element that contains the Blip element.<br>
&nbsp; &nbsp; &nbsp;Public Sub DeleteImage(ByVal blipElement As Blip)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim parent As OpenXmlElement = blipElement.Parent<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Do While parent IsNot Nothing _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AndAlso Not (TypeOf parent Is DocumentFormat.OpenXml.Wordprocessing.Drawing)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;parent = parent.Parent<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Loop<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If parent IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim drawing_Renamed As Drawing = TryCast(parent, Drawing)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;drawing_Renamed.Parent.RemoveChild(Of Drawing)(drawing_Renamed)<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Raise the ImagesChanged event.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.OnImagesChanged()<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp;End Sub<br>
<br>
<br>
C. To replace an image in a document, we have to add an ImagePart to the document first,<br>
&nbsp; and then edit the Blip element to refer to the new ImagePart.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Sub ReplaceImage(ByVal blipElement As Blip, ByVal newImg As FileInfo)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim rid As String = AddImagePart(newImg)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blipElement.Embed.Value = rid<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Me.OnImagesChanged()<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Private Function AddImagePart(ByVal newImg As FileInfo) As String<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim type As ImagePartType = ImagePartType.Bmp<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Select Case newImg.Extension.ToLower()<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Case &quot;.jpeg&quot;, &quot;.jpg&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;type = ImagePartType.Jpeg<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Case &quot;.png&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;type = ImagePartType.Png<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Case Else<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;type = ImagePartType.Bmp<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End Select<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim newImgPart As ImagePart = Document.MainDocumentPart.AddImagePart(type)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Using stream As FileStream = newImg.OpenRead()<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newImgPart.FeedData(stream)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End Using<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim rId As String = Document.MainDocumentPart.GetIdOfPart(newImgPart)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Return rId<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End Function<br>
<br>
D. Because we have set the image as the Image property of the PictureBox, we can just use<br>
&nbsp; the Image.Save method to export the image to local file.<br>
<br>
&nbsp; &nbsp;picView.Image.Save(dialog.FileName, ImageFormat.Jpeg)<br>
/////////////////////////////////////////////////////////////////////////////<br>
References:<br>
<br>
Welcome to the Open XML SDK 2.0 for Microsoft Office<br>
http://msdn.microsoft.com/en-us/library/bb448854.aspx<br>
<br>
WordprocessingDocument Class<br>
http://msdn.microsoft.com/en-us/library/documentformat.openxml.packaging.wordprocessingdocument.aspx<br>
<br>
ImagePart Class<br>
http://msdn.microsoft.com/en-us/library/documentformat.openxml.packaging.imagepart.aspx<br>
/////////////////////////////////////////////////////////////////////////////<br>
