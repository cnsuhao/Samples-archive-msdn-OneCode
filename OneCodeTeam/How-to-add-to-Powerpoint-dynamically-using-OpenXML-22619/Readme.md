# How to add images to Powerpoint dynamically using OpenXML
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Office
* Office Development
## Topics
* PowerPoint
* OpenXml
## IsPublished
* True
## ModifiedDate
* 2013-06-13 10:12:10
## Description

<h1><span style="">&nbsp;</span>How to add images to PowerPoint dynamically using Open XML (VBOpenXmlInsertImageToPPT)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The sample demonstrates how to add image to PowerPoint file automatically using Open XML SDK.</p>
<p class="MsoNormal">We first insert a new slide into a PowerPoint file (NOTE: the PowerPoint file should have at least one slide). Then, inserting an image into the new slide. If no error occurs, you can open the PowerPoint file, and you will see the image
 has been added into the last slide; otherwise, a message box will pop up to report the error.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">Before building the sample, please make sure you have installed
<a href="http://www.microsoft.com/en-us/download/details.aspx?id=5124">Open XML SDK 2.0 for Microsoft Office.</a></p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Step1. Open &quot;VBOpenXmlInsertImageToPPT.sln&quot; file and then click F5 to run the project. You will see the following Window Form:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84358/1/image.png" alt="" width="470" height="275" align="middle">
</span></p>
<p class="MsoNormal">Step2. Click &quot;Open&quot; button to select an existing PowerPoint file that must have at least a slide.</p>
<p class="MsoNormal">Step3. Click &quot;Select&quot; button to select an existing image on your machine.</p>
<p class="MsoNormal">Step4. Click &quot;Insert&quot; button to insert the image to the PowerPoint file. If Inserting image is successful, you will see a message:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84359/1/image.png" alt="" width="551" height="338" align="middle">
</span></p>
<p class="MsoNormal">Step5. Open source PowerPoint file and check whether the image has been added into the new slide.
</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84360/1/image.png" alt="" width="576" height="466" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">Step1. Create Windows Forms Application project via Visual Studio</p>
<p class="MsoNormal">Step2. Add the Open Xml references to the project. To reference the Open XML, right click the project and click &quot;Add Reference…&quot; button. In the Add Reference dialog, navigate to the .Net tab, find DocumentFormat.OpenXml and
 WindowsBase, and then click &quot;Ok&quot; button.</p>
<p class="MsoNormal">Step3. Import Open XML namespace in class.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Drawing
Imports DocumentFormat.OpenXml.Office2010.Drawing
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Presentation
Imports A = DocumentFormat.OpenXml.Drawing
Imports P = DocumentFormat.OpenXml.Presentation

