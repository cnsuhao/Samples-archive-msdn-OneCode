# List files in directory in C# (CSListFilesInDirectory)
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
* 2012-03-01 11:54:50
## Description

<h1>List files in directory in <span style="">CS</span> (<span class="SpellE"><span style="">CS</span>ListFilesInDirectory</span>)<span style="">
</span></h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span style="">The CSListFilesInDirectory project demonstrates how to implement an IEnumerable&lt;string&gt; that utilizes the Win32 File Management functions to enable application to get files and sub-directories in a specified directory
 one item a time.</span><span style=""> </span></p>
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
<p class="MsoListParagraphCxSpLast"><span style=""><img src="/site/view/file/53334/1/image.png" alt="" width="530" height="424" align="middle">
</span><span style=""></span></p>
<h2>Using the Code<span style=""> </span></h2>
<p class="MsoListParagraph" style="margin-left:54.0pt"><b style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style=""><span style="">Define Win32 P/Invoke methods.
</span></b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt;
/// Win32 Native P/Invoke
/// &lt;/summary&gt;
internal static class NativeMethods
{
    /// &lt;summary&gt;
    /// Searches a directory for a file or subdirectory with a name that matches
    /// a specific name (or partial name if wildcards are used).
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/aa364418(v=vs.85).aspx
    /// &lt;/summary&gt;
    [DllImport(&quot;kernel32.dll&quot;, CharSet = CharSet.Auto, SetLastError = true)]
    internal static extern SafeFindHandle FindFirstFile(
        string fileName, [In, Out] WIN32_FIND_DATA data);


    /// &lt;summary&gt;
    /// Continues a file search from a previous call to the FindFirstFile or 
    /// FindFirstFileEx function.
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/aa364428(v=VS.85).aspx
    /// &lt;/summary&gt;
    [DllImport(&quot;kernel32.dll&quot;, CharSet = CharSet.Auto, SetLastError = true)]
    internal static extern bool FindNextFile(
        SafeFindHandle hndFindFile, 
        [In, Out, MarshalAs(UnmanagedType.LPStruct)] 
        WIN32_FIND_DATA lpFindFileData);


    /// &lt;summary&gt;
    /// Closes a file search handle opened by the FindFirstFile, FindFirstFileEx, 
    /// FindFirstFileNameW, FindFirstFileNameTransactedW, FindFirstFileTransacted,
    /// FindFirstStreamTransactedW, or FindFirstStreamW functions.
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/aa364413(v=VS.85).aspx
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;handle&quot;&gt;&lt;/param&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), DllImport(&quot;kernel32.dll&quot;)]
    internal static extern bool FindClose(IntPtr handle);


    internal const int ERROR_SUCCESS = 0;
    internal const int ERROR_NO_MORE_FILES = 18;
    internal const int ERROR_FILE_NOT_FOUND = 2;
    internal const int FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
}

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
/// Win32 Native P/Invoke
/// &lt;/summary&gt;
internal static class NativeMethods
{
    /// &lt;summary&gt;
    /// Searches a directory for a file or subdirectory with a name that matches
    /// a specific name (or partial name if wildcards are used).
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/aa364418(v=vs.85).aspx
    /// &lt;/summary&gt;
    [DllImport(&quot;kernel32.dll&quot;, CharSet = CharSet.Auto, SetLastError = true)]
    internal static extern SafeFindHandle FindFirstFile(
        string fileName, [In, Out] WIN32_FIND_DATA data);


    /// &lt;summary&gt;
    /// Continues a file search from a previous call to the FindFirstFile or 
    /// FindFirstFileEx function.
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/aa364428(v=VS.85).aspx
    /// &lt;/summary&gt;
    [DllImport(&quot;kernel32.dll&quot;, CharSet = CharSet.Auto, SetLastError = true)]
    internal static extern bool FindNextFile(
        SafeFindHandle hndFindFile, 
        [In, Out, MarshalAs(UnmanagedType.LPStruct)] 
        WIN32_FIND_DATA lpFindFileData);


