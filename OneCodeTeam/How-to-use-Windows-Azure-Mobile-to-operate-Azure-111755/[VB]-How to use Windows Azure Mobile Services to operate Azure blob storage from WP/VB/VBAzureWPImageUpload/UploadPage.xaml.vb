Imports System.Windows.Media.Imaging
Imports Microsoft.Phone.Tasks
Imports Windows.Storage
Imports System.IO

Partial Public Class UploadPage
    Inherits PhoneApplicationPage

    Private m_chosenBitmapImage As BitmapImage
    Private m_uploadForm As UploadViewModel

    Public Property ChosenBitmapImage() As BitmapImage
        Get
            Return m_chosenBitmapImage
        End Get
        Set(value As BitmapImage)
            m_chosenBitmapImage = value
        End Set
    End Property
    Public Property UploadForm() As UploadViewModel
        Get
            Return m_uploadForm
        End Get
        Set(value As UploadViewModel)
            m_uploadForm = value
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
        m_chosenBitmapImage = New BitmapImage()

        m_uploadForm = New UploadViewModel()

        Me.DataContext = Me.UploadForm
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As RoutedEventArgs)
        Dim photoChooserTask As New PhotoChooserTask()
        AddHandler photoChooserTask.Completed, AddressOf photoChooserTask_Completed
        photoChooserTask.Show()
    End Sub

    Private Sub photoChooserTask_Completed(sender As Object, e As PhotoResult)
        If e.TaskResult = TaskResult.OK Then
            'Code to display the photo on the page in an image control named myImage.
            Dim bmp As New System.Windows.Media.Imaging.BitmapImage()
            bmp.SetSource(e.ChosenPhoto)

            imgSelected.Source = bmp
            m_chosenBitmapImage = bmp
        End If
    End Sub

    Private Async Sub btnUpload_Click(sender As Object, e As RoutedEventArgs)
        Dim applicationFolder As StorageFolder = ApplicationData.Current.LocalFolder
        Dim storageFile As StorageFile = Await applicationFolder.CreateFileAsync(Guid.NewGuid().ToString(), CreationCollisionOption.ReplaceExisting)

        Using stream As Stream = Await storageFile.OpenStreamForWriteAsync()
            Using mem As New MemoryStream()
                Dim wb As New WriteableBitmap(Me.m_chosenBitmapImage)
                wb.Invalidate()
                wb.SaveJpeg(mem, wb.PixelWidth, wb.PixelHeight, 0, 100)
                mem.Seek(0, System.IO.SeekOrigin.Begin)
                Dim content As Byte() = ReadFully(mem)
                Await stream.WriteAsync(content, 0, content.Length)
            End Using
        End Using
        If storageFile IsNot Nothing Then
            Me.UploadForm.PictureFile = storageFile
        End If

        If Me.IsValid(Me.UploadForm) Then
            btnUpload.IsEnabled = False
            btnSelect.IsEnabled = False
            Await PictureDataSource.UploadPicture(Me.UploadForm)
            btnUpload.IsEnabled = True
            btnSelect.IsEnabled = True
            NavigationService.Navigate(New Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute))
        End If
    End Sub

    ''' <summary>
    ''' Stream to byte.
    ''' </summary>
    ''' <param name="input"></param>
    ''' <returns></returns>
    Public Shared Function ReadFully(input As Stream) As Byte()
        Dim buffer As Byte() = New Byte(input.Length - 1) {}

        Using ms As New MemoryStream()
            Dim read As Integer
            While (InlineAssignHelper(read, input.Read(buffer, 0, buffer.Length))) > 0
                ms.Write(buffer, 0, read)
            End While
            Return ms.ToArray()
        End Using
    End Function

    Private Function IsValid(uploadForm As UploadViewModel) As Boolean
        If m_uploadForm.PictureFile Is Nothing Then

            MessageBox.Show("You must select a picture before uploading.")
            Return False
        End If
        If String.IsNullOrWhiteSpace(uploadForm.PictureName) Then
            MessageBox.Show("You must provide a picture title.")
            Return False
        End If
        Return True
    End Function
    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function
End Class
