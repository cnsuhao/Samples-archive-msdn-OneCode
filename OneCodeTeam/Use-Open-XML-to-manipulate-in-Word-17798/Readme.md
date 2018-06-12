# Use Open XML to manipulate images in Word (CSManipulateImagesInWordDocument)
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
* 2012-07-22 06:52:34
## Description
================================================================================<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Windows APPLICATION: CSManipulateImagesInWordDocument &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
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
Step3. Run CSManipulateImagesInWordDocument.exe.<br>
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
&nbsp; &nbsp; &nbsp; &nbsp; public IEnumerable&lt;Blip&gt; GetAllImages()<br>
&nbsp; &nbsp; &nbsp; &nbsp; {<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; // Get the drawing elements in the document.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; var drawingElements = from run in Document.MainDocumentPart.Document.Descendants&lt;DocumentFormat.OpenXml.Wordprocessing.Run&gt;()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; where run.Descendants&lt;Drawing&gt;().Count() != 0<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; select run.Descendants&lt;Drawing&gt;().First();<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; // Get the blip elements in the drawing elements.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; var blipElements = from drawing in drawingElements<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;where drawing.Descendants&lt;Blip&gt;().Count() &gt; 0<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;select drawing.Descendants&lt;Blip&gt;().First(); &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; return blipElements;<br>
&nbsp; &nbsp; &nbsp; &nbsp; }<br>
<br>
B. To delete the image, we can delete the Drawing element that contains the Blip element.<br>
&nbsp; &nbsp; &nbsp; &nbsp;public void DeleteImage(Blip blipElement)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;OpenXmlElement parent = blipElement.Parent;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;while (parent != null && !(parent is DocumentFormat.OpenXml.Wordprocessing.Drawing))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;parent = parent.Parent;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (parent != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Drawing drawing = parent as Drawing;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;drawing.Parent.RemoveChild&lt;Drawing&gt;(drawing);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Raise the ImagesChanged event.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.OnImagesChanged();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
<br>
C. To replace an image in a document, we have to add an ImagePart to the document first,<br>
&nbsp; and then edit the Blip element to refer to the new ImagePart.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public void ReplaceImage(Blip blipElement, FileInfo newImg)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string rid = AddImagePart(newImg);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;blipElement.Embed.Value = rid;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.OnImagesChanged();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;string AddImagePart(FileInfo newImg)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ImagePartType type = ImagePartType.Bmp ;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;switch(newImg.Extension.ToLower())<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;case &quot;.jpeg&quot;:<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;case &quot;.jpg&quot;:<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;type = ImagePartType.Jpeg;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;break;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;case &quot;.png&quot;:<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;type = ImagePartType.Png;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;break;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;default:<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;type = ImagePartType.Bmp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;break;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ImagePart newImgPart = Document.MainDocumentPart.AddImagePart(type);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;using (FileStream stream = newImg.OpenRead())<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;newImgPart.FeedData(stream);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string rId = Document.MainDocumentPart.GetIdOfPart(newImgPart);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return rId;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
D. Because we have set the image as the Image property of the PictureBox, we can just use<br>
&nbsp; the Image.Save method to export the image to local file.<br>
<br>
&nbsp; &nbsp;picView.Image.Save(dialog.FileName, ImageFormat.Jpeg);<br>
<br>
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
