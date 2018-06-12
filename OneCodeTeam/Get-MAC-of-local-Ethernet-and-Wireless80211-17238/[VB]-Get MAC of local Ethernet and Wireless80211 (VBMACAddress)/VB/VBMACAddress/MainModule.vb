'************************** Module Header ******************************'
' Module Name:  Program.vb
' Project:      VBMACAddress
' Copyright (c) Microsoft Corporation.
' 
' The main method of this application.
' 
' As the WMINetworkManager, NetworkInformationManager and NDISNetworkManager
' classes all implements the IMACManager interface, we only have to pass an
' IMACManager instance to get the MAC of local adapters or remote host.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************'

Imports System.Net


Module MainModule


    Private Const mainOptions As String =
        "Choose a method to get MAC Address:" & ControlChars.CrLf _
        & "1. WMI." & ControlChars.CrLf _
        & "2. NetworkInformation (IPHelper API)" & ControlChars.CrLf _
        & "3. MSNdis (WMI)" & ControlChars.CrLf _
        & "0: Exit."

    Private Const wmiOptions As String =
        "Use WMI to get MAC Address." & ControlChars.CrLf _
        & "1. Get all the MAC Addresses of local adapters." & ControlChars.CrLf _
        & "2. Get remote MAC address." & ControlChars.CrLf _
        & "0. Back to main options."

    Private Const networkInformationOptions As String =
        "Use WMNetworkInformation (IPHelper API) to get MAC Address." & ControlChars.CrLf _
        & "1. Get all the MAC Addresses of local adapters." & ControlChars.CrLf _
        & "2. Get remote MAC address." & ControlChars.CrLf _
        & "0. Back to main options."

    Private Const msNdisOptions As String =
        "Use MSNdis (WMI classes) to get MAC Address." & ControlChars.CrLf & _
        "1. Get all the MAC Addresses of local adapters." & ControlChars.CrLf & _
        "2. Get remote MAC address." & ControlChars.CrLf _
        & "0. Back to main options."

    Sub Main(ByVal args() As String)
        Do
            Console.WriteLine()
            Console.WriteLine(mainOptions)

            Dim mainOption As Integer = 0

            If Not Integer.TryParse(Console.ReadLine(), mainOption) Then
                Console.WriteLine("Wrong input!")
                Continue Do
            End If


            If mainOption = 0 Then
                Exit Do
            End If
            Try
                Select Case mainOption
                    Case 1
                        GetMACAddress(WMI.WMINetworkManager.Instance, wmiOptions)
                    Case 2
                        GetMACAddress(NetworkInformation.NetworkInformationManager.Instance,
                                      networkInformationOptions)
                    Case 3
                        GetMACAddress(NDIS.MSNdisNetworkManager.Instance, msNdisOptions)
                    Case Else
                        Console.WriteLine("Wrong input!")
                End Select
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

        Loop
        Console.ReadLine()
    End Sub

    Sub GetMACAddress(ByVal manager As IMACManager, ByVal subOptions As String)

        Do
            Console.WriteLine()
            Console.WriteLine(subOptions)
            Dim subOption As Integer = 0

            If Not Integer.TryParse(Console.ReadLine(), subOption) Then
                Console.WriteLine("Wrong input!")
                Continue Do
            End If

            If subOption = 0 Then
                Exit Do
            End If

            Select Case subOption
                Case 1
                    Dim adaptersMAC = manager.GetLocalAdaptersMAC()
                    For Each item In adaptersMAC
                        Console.WriteLine("MAC:{1} Name:{0}", item.Key, item.Value)
                    Next item
                Case 2
                    Do
                        Console.WriteLine()
                        Console.WriteLine("Type the remote machine and credentials (if necessary). Empty to back.")
                        Console.WriteLine("MachineName|IP [Domain UserName Password]")
                        Dim input As String = Console.ReadLine()

                        If String.IsNullOrEmpty(input) Then
                            Exit Do
                        End If

                        Dim parameters() As String = input.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)

                        If parameters.Length <> 1 AndAlso parameters.Length <> 4 Then
                            Console.WriteLine("The input format is not correct.")
                            Exit Do
                        End If

                        Dim machine As String = parameters(0)
                        Dim credential As NetworkCredential = Nothing

                        If parameters.Length = 4 Then
                            credential = New NetworkCredential(parameters(2), parameters(3), parameters(1))
                        End If



                        Dim maclist = manager.GetRemoteMachineMAC(machine, credential)
                        If maclist IsNot Nothing AndAlso maclist.Count > 0 Then
                            For Each mac In maclist
                                Console.WriteLine("MAC:{1} Name:{0}", mac.Key, mac.Value)
                            Next mac
                        Else
                            Console.WriteLine("Can not find the Physical Address.")
                        End If

                        Console.WriteLine()
                    Loop

                Case Else
                    Console.WriteLine("Wrong input!")
            End Select

        Loop
    End Sub

End Module
