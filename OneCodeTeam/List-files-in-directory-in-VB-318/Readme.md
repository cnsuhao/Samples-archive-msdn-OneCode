# List files in directory in VB (VBListFilesInDirectory)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* Windows SDK
## Topics
* File System
## IsPublished
* True
## ModifiedDate
* 2012-03-01 11:54:18
## Description

<h1>List files in directory in <span style="">VB</span> (<span class="SpellE"><span style="">VB</span>ListFilesInDirectory</span>)<span style="">
</span></h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span style="">The </span><span style="">VB</span><span style="">ListFilesInDirectory project demonstrates how to implement an IEnumerable&lt;string&gt; that utilizes the Win32 File Management functions to enable application to get files
 and sub-directories in a specified directory one item a time.</span><span style="">
</span></p>
<p class="MsoNormal"><span style="">The FileEnumerator class in this sample project solved a common problem inthe System.IO.Directory.GetFiles method - if a directory contains a large</span><span style="">
</span><span style="">number of items, this it will take a long time for this method to return</span><span style="">
</span><span style="">because it will enumerate all the files and put the names in an array as</span><span style="">
</span><span style="">an entire operation. This will also cause a very high memory load if the</span><span style="">
</span><span style="">array gets huge.</span><span style=""> </span></p>
<p class="MsoNormal"><span style="">The FileEnumerator class works differently. It returns one file at a time.</span><span style="">
</span><span style="">And the enumeration can be canceled or reset at anytime.</span><span style="">
</span></p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Press F5 to run this application. </span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Type the folder and search pattern, then click the List button, the files which match the pattern will be displayed in the list box.
</span></p>
<p class="MsoListParagraphCxSpLast"><span style=""><img src="/site/view/file/53331/1/image.png" alt="" width="530" height="424" align="middle">
</span><span style=""></span></p>
<h2>Using the Code<span style=""> </span></h2>
<p class="MsoListParagraph" style="margin-left:54.0pt"><b style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style=""><span style="">Define Win32 P/Invoke methods.
</span></b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
''' Win32 Native P/Invoke
''' &lt;/summary&gt;
Friend Module NativeMethods
    ''' &lt;summary&gt;
    ''' Searches a directory for a file or subdirectory with a name that matches
    ''' a specific name (or partial name if wildcards are used).
    ''' http://msdn.microsoft.com/en-us/library/windows/desktop/aa364418(v=vs.85).aspx
    ''' &lt;/summary&gt;
    &lt;DllImport(&quot;kernel32.dll&quot;, CharSet:=CharSet.Auto, SetLastError:=True)&gt; _
    Friend Function FindFirstFile( _
        ByVal fileName As String, _
        &lt;[In](), Out()&gt; ByVal data As WIN32_FIND_DATA) As SafeFindHandle
    End Function


    ''' &lt;summary&gt;
    ''' Continues a file search from a previous call to the FindFirstFile or 
    ''' FindFirstFileEx function.
    ''' http://msdn.microsoft.com/en-us/library/windows/desktop/aa364428(v=VS.85).aspx
    ''' &lt;/summary&gt;
    &lt;DllImport(&quot;kernel32.dll&quot;, CharSet:=CharSet.Auto, SetLastError:=True)&gt; _
    Friend Function FindNextFile( _
        ByVal hndFindFile As SafeFindHandle, _
        &lt;[In](), Out(), MarshalAs(UnmanagedType.LPStruct)&gt; ByVal _
         lpFindFileData As WIN32_FIND_DATA) As Boolean
    End Function


    ''' &lt;summary&gt;
    ''' Closes a file search handle opened by the FindFirstFile, FindFirstFileEx, 
    ''' FindFirstFileNameW, FindFirstFileNameTransactedW, FindFirstFileTransacted,
    ''' FindFirstStreamTransactedW, or FindFirstStreamW functions.
    ''' http://msdn.microsoft.com/en-us/library/windows/desktop/aa364413(v=VS.85).aspx
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;handle&quot;&gt;&lt;/param&gt;
    ''' &lt;returns&gt;&lt;/returns&gt;
    ''' &lt;remarks&gt;&lt;/remarks&gt;
    &lt;ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), DllImport(&quot;kernel32.dll&quot;)&gt; _
    Friend Function FindClose(ByVal handle As IntPtr) As Boolean
    End Function


    Friend Const ERROR_SUCCESS As Integer = 0
    Friend Const ERROR_NO_MORE_FILES As Integer = 18
    Friend Const ERROR_FILE_NOT_FOUND As Integer = 2
    Friend Const FILE_ATTRIBUTE_DIRECTORY As Integer = &H10
End Module

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
''' Win32 Native P/Invoke
''' &lt;/summary&gt;
Friend Module NativeMethods
    ''' &lt;summary&gt;
    ''' Searches a directory for a file or subdirectory with a name that matches
    ''' a specific name (or partial name if wildcards are used).
    ''' http://msdn.microsoft.com/en-us/library/windows/desktop/aa364418(v=vs.85).aspx
    ''' &lt;/summary&gt;
    &lt;DllImport(&quot;kernel32.dll&quot;, CharSet:=CharSet.Auto, SetLastError:=True)&gt; _
    Friend Function FindFirstFile( _
        ByVal fileName As String, _
        &lt;[In](), Out()&gt; ByVal data As WIN32_FIND_DATA) As SafeFindHandle
    End Function


    ''' &lt;summary&gt;
    ''' Continues a file search from a previous call to the FindFirstFile or 
    ''' FindFirstFileEx function.
    ''' http://msdn.microsoft.com/en-us/library/windows/desktop/aa364428(v=VS.85).aspx
    ''' &lt;/summary&gt;
    &lt;DllImport(&quot;kernel32.dll&quot;, CharSet:=CharSet.Auto, SetLastError:=True)&gt; _
    Friend Function FindNextFile( _
        ByVal hndFindFile As SafeFindHandle, _
        &lt;[In](), Out(), MarshalAs(UnmanagedType.LPStruct)&gt; ByVal _
         lpFindFileData As WIN32_FIND_DATA) As Boolean
    End Function


    ''' &lt;summary&gt;
    ''' Closes a file search handle opened by the FindFirstFile, FindFirstFileEx, 
    ''' FindFirstFileNameW, FindFirstFileNameTransactedW, FindFirstFileTransacted,
    ''' FindFirstStreamTransactedW, or FindFirstStreamW functions.
    ''' http://msdn.microsoft.com/en-us/library/windows/desktop/aa364413(v=VS.85).aspx
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;handle&quot;&gt;&lt;/param&gt;
    ''' &lt;returns&gt;&lt;/returns&gt;
    ''' &lt;remarks&gt;&lt;/remarks&gt;
    &lt;ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), DllImport(&quot;kernel32.dll&quot;)&gt; _
    Friend Function FindClose(ByVal handle As IntPtr) As Boolean
    End Function


    Friend Const ERROR_SUCCESS As Integer = 0
    Friend Const ERROR_NO_MORE_FILES As Integer = 18
    Friend Const ERROR_FILE_NOT_FOUND As Integer = 2
    Friend Const FILE_ATTRIBUTE_DIRECTORY As Integer = &H10