    /// &lt;summary&gt;
    /// Closes a file search handle opened by the FindFirstFile, FindFirstFileEx, 
    /// FindFirstFileNameW, FindFirstFileNameTransactedW, FindFirstFileTransacted,
    /// FindFirstStreamTransactedW, or FindFirstStreamW functions.
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/aa364413(v=VS.85).aspx
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;handle&quot;&gt;&lt;/param&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), DllImport(&quot;kernel32.dll&quot;)]
    internal static extern bool FindClose(IntPtr handle);


    internal const int ERROR_SUCCESS = 0;
    internal const int ERROR_NO_MORE_FILES = 18;
    internal const int ERROR_FILE_NOT_FOUND = 2;
    internal const int FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
}

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public class DirectoryEnumerator : IEnumerable&lt;string&gt;
{
    #region The Enumerator


    public struct Enumerator : IEnumerator&lt;string&gt;
    {
        #region Private members


        private SafeFindHandle hFindFile;
        private string current;
        private string pattern;
        private Mode mode;


        #endregion


        #region .ctor


        internal Enumerator(string pattern, Mode mode)
        {
            this.pattern = pattern;
            this.current = null;
            this.hFindFile = null;
            this.mode = mode;
        }


        #endregion


        #region IEnumerator&lt;string&gt; Members


        public string Current
        {
            get { return current; }
        }


        #endregion


        #region IDisposable Members


        public void Dispose()
        {
            if (null != hFindFile)
            {
                hFindFile.Close();
            }
        }


        #endregion


        #region IEnumerator Members


        object IEnumerator.Current
        {
            get { return this.Current; }
        }


        public bool MoveNext()
        {
            if (null == hFindFile)
            {
                return FindFirst();
            }
            else
            {
                return FindNext();
            }
        }


        public void Reset()
        {
            if (null != hFindFile)
            {
                // close the find handle
                hFindFile.Close();
                hFindFile = null;
            }
        }


        #endregion


        #region Supporting methods


        /// &lt;summary&gt;
        /// Find the first match.
        /// &lt;/summary&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        private bool FindFirst()
        {
            WIN32_FIND_DATA fd = new WIN32_FIND_DATA();


            hFindFile = NativeMethods.FindFirstFile(pattern, fd);


            if (hFindFile.IsInvalid)
            {
                // Got an invalid find handle, get the error code
                int code = Marshal.GetLastWin32Error();


                if (code == NativeMethods.ERROR_FILE_NOT_FOUND)
                {
                    // file not found, just return false
                    return false;
                }


                // other errors, throw exception
                throw new Win32Exception(code);
            }


            if (!AttributesMatchMode(fd.dwFileAttributes))
            {
                // if the file does not meet the match mode,
                // go find the next match.
                return FindNext();
            }


            current = fd.cFileName;
            return true;
        }


        private bool FindNext()
        {
            WIN32_FIND_DATA fd = new WIN32_FIND_DATA();


            while (NativeMethods.FindNextFile(hFindFile, fd))
            {
                if (!AttributesMatchMode(fd.dwFileAttributes))
                {
                    // if the file does not meet the match mode,
                    // go find the next match.
                    continue;
                }


                // found a match, return.
                current = fd.cFileName;
                return true;
            }
            
            int code = Marshal.GetLastWin32Error();


            if (code == NativeMethods.ERROR_NO_MORE_FILES)
            {
                // no more files, return false.
                return false;
            }
            
            // other errors, throw exception.
            throw new Win32Exception(code);
        }


        private bool AttributesMatchMode(int fileAttributes)
        {
            bool isDir = (fileAttributes & NativeMethods.FILE_ATTRIBUTE_DIRECTORY) 
                == NativeMethods.FILE_ATTRIBUTE_DIRECTORY;


            return ((isDir && (mode & Mode.Directory) == Mode.Directory) ||
                (!isDir && (mode & Mode.File) == Mode.File));
        }


        #endregion
    }


    #endregion


    #region FileEnumeratorMode


    [Flags]
    public enum Mode
    {
        /// &lt;summary&gt;
        /// Enumerate directories.
        /// &lt;/summary&gt;
        Directory = 1,
        /// &lt;summary&gt;
        /// Enumerate files.
        /// &lt;/summary&gt;
        File = 2
    }


    #endregion


    #region Private members


    private string pattern; // Search pattern
    private Mode mode;      // Enum mode


    #endregion


    #region .ctor


    public DirectoryEnumerator()
        : this(&quot;*.*&quot;)
    {
    }


    public DirectoryEnumerator(string pattern)
        : this(pattern, Mode.Directory | Mode.File)
    {            
    }


    public DirectoryEnumerator(string pattern, Mode mode)
    {
        this.pattern = pattern;
        this.mode = mode;
    }


    #endregion


    #region IEnumerable&lt;string&gt; Members


    IEnumerator&lt;string&gt; IEnumerable&lt;string&gt;.GetEnumerator()
    {
        return new Enumerator(pattern, mode);
    }


    #endregion


    #region IEnumerable Members


    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable&lt;string&gt;)this).GetEnumerator();
    }


    #endregion
}