</pre>
<pre id="codePreview" class="vb">
Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Drawing
Imports DocumentFormat.OpenXml.Office2010.Drawing
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Presentation
Imports A = DocumentFormat.OpenXml.Drawing
Imports P = DocumentFormat.OpenXml.Presentation

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal">Step4. Insert a new slide into PowerPoint.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
    ''' Insert a new Slide into PowerPoint
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;presentationPart&quot;&gt;Presentation Part&lt;/param&gt;
    ''' &lt;param name=&quot;layoutName&quot;&gt;Layout of the new Slide&lt;/param&gt;
    ''' &lt;returns&gt;Slide Instance&lt;/returns&gt;
    Public Function InsertSlide(presentationPart As PresentationPart, layoutName As String) As Slide
        Dim slideId As UInt32 = 256UI


        ' Get the Slide Id collection of the presentation document
        Dim slideIdList = presentationPart.Presentation.SlideIdList


        If slideIdList Is Nothing Then
            Throw New NullReferenceException(&quot;The number of slide is empty, please select a ppt with a slide at least again&quot;)
        End If


        slideId &#43;= Convert.ToUInt32(slideIdList.Count())


        ' Creates a Slide instance and adds its children.
        Dim slide As New Slide(New CommonSlideData(New ShapeTree()))


        Dim slidePart As SlidePart = presentationPart.AddNewPart(Of SlidePart)()
        slide.Save(slidePart)


        ' Get SlideMasterPart and SlideLayoutPart from the existing Presentation Part
        Dim slideMasterPart As SlideMasterPart = presentationPart.SlideMasterParts.First()
        Dim slideLayoutPart As SlideLayoutPart = slideMasterPart.SlideLayoutParts.SingleOrDefault(Function(sl) sl.SlideLayout.CommonSlideData.Name.Value.Equals(layoutName, StringComparison.OrdinalIgnoreCase))
        If slideLayoutPart Is Nothing Then
            Throw New Exception(&quot;The slide layout &quot; & layoutName & &quot; is not found&quot;)
        End If


        slidePart.AddPart(Of SlideLayoutPart)(slideLayoutPart)


        slidePart.Slide.CommonSlideData = DirectCast(slideMasterPart.SlideLayoutParts.SingleOrDefault(Function(sl) sl.SlideLayout.CommonSlideData.Name.Value.Equals(layoutName)).SlideLayout.CommonSlideData.Clone(), CommonSlideData)


        ' Create SlideId instance and Set property
        Dim newSlideId As SlideId = presentationPart.Presentation.SlideIdList.AppendChild(Of SlideId)(New SlideId())
        newSlideId.Id = slideId
        newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart)


        Return GetSlideByRelationShipId(presentationPart, newSlideId.RelationshipId)
    End Function


    ''' &lt;summary&gt;
    ''' Get Slide By RelationShip ID
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;presentationPart&quot;&gt;Presentation Part&lt;/param&gt;
    ''' &lt;param name=&quot;relationshipId&quot;&gt;Relationship ID&lt;/param&gt;
    ''' &lt;returns&gt;Slide Object&lt;/returns&gt;
    Private Shared Function GetSlideByRelationShipId(presentationPart As PresentationPart, relationshipId As StringValue) As Slide
        ' Get Slide object by Relationship ID
        Dim slidePart As SlidePart = TryCast(presentationPart.GetPartById(relationshipId), SlidePart)
        If slidePart IsNot Nothing Then
            Return slidePart.Slide
        Else
            Return Nothing
        End If
    End Function

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
    ''' Insert a new Slide into PowerPoint
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;presentationPart&quot;&gt;Presentation Part&lt;/param&gt;
    ''' &lt;param name=&quot;layoutName&quot;&gt;Layout of the new Slide&lt;/param&gt;
    ''' &lt;returns&gt;Slide Instance&lt;/returns&gt;
    Public Function InsertSlide(presentationPart As PresentationPart, layoutName As String) As Slide
        Dim slideId As UInt32 = 256UI


        ' Get the Slide Id collection of the presentation document
        Dim slideIdList = presentationPart.Presentation.SlideIdList


        If slideIdList Is Nothing Then
            Throw New NullReferenceException(&quot;The number of slide is empty, please select a ppt with a slide at least again&quot;)
        End If


        slideId &#43;= Convert.ToUInt32(slideIdList.Count())


        ' Creates a Slide instance and adds its children.
        Dim slide As New Slide(New CommonSlideData(New ShapeTree()))


        Dim slidePart As SlidePart = presentationPart.AddNewPart(Of SlidePart)()
        slide.Save(slidePart)


        ' Get SlideMasterPart and SlideLayoutPart from the existing Presentation Part
        Dim slideMasterPart As SlideMasterPart = presentationPart.SlideMasterParts.First()
        Dim slideLayoutPart As SlideLayoutPart = slideMasterPart.SlideLayoutParts.SingleOrDefault(Function(sl) sl.SlideLayout.CommonSlideData.Name.Value.Equals(layoutName, StringComparison.OrdinalIgnoreCase))
        If slideLayoutPart Is Nothing Then
            Throw New Exception(&quot;The slide layout &quot; & layoutName & &quot; is not found&quot;)
        End If


        slidePart.AddPart(Of SlideLayoutPart)(slideLayoutPart)


        slidePart.Slide.CommonSlideData = DirectCast(slideMasterPart.SlideLayoutParts.SingleOrDefault(Function(sl) sl.SlideLayout.CommonSlideData.Name.Value.Equals(layoutName)).SlideLayout.CommonSlideData.Clone(), CommonSlideData)


        ' Create SlideId instance and Set property
        Dim newSlideId As SlideId = presentationPart.Presentation.SlideIdList.AppendChild(Of SlideId)(New SlideId())
        newSlideId.Id = slideId
        newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart)


        Return GetSlideByRelationShipId(presentationPart, newSlideId.RelationshipId)
    End Function


    ''' &lt;summary&gt;
    ''' Get Slide By RelationShip ID
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;presentationPart&quot;&gt;Presentation Part&lt;/param&gt;
    ''' &lt;param name=&quot;relationshipId&quot;&gt;Relationship ID&lt;/param&gt;
    ''' &lt;returns&gt;Slide Object&lt;/returns&gt;
    Private Shared Function GetSlideByRelationShipId(presentationPart As PresentationPart, relationshipId As StringValue) As Slide
        ' Get Slide object by Relationship ID
        Dim slidePart As SlidePart = TryCast(presentationPart.GetPartById(relationshipId), SlidePart)
        If slidePart IsNot Nothing Then
            Return slidePart.Slide
        Else
            Return Nothing
        End If
    End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step5. Insert image into the added new slide.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
   ''' Insert Image into Slide
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;imagePath&quot;&gt;Image Path&lt;/param&gt;
   ''' &lt;param name=&quot;imageExt&quot;&gt;Image Extension&lt;/param&gt;
   Public Sub InsertImageInLastSlide(slide As Slide, imagePath As String, imageExt As String)
       ' Creates a Picture instance and adds its children.
       Dim picture As New P.Picture()
       Dim embedId As String = String.Empty
       embedId = &quot;rId&quot; & (slide.Elements(Of P.Picture)().Count() &#43; 915).ToString()
       Dim nonVisualPictureProperties As New P.NonVisualPictureProperties(New P.NonVisualDrawingProperties() With { _
        .Id = 4, _
        .Name = &quot;Picture 5&quot; _
       }, New P.NonVisualPictureDrawingProperties(New A.PictureLocks() With { _
        .NoChangeAspect = True _
       }), New ApplicationNonVisualDrawingProperties())


       Dim blipFill As New P.BlipFill()
       Dim blip As New Blip() With { _
        .Embed = embedId _
       }


       ' Creates a BlipExtensionList instance and adds its children
       Dim blipExtensionList As New BlipExtensionList()
       Dim blipExtension As New BlipExtension() With { _
        .Uri = &quot;{28A0092B-C50C-407E-A947-70E740481C1C}&quot; _
       }


       Dim useLocalDpi As New UseLocalDpi() With { _
        .Val = False _
       }
       useLocalDpi.AddNamespaceDeclaration(&quot;a14&quot;, &quot;http://schemas.microsoft.com/office/drawing/2010/main&quot;)


       blipExtension.Append(useLocalDpi)
       blipExtensionList.Append(blipExtension)
       blip.Append(blipExtensionList)


       Dim stretch As New Stretch()
       Dim fillRectangle As New FillRectangle()
       stretch.Append(fillRectangle)


       blipFill.Append(blip)
       blipFill.Append(stretch)


       ' Creates a ShapeProperties instance and adds its children.
       Dim shapeProperties As New P.ShapeProperties()


       Dim transform2D As New A.Transform2D()
       Dim offset As New A.Offset() With { _
         .X = 457200L, _
         .Y = 1524000L _
       }
       Dim extents As New A.Extents() With { _
         .Cx = 8229600L, _
         .Cy = 5029200L _
       }


       transform2D.Append(offset)
       transform2D.Append(extents)


       Dim presetGeometry As New A.PresetGeometry() With { _
        .Preset = A.ShapeTypeValues.Rectangle _
       }
       Dim adjustValueList As New A.AdjustValueList()


       presetGeometry.Append(adjustValueList)


       shapeProperties.Append(transform2D)
       shapeProperties.Append(presetGeometry)


       picture.Append(nonVisualPictureProperties)
       picture.Append(blipFill)
       picture.Append(shapeProperties)


       slide.CommonSlideData.ShapeTree.AppendChild(picture)


       ' Generates content of imagePart.
       Dim imagePart As ImagePart = slide.SlidePart.AddNewPart(Of ImagePart)(imageExt, embedId)
       Dim fileStream As New FileStream(imagePath, FileMode.Open)
       imagePart.FeedData(fileStream)
       fileStream.Close()
   End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
   ''' Insert Image into Slide
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;imagePath&quot;&gt;Image Path&lt;/param&gt;
   ''' &lt;param name=&quot;imageExt&quot;&gt;Image Extension&lt;/param&gt;
   Public Sub InsertImageInLastSlide(slide As Slide, imagePath As String, imageExt As String)
       ' Creates a Picture instance and adds its children.
       Dim picture As New P.Picture()
       Dim embedId As String = String.Empty
       embedId = &quot;rId&quot; & (slide.Elements(Of P.Picture)().Count() &#43; 915).ToString()
       Dim nonVisualPictureProperties As New P.NonVisualPictureProperties(New P.NonVisualDrawingProperties() With { _
        .Id = 4, _
        .Name = &quot;Picture 5&quot; _
       }, New P.NonVisualPictureDrawingProperties(New A.PictureLocks() With { _
        .NoChangeAspect = True _
       }), New ApplicationNonVisualDrawingProperties())


       Dim blipFill As New P.BlipFill()
       Dim blip As New Blip() With { _
        .Embed = embedId _
       }


       ' Creates a BlipExtensionList instance and adds its children
       Dim blipExtensionList As New BlipExtensionList()
       Dim blipExtension As New BlipExtension() With { _
        .Uri = &quot;{28A0092B-C50C-407E-A947-70E740481C1C}&quot; _
       }


       Dim useLocalDpi As New UseLocalDpi() With { _
        .Val = False _
       }
       useLocalDpi.AddNamespaceDeclaration(&quot;a14&quot;, &quot;http://schemas.microsoft.com/office/drawing/2010/main&quot;)


       blipExtension.Append(useLocalDpi)
       blipExtensionList.Append(blipExtension)
       blip.Append(blipExtensionList)


       Dim stretch As New Stretch()
       Dim fillRectangle As New FillRectangle()
       stretch.Append(fillRectangle)


       blipFill.Append(blip)
       blipFill.Append(stretch)


       ' Creates a ShapeProperties instance and adds its children.
       Dim shapeProperties As New P.ShapeProperties()


       Dim transform2D As New A.Transform2D()
       Dim offset As New A.Offset() With { _
         .X = 457200L, _
         .Y = 1524000L _
       }
       Dim extents As New A.Extents() With { _
         .Cx = 8229600L, _
         .Cy = 5029200L _
       }


       transform2D.Append(offset)
       transform2D.Append(extents)


       Dim presetGeometry As New A.PresetGeometry() With { _
        .Preset = A.ShapeTypeValues.Rectangle _
       }
       Dim adjustValueList As New A.AdjustValueList()


       presetGeometry.Append(adjustValueList)


       shapeProperties.Append(transform2D)
       shapeProperties.Append(presetGeometry)


       picture.Append(nonVisualPictureProperties)
       picture.Append(blipFill)
       picture.Append(shapeProperties)


       slide.CommonSlideData.ShapeTree.AppendChild(picture)


       ' Generates content of imagePart.
       Dim imagePart As ImagePart = slide.SlidePart.AddNewPart(Of ImagePart)(imageExt, embedId)
       Dim fileStream As New FileStream(imagePath, FileMode.Open)
       imagePart.FeedData(fileStream)
       fileStream.Close()
   End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step6. Handle the events of the button in Main Form</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
    ''' Handle Click events of Open button
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
    ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
    Private Sub btnOpenPPt_Click(sender As System.Object, e As System.EventArgs) Handles btnOpenPPt.Click
        Using dialog As New OpenFileDialog()
            dialog.Filter = &quot;PowerPoint document (*.pptx)|*.pptx&quot;
            dialog.InitialDirectory = Environment.CurrentDirectory


            ' Retore the directory before closing
            dialog.RestoreDirectory = True
            If dialog.ShowDialog() = DialogResult.OK Then
                Me.txbPPtPath.Text = dialog.FileName
            End If
        End Using


    End Sub


    ''' &lt;summary&gt;
    ''' Handle Click events of Select button
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
    ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
    Private Sub btnSelectImg_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectImg.Click
        Using dialog As New OpenFileDialog()
            dialog.Filter = &quot;Pictures(*.jpg;*.png)|*.jpg;*.png&quot;
            dialog.InitialDirectory = Environment.CurrentDirectory


            ' Retore the directory before closing
            dialog.RestoreDirectory = True
            If dialog.ShowDialog() = DialogResult.OK Then
                Me.txbImagePath.Text = dialog.FileName
            End If
        End Using


    End Sub


    ''' &lt;summary&gt;
    ''' Handle client event of Insert button 
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
    ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
    Private Sub btnInsert_Click(sender As System.Object, e As System.EventArgs) Handles btnInsert.Click
        Dim pptFilePath As String = txbPPtPath.Text.Trim()
        Dim imagefilePath As String = txbImagePath.Text.Trim()
        Dim imageExt As String = Path.GetExtension(imagefilePath)
        If imageExt.Equals(&quot;jpg&quot;, StringComparison.OrdinalIgnoreCase) Then
            imageExt = &quot;image/jpeg&quot;
        Else
            imageExt = &quot;image/png&quot;
        End If
        Dim condition As Boolean = String.IsNullOrEmpty(pptFilePath) OrElse Not File.Exists(pptFilePath) OrElse String.IsNullOrEmpty(imagefilePath) OrElse Not File.Exists(imagefilePath)
        If condition Then
            MessageBox.Show(&quot;The PowerPoint or iamge file is invalid,Please select an existing file again&quot;, &quot;Error&quot;, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If


        Try
            Using presentationDocument__1 As PresentationDocument = PresentationDocument.Open(pptFilePath, True)
                ' Get the presentation Part of the presentation document
                Dim presentationPart As PresentationPart = presentationDocument__1.PresentationPart
                Dim slide As Slide = New InsertImage().InsertSlide(presentationPart, &quot;Title Only&quot;)
                Dim insertImage As New InsertImage()
                insertImage.InsertImageInLastSlide(slide, imagefilePath, imageExt)
                slide.Save()
                presentationDocument__1.PresentationPart.Presentation.Save()
                MessageBox.Show(&quot;Insert Image Successfully,you can check with opening PowerPoint&quot;)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, &quot;Error&quot;, MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try


    End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
    ''' Handle Click events of Open button
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
    ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
    Private Sub btnOpenPPt_Click(sender As System.Object, e As System.EventArgs) Handles btnOpenPPt.Click
        Using dialog As New OpenFileDialog()
            dialog.Filter = &quot;PowerPoint document (*.pptx)|*.pptx&quot;
            dialog.InitialDirectory = Environment.CurrentDirectory


            ' Retore the directory before closing
            dialog.RestoreDirectory = True
            If dialog.ShowDialog() = DialogResult.OK Then
                Me.txbPPtPath.Text = dialog.FileName
            End If
        End Using


    End Sub


    ''' &lt;summary&gt;
    ''' Handle Click events of Select button
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
    ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
    Private Sub btnSelectImg_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectImg.Click
        Using dialog As New OpenFileDialog()
            dialog.Filter = &quot;Pictures(*.jpg;*.png)|*.jpg;*.png&quot;
            dialog.InitialDirectory = Environment.CurrentDirectory


            ' Retore the directory before closing
            dialog.RestoreDirectory = True
            If dialog.ShowDialog() = DialogResult.OK Then
                Me.txbImagePath.Text = dialog.FileName
            End If
        End Using


    End Sub


    ''' &lt;summary&gt;
    ''' Handle client event of Insert button 
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
    ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
    Private Sub btnInsert_Click(sender As System.Object, e As System.EventArgs) Handles btnInsert.Click
        Dim pptFilePath As String = txbPPtPath.Text.Trim()
        Dim imagefilePath As String = txbImagePath.Text.Trim()
        Dim imageExt As String = Path.GetExtension(imagefilePath)
        If imageExt.Equals(&quot;jpg&quot;, StringComparison.OrdinalIgnoreCase) Then
            imageExt = &quot;image/jpeg&quot;
        Else
            imageExt = &quot;image/png&quot;
        End If
        Dim condition As Boolean = String.IsNullOrEmpty(pptFilePath) OrElse Not File.Exists(pptFilePath) OrElse String.IsNullOrEmpty(imagefilePath) OrElse Not File.Exists(imagefilePath)
        If condition Then
            MessageBox.Show(&quot;The PowerPoint or iamge file is invalid,Please select an existing file again&quot;, &quot;Error&quot;, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If


        Try
            Using presentationDocument__1 As PresentationDocument = PresentationDocument.Open(pptFilePath, True)
                ' Get the presentation Part of the presentation document
                Dim presentationPart As PresentationPart = presentationDocument__1.PresentationPart
                Dim slide As Slide = New InsertImage().InsertSlide(presentationPart, &quot;Title Only&quot;)
                Dim insertImage As New InsertImage()
                insertImage.InsertImageInLastSlide(slide, imagefilePath, imageExt)
                slide.Save()
                presentationDocument__1.PresentationPart.Presentation.Save()
                MessageBox.Show(&quot;Insert Image Successfully,you can check with opening PowerPoint&quot;)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, &quot;Error&quot;, MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try


    End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal">DocumentFormat.OpenXml.Presentation Namespace:</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/office/documentformat.openxml.presentation(v=office.14).aspx">http://msdn.microsoft.com/en-us/library/office/documentformat.openxml.presentation(v=office.14).aspx</a></p>
<p class="MsoNormal">Open XML for Office developers:</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/office/bb265236">http://msdn.microsoft.com/en-us/office/bb265236</a></p>
<p class="MsoNormal">Picture Class</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/cc865819.aspx">http://msdn.microsoft.com/en-us/library/cc865819.aspx</a>
</p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