End Module

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:54.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:54.0pt"><b style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style=""><span style="">Design <span style="">t</span></span><span style="">he FileEnumerator class</span></b><b style=""><span style="">
</span></b></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:54.0pt"><span style="">This class
</span><span style="">returns one file at a time.</span><span style=""> </span><span style="">And the enumeration can be canceled or reset at anytime.</span><span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Class DirectoryEnumerator
    Implements IEnumerable(Of String)


#Region &quot;The Enumerator&quot;
    Public Structure Enumerator
        Implements IEnumerator(Of String)


#Region &quot;Private members&quot;


        Private hFindFile As SafeFindHandle
        Private m_current As String
        Private m_pattern As String
        Private m_mode As Mode


#End Region


#Region &quot;Constructor&quot;


        Friend Sub New(ByVal pattern As String, ByVal mode As Mode)
            Me.m_pattern = pattern
            Me.m_current = Nothing
            Me.hFindFile = Nothing
            Me.m_mode = mode
        End Sub


#End Region


#Region &quot;IEnumerator(Of String) Members&quot;


        Public ReadOnly Property Current() As String Implements IEnumerator(Of String).Current
            Get
                Return Me.m_current
            End Get
        End Property


#End Region


#Region &quot;IDisposable Members&quot;


        Public Sub Dispose() Implements IDisposable.Dispose
            If Me.hFindFile IsNot Nothing Then
                Me.hFindFile.Dispose()
            End If
        End Sub


#End Region


#Region &quot;IEnumerator Members&quot;


        Public ReadOnly Property CurrentObject() As Object Implements IEnumerator.Current
            Get
                Return Me.m_current
            End Get
        End Property


        Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
            If Me.hFindFile Is Nothing Then
                Return FindFirst()
            Else
                Return FindNext()
            End If
        End Function


        Public Sub Reset() Implements System.Collections.IEnumerator.Reset
            If Me.hFindFile IsNot Nothing Then
                Me.hFindFile.Close()
                Me.hFindFile = Nothing
            End If
        End Sub


#End Region


