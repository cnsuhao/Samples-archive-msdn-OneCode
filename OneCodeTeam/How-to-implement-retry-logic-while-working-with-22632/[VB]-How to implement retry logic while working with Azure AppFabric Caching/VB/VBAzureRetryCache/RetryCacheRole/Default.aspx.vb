'****************************** Module Header ******************************\
'Module Name: Default.aspx.vb
'Project:     RetryCacheRole
'Copyright (c) Microsoft Corporation.
'
'When using cloud based services, it is very common to receive exceptions similar
'to below while performing cache operations such as get, put. These are called transient errors.  
'Developer is required to implement Retrylogic to successfully complete their cache operations. 
'
'ErrorCode<ERRCA0017>:SubStatus<ES0006>:There is a temporary failure. Please retry later. 
'(One or more specified cache servers are unavailable, which could be caused by busy 
'network or servers. For on-premises cache clusters, also verify the following conditions. 
'Ensure that security permission has been granted for this client account, and check 
'that the AppFabric Caching Service is allowed through the firewall on all cache hosts. 
'Also the MaxBufferSize on the server must be greater than or equal to the serialized 
'object size sent from the client.)
'
'This sample implements retrylogic to protect the application from crashing in the 
'event of transient errors. This sample uses Transient Fault Handling Application 
'Block to implement retry mechanism
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports Microsoft.ApplicationServer.Caching
Imports Microsoft.Practices.TransientFaultHandling
Imports Microsoft.Practices.EnterpriseLibrary.WindowsAzure.TransientFaultHandling.Cache

Public Class _Default
    Inherits System.Web.UI.Page
    ' Define DataCache object
    Dim cache As DataCache

    ' Global variable for retry strategy
    Dim retryStrategy As FixedInterval

    ' Global variable for retry policy
    Dim retryPolicy As RetryPolicy
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Configure retry policies, strategies, actions
        SetupRetryPolicy()

        ' Create cache object using the cache settings specified web.config 
        cache = CacheUtil.GetCacheConfig()
    End Sub


    Protected Sub btnReadFromCache_Click(sender As Object, e As EventArgs)
        Try
            ' In order to use the retry policies, strategies defined in Transient Fault 
            ' Handling Application Block , user calls to cache must be wrapped with in 
            ' ExecuteAction delegate.
            retryPolicy.ExecuteAction(Sub()

                                          ' Getting the object from azure cache and printing it on the page. 
                                          Response.Write(cache.[Get]("MyDataSet"))

                                      End Sub)
        Catch dc As DataCacheException
            ' Exception occurred after implementing the Retry logic.
            ' Ideally you should log the exception to your application logs and show user 
            ' friendly error message on the webpage.
            Trace.Write(dc.[GetType]().ToString() + dc.Message.ToString() + dc.StackTrace.ToString())
        End Try
    End Sub


    Protected Sub btnAddToCache_Click(sender As Object, e As EventArgs)
        Try
            ' In order to use the retry policies, strategies defined in Transient Fault Handling
            ' Application Block , user calls to cache must be wrapped with in ExecuteAction delegate
            retryPolicy.ExecuteAction(Sub()
                                          ' I'm just storing simple string object here .. Assuming this call fails, 
                                          ' this sample retries the same call 3 times with 1 second interval before it gives up.
                                          cache.Put("MyDataSet", "My Cache")
                                          Response.Write("String object added to cache!")


                                      End Sub)
        Catch dc As DataCacheException
            ' Exception occurred after implementing the Retry logic.
            ' Ideally you should log the exception to your application logs and show user friendly 
            ' error message on the webpage.
            Trace.Write(dc.[GetType]().ToString() + dc.Message.ToString() + dc.StackTrace.ToString())
        End Try
    End Sub

    ''' <summary>
    ''' This method configures strategies, policies, actions required for performing retries.
    ''' </summary> 
    Protected Sub SetupRetryPolicy()
        ' Define your retry strategy: in this sample, I'm retrying operation 3 times with 1 second interval
        retryStrategy = New FixedInterval(3, TimeSpan.FromSeconds(1))

        ' Define your retry policy here. This sample uses CacheTransientErrorDetectionStrategy 
        retryPolicy = New RetryPolicy(Of CacheTransientErrorDetectionStrategy)(retryStrategy)

        ' Get notifications from retries from  Transient Fault Handling Application Block code
        AddHandler retryPolicy.Retrying, AddressOf NewFunction
    End Sub

    Sub NewFunction(sender1, args)
        ' Log details of the retry.
        Dim msg = [String].Format("Retry - Count:{0}, Delay:{1}, Exception:{2}", args.CurrentRetryCount, args.Delay, args.LastException)

        ' Logging the notification details to the application trace. 
        Trace.Write(msg)

    End Sub
End Class