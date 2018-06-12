'***************************** Module Header ******************************\
' Module Name:  InsertImage.vb
' Project:      VBOpenXmlInsertImageToPPT
' Copyright(c)  Microsoft Corporation.
' 
' The Class is used to Insert Image into PowerPoint using Open XML SDK.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.IO
Imports System.Linq
Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Drawing
Imports DocumentFormat.OpenXml.Office2010.Drawing
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Presentation
Imports A = DocumentFormat.OpenXml.Drawing
Imports P = DocumentFormat.OpenXml.Presentation
Public Class InsertImage
    ''' <summary>
    ''' Insert a new Slide into PowerPoint
    ''' </summary>
    ''' <param name="presentationPart">Presentation Part</param>
    ''' <param name="layoutName">Layout of the new Slide</param>
    ''' <returns>Slide Instance</returns>
    Public Function InsertSlide(presentationPart As PresentationPart, layoutName As String) As Slide
        Dim slideId As UInt32 = 256UI

        ' Get the Slide Id collection of the presentation document
        Dim slideIdList = presentationPart.Presentation.SlideIdList

        If slideIdList Is Nothing Then
            Throw New NullReferenceException("The number of slide is empty, please select a ppt with a slide at least again")
        End If

        slideId += Convert.ToUInt32(slideIdList.Count())

        ' Creates a Slide instance and adds its children.
        Dim slide As New Slide(New CommonSlideData(New ShapeTree()))

        Dim slidePart As SlidePart = presentationPart.AddNewPart(Of SlidePart)()
        slide.Save(slidePart)

        ' Get SlideMasterPart and SlideLayoutPart from the existing Presentation Part
        Dim slideMasterPart As SlideMasterPart = presentationPart.SlideMasterParts.First()
        Dim slideLayoutPart As SlideLayoutPart = slideMasterPart.SlideLayoutParts.SingleOrDefault(Function(sl) sl.SlideLayout.CommonSlideData.Name.Value.Equals(layoutName, StringComparison.OrdinalIgnoreCase))
        If slideLayoutPart Is Nothing Then
            Throw New Exception("The slide layout " & layoutName & " is not found")
        End If

        slidePart.AddPart(Of SlideLayoutPart)(slideLayoutPart)

        slidePart.Slide.CommonSlideData = DirectCast(slideMasterPart.SlideLayoutParts.SingleOrDefault(Function(sl) sl.SlideLayout.CommonSlideData.Name.Value.Equals(layoutName)).SlideLayout.CommonSlideData.Clone(), CommonSlideData)

        ' Create SlideId instance and Set property
        Dim newSlideId As SlideId = presentationPart.Presentation.SlideIdList.AppendChild(Of SlideId)(New SlideId())
        newSlideId.Id = slideId
        newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart)

        Return GetSlideByRelationShipId(presentationPart, newSlideId.RelationshipId)
    End Function

    ''' <summary>
    ''' Get Slide By RelationShip ID
    ''' </summary>
    ''' <param name="presentationPart">Presentation Part</param>
    ''' <param name="relationshipId">Relationship ID</param>
    ''' <returns>Slide Object</returns>
    Private Shared Function GetSlideByRelationShipId(presentationPart As PresentationPart, relationshipId As StringValue) As Slide
        ' Get Slide object by Relationship ID
        Dim slidePart As SlidePart = TryCast(presentationPart.GetPartById(relationshipId), SlidePart)
        If slidePart IsNot Nothing Then
            Return slidePart.Slide
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' Insert Image into Slide
    ''' </summary>
    ''' <param name="imagePath">Image Path</param>
    ''' <param name="imageExt">Image Extension</param>
    Public Sub InsertImageInLastSlide(slide As Slide, imagePath As String, imageExt As String)
        ' Creates a Picture instance and adds its children.
        Dim picture As New P.Picture()
        Dim embedId As String = String.Empty
        embedId = "rId" & (slide.Elements(Of P.Picture)().Count() + 915).ToString()
        Dim nonVisualPictureProperties As New P.NonVisualPictureProperties(New P.NonVisualDrawingProperties() With { _
         .Id = 4, _
         .Name = "Picture 5" _
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
         .Uri = "{28A0092B-C50C-407E-A947-70E740481C1C}" _
        }

        Dim useLocalDpi As New UseLocalDpi() With { _
         .Val = False _
        }
        useLocalDpi.AddNamespaceDeclaration("a14", "http://schemas.microsoft.com/office/drawing/2010/main")

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

End Class
