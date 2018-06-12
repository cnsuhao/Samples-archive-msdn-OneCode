Imports System.Activities
Imports System.Activities.Statements
Imports System.Diagnostics
Imports System.Linq

Module Module1

    Dim s As Sequence

    Sub Main()
        Dim workflow1 = New Workflow1()
        WorkflowInvoker.Invoke(workflow1)
    End Sub

End Module
