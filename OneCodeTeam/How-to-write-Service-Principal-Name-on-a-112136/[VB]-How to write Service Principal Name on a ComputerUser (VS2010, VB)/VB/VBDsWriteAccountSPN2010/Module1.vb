'****************************** Module Header ******************************\
'Module Name:    Module1.vb
'Project:        VBDsWriteAccountSPN2010
'Copyright (c) Microsoft Corporation

'The project illustrates how to check whether a file is in use or not.

'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
'All other rights reserved.

'*****************************************************************************/

Imports System.Runtime.InteropServices
Imports System.Text

Module Module1

    Const ERROR_BUFFER_OVERFLOW As Int32 = 111
    Const NO_ERROR As Int32 = 0

#Region "Native functions"

    <DllImport("ntdsapi.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Private Function DsGetSpn(ByVal ServiceType As DS_SPN_NAME_TYPE, ByVal serviceClass As String, ByVal serviceName As String, ByVal InstancePort As UShort, ByVal cInstanceNames As UShort, ByVal pInstanceNames As String(), _
 ByVal pInstancePorts As UShort(), ByRef SpnCount As Int32, ByRef SpnArrayPointer As System.IntPtr) As UInt32
    End Function

    ''' <summary> 
    ''' ENUM for spn Type 
    ''' </summary> 
    Public Enum DS_SPN_NAME_TYPE
        DS_SPN_DNS_HOST = 0
        DS_SPN_DN_HOST = 1
        DS_SPN_NB_HOST = 2
        DS_SPN_DOMAIN = 3
        DS_SPN_NB_DOMAIN = 4
        DS_SPN_SERVICE = 5
    End Enum

    ''' <summary> 
    ''' DsCrackSpn parses a spn into its component strings 
    ''' </summary> 
    ''' <param name="pszSPN"></param> 
    ''' <param name="pcServiceClass"></param> 
    ''' <param name="serviceClass"></param> 
    ''' <param name="pcServicename"></param> 
    ''' <param name="serviceName"></param> 
    ''' <param name="pcInstanceName"></param> 
    ''' <param name="instanceName"></param> 
    ''' <param name="pinstancePort"></param> 
    ''' <returns></returns> 
    <DllImport("Ntdsapi.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Private Function DsCrackSpn(ByVal pszSPN As String, ByRef pcServiceClass As Int32, ByVal serviceClass As StringBuilder, ByRef pcServicename As Int32, ByVal serviceName As StringBuilder, ByRef pcInstanceName As Int32, _
 ByVal instanceName As StringBuilder, ByRef pinstancePort As UShort) As UInt32
    End Function

    ''' <summary> 
    ''' DsWriteAccountSpn writes an array of SPNs to the servicePrincipalName attribute of a 
    ''' specified user or computer object in AD. 
    ''' </summary> 
    ''' <param name="hDS"></param> 
    ''' <param name="Operation"></param> 
    ''' <param name="pszAccount"></param> 
    ''' <param name="cSpn"></param> 
    ''' <param name="SPNArray"></param> 
    ''' <returns></returns> 
    <DllImport("ntdsapi.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Private Function DsWriteAccountSpn(ByVal hDS As System.IntPtr, ByVal Operation As DS_SPN_WRITE_OP, ByVal pszAccount As String, ByVal cSpn As Int32, ByVal SPNArray As System.IntPtr) As UInteger
    End Function

    ''' <summary> 
    ''' DSBind binds to a domain controller/Domain 
    ''' </summary> 
    ''' <param name="DomainControllerName"></param> 
    ''' <param name="DnsDomainName"></param> 
    ''' <param name="phDS"></param> 
    ''' <returns></returns> 
    <DllImport("ntdsapi.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Private Function DsBind(ByVal DomainControllerName As String, ByVal DnsDomainName As String, ByRef phDS As System.IntPtr) As UInteger
    End Function

    ''' <summary> 
    ''' Enum for spn Writing operation 
    ''' </summary> 
    Public Enum DS_SPN_WRITE_OP
        DS_SPN_ADD_SPN_OP = 0
        DS_SPN_REPLACE_SPN_OP = 1
        DS_SPN_DELETE_SPN_OP = 2
    End Enum
#End Region

    Sub Main()

        ' Input Variable values 
        Dim spn As String = "Machine/NewSPN"
        ' spn name 
        Dim servicePrincipalName As String = "CN=ACTUser,CN=Users,DC=SHAOLINT,DC=COM"
        ' DistinguishedName of the user/Computer 
        Dim domainControllerName As String = "SHALOINT"
        ' Domain controller name 
        Dim dnsDomainName As String = "SHAOLINT.COM"
        ' DNS domain name 
        Dim serviceClassSize As Integer = 1
        Dim serviceNameSize As Integer = 1
        Dim instanceNameSize As Integer = 1
        Dim port As UShort

        Dim sTemp As New StringBuilder(1)

        ' Initial call to DsCrackSpn should result in BUFFER_OVERFLOW... 
        Dim crackSpnResult As UInteger = DsCrackSpn(spn, serviceClassSize, sTemp, serviceNameSize, sTemp, instanceNameSize, _
         sTemp, port)

        ' Check for buffer overflow 
        If crackSpnResult = ERROR_BUFFER_OVERFLOW Then
            ' Resize our SB's 
            Dim serviceClass As New StringBuilder(serviceClassSize)
            Dim serviceName As New StringBuilder(serviceNameSize)
            Dim instanceName As New StringBuilder(instanceNameSize)

            ' Crack this spn using DsCrackSpn 
            crackSpnResult = DsCrackSpn(spn, serviceClassSize, serviceClass, serviceNameSize, serviceName, instanceNameSize, _
             instanceName, port)

            ' If Success 
            If crackSpnResult = NO_ERROR Then
                Dim hostArray As String() = {serviceName.ToString()}
                Dim portArray As UShort() = {port}
                Dim spnCount As UShort = 1
                Dim spnArrayPointer As New IntPtr()
                Dim spnArrayCount As Int32 = 0

                ' Call to DsBind to get handle for Directory 
                Dim hDS As System.IntPtr
                Dim result As UInteger = DsBind(domainControllerName, dnsDomainName, hDS)

                If result <> NO_ERROR Then
                    Console.WriteLine("DSBind Failed.")
                    Return
                End If

                ' Call to DsgetSpn to construct an spn 
                Dim getSPNResult As UInteger = DsGetSpn(DS_SPN_NAME_TYPE.DS_SPN_DNS_HOST, serviceClass.ToString(), Nothing, port, spnCount, hostArray, _
                 portArray, spnArrayCount, spnArrayPointer)

                If getSPNResult = NO_ERROR Then
                    ' Call the CSDsWriteAccountSPN for writing this spn to the object 
                    Dim dsWriteSpnResult As UInteger = DsWriteAccountSpn(hDS, DS_SPN_WRITE_OP.DS_SPN_ADD_SPN_OP, servicePrincipalName, spnArrayCount, spnArrayPointer)

                    If dsWriteSpnResult = NO_ERROR Then
                        Console.WriteLine("DsWriteAccountSpn Succeed. Please check the user/Computer object for ServicePrincipalName.")
                        Console.ReadKey()
                    Else
                        Console.WriteLine("DsWriteAccountSpn Failed.")
                        Return
                    End If
                Else
                    Console.WriteLine("DsGetSPN Failed.")
                    Return
                End If
            Else
                Console.WriteLine("DsCrackSpn Failed.")
                Return
            End If
        End If

    End Sub

End Module