</pre>
<pre id="codePreview" class="csharp">
public class DirectoryEnumerator : IEnumerable&lt;string&gt;
{
    #region The Enumerator


    public struct Enumerator : IEnumerator&lt;string&gt;
    {
        #region Private members


        private SafeFindHandle hFindFile;
        private string current;
        private string pattern;
        private Mode mode;


        #endregion


        #region .ctor


        internal Enumerator(string pattern, Mode mode)
        {
            this.pattern = pattern;
            this.current = null;
            this.hFindFile = null;
            this.mode = mode;
        }


        #endregion


        #region IEnumerator&lt;string&gt; Members


        public string Current
        {
            get { return current; }
        }


        #endregion


        #region IDisposable Members


        public void Dispose()
        {
            if (null != hFindFile)
            {
                hFindFile.Close();
            }
        }


        #endregion


        #region IEnumerator Members


        object IEnumerator.Current
        {
            get { return this.Current; }
        }


        public bool MoveNext()
        {
            if (null == hFindFile)
            {
                return FindFirst();
            }
            else
            {
                return FindNext();
            }
        }


        public void Reset()
        {
            if (null != hFindFile)
            {
                // close the find handle
                hFindFile.Close();
                hFindFile = null;
            }
        }


        #endregion


        #region Supporting methods


        /// &lt;summary&gt;
        /// Find the first match.
        /// &lt;/summary&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        private bool FindFirst()
        {
            WIN32_FIND_DATA fd = new WIN32_FIND_DATA();


            hFindFile = NativeMethods.FindFirstFile(pattern, fd);


            if (hFindFile.IsInvalid)
            {
                // Got an invalid find handle, get the error code
                int code = Marshal.GetLastWin32Error();


                if (code == NativeMethods.ERROR_FILE_NOT_FOUND)
                {
                    // file not found, just return false
                    return false;
                }


                // other errors, throw exception
                throw new Win32Exception(code);
            }


            if (!AttributesMatchMode(fd.dwFileAttributes))
            {
                // if the file does not meet the match mode,
                // go find the next match.
                return FindNext();
            }


            current = fd.cFileName;
            return true;
        }


        private bool FindNext()
        {
            WIN32_FIND_DATA fd = new WIN32_FIND_DATA();


            while (NativeMethods.FindNextFile(hFindFile, fd))
            {
                if (!AttributesMatchMode(fd.dwFileAttributes))
                {
                    // if the file does not meet the match mode,
                    // go find the next match.
                    continue;
                }


                // found a match, return.
                current = fd.cFileName;
                return true;
            }
            
            int code = Marshal.GetLastWin32Error();


            if (code == NativeMethods.ERROR_NO_MORE_FILES)
            {
                // no more files, return false.
                return false;
            }
            
            // other errors, throw exception.
            throw new Win32Exception(code);
        }


        private bool AttributesMatchMode(int fileAttributes)
        {
            bool isDir = (fileAttributes & NativeMethods.FILE_ATTRIBUTE_DIRECTORY) 
                == NativeMethods.FILE_ATTRIBUTE_DIRECTORY;


            return ((isDir && (mode & Mode.Directory) == Mode.Directory) ||
                (!isDir && (mode & Mode.File) == Mode.File));
        }


        #endregion
    }


    #endregion


    #region FileEnumeratorMode


    [Flags]
    public enum Mode
    {
        /// &lt;summary&gt;
        /// Enumerate directories.
        /// &lt;/summary&gt;
        Directory = 1,
        /// &lt;summary&gt;
        /// Enumerate files.
        /// &lt;/summary&gt;
        File = 2
    }


    #endregion


    #region Private members


    private string pattern; // Search pattern
    private Mode mode;      // Enum mode


    #endregion


    #region .ctor


    public DirectoryEnumerator()
        : this(&quot;*.*&quot;)
    {
    }


    public DirectoryEnumerator(string pattern)
        : this(pattern, Mode.Directory | Mode.File)
    {            
    }


    public DirectoryEnumerator(string pattern, Mode mode)
    {
        this.pattern = pattern;
        this.mode = mode;
    }


    #endregion


    #region IEnumerable&lt;string&gt; Members


    IEnumerator&lt;string&gt; IEnumerable&lt;string&gt;.GetEnumerator()
    {
        return new Enumerator(pattern, mode);
    }


    #endregion


    #region IEnumerable Members


    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable&lt;string&gt;)this).GetEnumerator();
    }


    #endregion
}

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