#Region &quot;Supporting Methods&quot;


        ''' &lt;summary&gt;
        ''' Find the first match.
        ''' &lt;/summary&gt;
        ''' &lt;returns&gt;&lt;/returns&gt;
        Private Function FindFirst() As Boolean
            Dim fd As New WIN32_FIND_DATA


            Me.hFindFile = NativeMethods.FindFirstFile(Me.m_pattern, fd)


            If Me.hFindFile.IsInvalid Then
                ' Got an invalid find handle, get the error code
                Dim code As Integer = Marshal.GetLastWin32Error()


                If code = NativeMethods.ERROR_FILE_NOT_FOUND Then
                    ' file not found, just return false
                    Return False
                End If


                ' other errors, throw exception
                Throw New Win32Exception(code)
            End If


            If Not AttributesMatchMode(fd.dwFileAttributes) Then
                ' if the file does not meet the match mode,
                ' go find the next match.
                Return FindNext()
            End If


            Me.m_current = fd.cFileName
            Return True
        End Function


        Private Function FindNext() As Boolean
            Dim fd As New WIN32_FIND_DATA


            While NativeMethods.FindNextFile(Me.hFindFile, fd)
                If Not AttributesMatchMode(fd.dwFileAttributes) Then
                    ' if the file does not meet the match mode,
                    ' go find the next match.
                    Continue While
                End If


                ' found a match, return.
                Me.m_current = fd.cFileName
                Return True
            End While


            Dim code As Integer = Marshal.GetLastWin32Error()


            If code = NativeMethods.ERROR_NO_MORE_FILES Then
                ' no more files, return false.
                Return False
            End If


            ' other errors, throw exception.
            Throw New Win32Exception(code)
        End Function


        Private Function AttributesMatchMode(ByVal fileAttributes As Integer) As Boolean
            Dim isDir As Boolean = _
                ((fileAttributes And NativeMethods.FILE_ATTRIBUTE_DIRECTORY) = NativeMethods.FILE_ATTRIBUTE_DIRECTORY)


            Return (isDir AndAlso ((Me.m_mode And Mode.Directory) = Mode.Directory)) OrElse _
                    (Not isDir AndAlso (Me.m_mode And Mode.File) = Mode.File)
        End Function


#End Region


    End Structure
#End Region


#Region &quot;FileEnumeratorMode&quot;


    &lt;Flags()&gt; _
    Public Enum Mode
        ''' &lt;summary&gt;
        ''' Enumerate directories.
        ''' &lt;/summary&gt;
        Directory = 1
        ''' &lt;summary&gt;
        ''' Enumerate files. 
        ''' &lt;/summary&gt;
        File = 2
    End Enum


#End Region


#Region &quot;Private members&quot;


    Private m_pattern As String     ' Search pattern
    Private m_mode As Mode          ' Enum mode


#End Region


#Region &quot;Constructor&quot;


    Public Sub New()
        Me.New(&quot;*.*&quot;)
    End Sub


    Public Sub New(ByVal pattern As String)
        Me.New(pattern, Mode.Directory Or Mode.File)
    End Sub


    Public Sub New(ByVal pattern As String, ByVal mode As Mode)
        Me.m_pattern = pattern
        Me.m_mode = mode
    End Sub


#End Region


#Region &quot;IEnumerable(Of String) Members&quot;


    Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of String) Implements IEnumerable(Of String).GetEnumerator
        Return New Enumerator(Me.m_pattern, Me.m_mode)
    End Function


#End Region


#Region &quot;IEnumerable Memebers&quot;


    Public Function GetEnumeratorObject() As System.Collections.IEnumerator Implements IEnumerable.GetEnumerator
        Return Me.GetEnumerator
    End Function


#End Region


End Class

</pre>
<pre id="codePreview" class="vb">
Public Class DirectoryEnumerator
    Implements IEnumerable(Of String)


#Region &quot;The Enumerator&quot;
    Public Structure Enumerator
        Implements IEnumerator(Of String)


#Region &quot;Private members&quot;


        Private hFindFile As SafeFindHandle
        Private m_current As String
        Private m_pattern As String
        Private m_mode As Mode


#End Region


#Region &quot;Constructor&quot;


        Friend Sub New(ByVal pattern As String, ByVal mode As Mode)
            Me.m_pattern = pattern
            Me.m_current = Nothing
            Me.hFindFile = Nothing
            Me.m_mode = mode
        End Sub


#End Region


#Region &quot;IEnumerator(Of String) Members&quot;


        Public ReadOnly Property Current() As String Implements IEnumerator(Of String).Current
            Get
                Return Me.m_current
            End Get
        End Property


#End Region


#Region &quot;IDisposable Members&quot;


        Public Sub Dispose() Implements IDisposable.Dispose
            If Me.hFindFile IsNot Nothing Then
                Me.hFindFile.Dispose()
            End If
        End Sub


#End Region


