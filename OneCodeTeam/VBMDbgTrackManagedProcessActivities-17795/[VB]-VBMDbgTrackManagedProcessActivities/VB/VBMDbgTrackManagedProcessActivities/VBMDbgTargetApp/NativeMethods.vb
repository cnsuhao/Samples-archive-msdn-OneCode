Imports System.Runtime.InteropServices

Friend NotInheritable Class NativeMethods
    <DllImport("kernel32.dll", CallingConvention:=CallingConvention.StdCall,
        SetLastError:=True, CharSet:=CharSet.Auto, ExactSpelling:=True)>
    Friend Shared Function GetCurrentThreadId() As UInteger
    End Function

End Class

