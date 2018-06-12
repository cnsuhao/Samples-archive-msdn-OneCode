Imports System.Collections.ObjectModel
Imports System.Threading

Module MainModule

    Private Const _newThreadCmdString As String = "t"

    Private Const _newAppDomainCmdString As String = "ad"

    Private Const _unloadAppDomainCmdString As String = "uad"

    Private Const _throwExceptionCmdString As String = "err"

    Private Const _logMessageCmdString As String = "log"

    Private _allowedCmdList As New ReadOnlyCollection(Of String)(
        New String() {
            _newThreadCmdString,
            _newAppDomainCmdString,
            _unloadAppDomainCmdString,
            _throwExceptionCmdString,
            _logMessageCmdString})

    Private Const _helpMsg As String =
        "Choose an activity:" & ControlChars.CrLf _
        & "t: Create a thread. Syntax: " & ControlChars.CrLf _
        & "   t [-list]" & ControlChars.CrLf _
        & "ad: Create an appdomain. Syntax:" & ControlChars.CrLf _
        & "   ad [friendly name | -list ]" & ControlChars.CrLf _
        & "uad: Unload an appdomain. Syntax:" & ControlChars.CrLf _
        & "   uad [app domain friendly name | -list ]" & ControlChars.CrLf _
        & "err: Throw an exception. Syntax:" & ControlChars.CrLf _
        & "   err <error message>" & ControlChars.CrLf _
        & "log: Add a log. Syntax:" & ControlChars.CrLf _
        & "   log <message>" & ControlChars.CrLf _
        & "help: Print this help message again." & ControlChars.CrLf _
        & "   help | ? "

    Private _appDomains As New Dictionary(Of String, AppDomain)()

    Sub Main(ByVal args() As String)
        _appDomains.Add(AppDomain.CurrentDomain.FriendlyName, AppDomain.CurrentDomain)

        Try
            Console.WriteLine(_helpMsg)

            Do
                Dim input As String = Console.ReadLine()
                Dim cmd As String = Nothing
                Dim arguments As String = Nothing
                TryParseCommand(input, cmd, arguments)

                Select Case cmd.ToLower()
                    Case _newThreadCmdString
                        ThreadCmd(arguments)
                    Case _newAppDomainCmdString
                        NewAppDomainCmd(arguments)
                    Case _unloadAppDomainCmdString
                        UnloadAppDomainCmd(arguments)
                    Case _throwExceptionCmdString
                        ThrowExceptionCmd(arguments)
                    Case _logMessageCmdString
                        LogCmd(arguments)
                    Case "help", "?"
                        Console.WriteLine(_helpMsg)
                    Case Else
                End Select
            Loop
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        Console.ReadLine()
    End Sub


    Private Sub TryParseCommand(ByVal input As String, ByRef commandName As String,
                                ByRef commandArguments As String)
        Dim commandLineText = input.Trim()
        Dim length As Integer = commandLineText.Length
        Dim index As Integer = 0
        Do While (index < length) AndAlso Not Char.IsWhiteSpace(commandLineText, index)
            index += 1
        Loop
        commandName = commandLineText.Substring(0, index)
        commandArguments = commandLineText.Substring(index).Trim()
    End Sub


    Private Sub ThreadCmd(ByVal arguments As String)
        If String.IsNullOrWhiteSpace(arguments) Then
            Dim newThread As New Thread(New ThreadStart(AddressOf SleepThread))
            newThread.Start()
        ElseIf arguments.Equals("-list", StringComparison.OrdinalIgnoreCase) Then
            Console.WriteLine("Print all threads:")

            For Each procThread As ProcessThread In Process.GetCurrentProcess().Threads
                Console.WriteLine(vbTab & "Thread ID: {0} State:{1} WaitReason:{2}",
                                  procThread.Id, procThread.ThreadState,
                                  If(procThread.ThreadState = Diagnostics.ThreadState.Wait,
                                     procThread.WaitReason.ToString(), String.Empty))

            Next procThread
        End If
    End Sub

    Private Sub SleepThread()
        Console.WriteLine("Create thread : {0}", NativeMethods.GetCurrentThreadId())
        Thread.Sleep(5000)
        Console.WriteLine("Exit thread : {0}", NativeMethods.GetCurrentThreadId())
    End Sub


    Private Sub NewAppDomainCmd(ByVal arguments As String)

        If String.IsNullOrWhiteSpace(arguments) OrElse arguments.Equals("-list", StringComparison.OrdinalIgnoreCase) Then
            Console.WriteLine("Print all AppDomains:")

            For Each item In _appDomains
                Console.WriteLine(vbTab & "AppDomain ID:{0} FriendlyName :{1}",
                                  item.Value.Id, item.Value.FriendlyName)
            Next item
        ElseIf Not _appDomains.ContainsKey(arguments) Then
            Dim domain = AppDomain.CreateDomain(arguments)
            _appDomains.Add(arguments, domain)
            Console.WriteLine("Create AppDomain : {0} {1}", domain.Id, domain.FriendlyName)
        Else
            Console.WriteLine("There is already an AppDomain with this name.")
        End If
    End Sub

    Private Sub UnloadAppDomainCmd(ByVal arguments As String)
        If String.IsNullOrWhiteSpace(arguments) OrElse
            arguments.Equals("-list", StringComparison.OrdinalIgnoreCase) Then
            Console.WriteLine("Print all AppDomains:")

            For Each item In _appDomains
                Console.WriteLine(vbTab & "AppDomain ID:{0} FriendlyName :{1}",
                                  item.Value.Id, item.Value.FriendlyName)
            Next item
        ElseIf _appDomains.ContainsKey(arguments) Then
            AppDomain.Unload(_appDomains(arguments))
            _appDomains.Remove(arguments)
            Console.WriteLine("Unload AppDomain : {0}", arguments)
        Else
            Console.WriteLine("No AppDomain with this name.")
        End If
    End Sub

    Private Sub ThrowExceptionCmd(ByVal msg As String)

        If String.IsNullOrWhiteSpace(msg) Then
            msg = "Default Exception."
        End If

        Try
            Throw New Exception(msg)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub

    Private Sub LogCmd(ByVal msg As String)
        If String.IsNullOrWhiteSpace(msg) Then
            Debugger.Log(0, "Default Category", "Default Message.")
        Else
            Debugger.Log(0, "Default Category", msg)
        End If
    End Sub

End Module