#Region &quot;IEnumerator Members&quot;


        Public ReadOnly Property CurrentObject() As Object Implements IEnumerator.Current
            Get
                Return Me.m_current
            End Get
        End Property


        Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
            If Me.hFindFile Is Nothing Then
                Return FindFirst()
            Else
                Return FindNext()
            End If
        End Function


        Public Sub Reset() Implements System.Collections.IEnumerator.Reset
            If Me.hFindFile IsNot Nothing Then
                Me.hFindFile.Close()
                Me.hFindFile = Nothing
            End If
        End Sub


#End Region


#Region &quot;Supporting Methods&quot;


        ''' &lt;summary&gt;
        ''' Find the first match.
        ''' &lt;/summary&gt;
        ''' &lt;returns&gt;&lt;/returns&gt;
        Private Function FindFirst() As Boolean
            Dim fd As New WIN32_FIND_DATA


            Me.hFindFile = NativeMethods.FindFirstFile(Me.m_pattern, fd)


            If Me.hFindFile.IsInvalid Then
                ' Got an invalid find handle, get the error code
                Dim code As Integer = Marshal.GetLastWin32Error()


                If code = NativeMethods.ERROR_FILE_NOT_FOUND Then
                    ' file not found, just return false
                    Return False
                End If


                ' other errors, throw exception
                Throw New Win32Exception(code)
            End If


            If Not AttributesMatchMode(fd.dwFileAttributes) Then
                ' if the file does not meet the match mode,
                ' go find the next match.
                Return FindNext()
            End If


            Me.m_current = fd.cFileName
            Return True
        End Function


        Private Function FindNext() As Boolean
            Dim fd As New WIN32_FIND_DATA


            While NativeMethods.FindNextFile(Me.hFindFile, fd)
                If Not AttributesMatchMode(fd.dwFileAttributes) Then
                    ' if the file does not meet the match mode,
                    ' go find the next match.
                    Continue While
                End If


                ' found a match, return.
                Me.m_current = fd.cFileName
                Return True
            End While


            Dim code As Integer = Marshal.GetLastWin32Error()


            If code = NativeMethods.ERROR_NO_MORE_FILES Then
                ' no more files, return false.
                Return False
            End If


            ' other errors, throw exception.
            Throw New Win32Exception(code)
        End Function


        Private Function AttributesMatchMode(ByVal fileAttributes As Integer) As Boolean
            Dim isDir As Boolean = _
                ((fileAttributes And NativeMethods.FILE_ATTRIBUTE_DIRECTORY) = NativeMethods.FILE_ATTRIBUTE_DIRECTORY)


            Return (isDir AndAlso ((Me.m_mode And Mode.Directory) = Mode.Directory)) OrElse _
                    (Not isDir AndAlso (Me.m_mode And Mode.File) = Mode.File)
        End Function


#End Region


    End Structure
#End Region


#Region &quot;FileEnumeratorMode&quot;


    &lt;Flags()&gt; _
    Public Enum Mode
        ''' &lt;summary&gt;
        ''' Enumerate directories.
        ''' &lt;/summary&gt;
        Directory = 1
        ''' &lt;summary&gt;
        ''' Enumerate files. 
        ''' &lt;/summary&gt;
        File = 2
    End Enum


#End Region


#Region &quot;Private members&quot;


    Private m_pattern As String     ' Search pattern
    Private m_mode As Mode          ' Enum mode


#End Region


#Region &quot;Constructor&quot;


    Public Sub New()
        Me.New(&quot;*.*&quot;)
    End Sub


    Public Sub New(ByVal pattern As String)
        Me.New(pattern, Mode.Directory Or Mode.File)
    End Sub


    Public Sub New(ByVal pattern As String, ByVal mode As Mode)
        Me.m_pattern = pattern
        Me.m_mode = mode
    End Sub


#End Region


#Region &quot;IEnumerable(Of String) Members&quot;


    Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of String) Implements IEnumerable(Of String).GetEnumerator
        Return New Enumerator(Me.m_pattern, Me.m_mode)
    End Function


#End Region


#Region &quot;IEnumerable Memebers&quot;


    Public Function GetEnumeratorObject() As System.Collections.IEnumerator Implements IEnumerable.GetEnumerator
        Return Me.GetEnumerator
    End Function


#End Region


End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:54.0pt"><b style=""><span style=""></span></b></p>
<h2>More Information<span style=""> </span></h2>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/aa364418(VS.85).aspx">FindFirstFile Function</a></span><span style="">
</span></p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/aa364428(VS.85).aspx">FindNextFile Function</a></span><span style="">
</span></p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/aa364413(VS.85).aspx">FindClose Function</a></span><span style="">
</span></p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/9eekhta0.aspx">IEnumerable&lt;T&gt; Interface</a></span><span style="">
</span></p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/78dfe2yb.aspx">IEnumerator&lt;T&gt; Interface</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
