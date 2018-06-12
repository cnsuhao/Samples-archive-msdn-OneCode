# How to delete entity from Windows Azure Table storage in a DropDownList Control
## Requires
* 
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
* Windows Azure Mobile Services
* Windows Store app Development
## Topics
* Azure
* code snippets
* Windows RT
## IsPublished
* True
## ModifiedDate
* 2014-02-24 02:00:13
## Description

<h1>How to delete entity from Windows Azure Table storage in a DropDownList Control&nbsp;</h1>
<h2>Introduction</h2>
<p><span style="font-size:small">Deleting or retrieving an Azure Table Entity needs both partition key and row key.</span></p>
<p><span style="font-size:small">But if you use ASP.NET, you may not store the entire entity information like WPF, so after you bind the table entities to a data binding control, you may lose its partition key and row key when page is posted back.</span></p>
<p><span style="font-size:small">So this code snippet will show you how to bind table entity&rsquo;s data to a dropdown list, and get its partition key and row key when page is posted back.</span></p>
<h2>Using the Code</h2>
<p><span style="font-size:small">How to bind table entity&rsquo;s data to a dropdown list, and get its partition key and row key when page is posted back?</span></p>
<div class="scriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">public class UserData : TableEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        //We need PartionKey and Rowkey when retrive the entity. 
        //But We can only store a String in SelectValue. So I create a 
        //Property to store that.
        //You can use viewstate, session instead if want.

        public string PartitionKeyAndRowKey
        {
            get {return base.PartitionKey&#43;&quot;&amp;&quot;&#43;base.RowKey;}
        }
        
    }

    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            CloudStorageAccount account = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting(&quot;StorageConnectionString&quot;));

            var tableClient = account.CreateCloudTableClient();
            var table=tableClient.GetTableReference(&quot;LoginTable&quot;);

            var query = new TableQuery&lt;UserData&gt;();
            var tableResults = table.ExecuteQuery(query);
            ddlUsers.DataSource = tableResults;


           
            
            ddlUsers.DataTextField = &quot;UserName&quot;;
            ddlUsers.DataValueField = &quot;PartitionKeyAndRowKey&quot;;
           
            ddlUsers.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CloudStorageAccount account = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting(&quot;StorageConnectionString&quot;));

            var tableClient = account.CreateCloudTableClient();
            var table=tableClient.GetTableReference(&quot;LoginTable&quot;);

            string PartitionKeyAndRowKey = ddlUsers.SelectedValue;
            var strArrary = divide(PartitionKeyAndRowKey);
            string partitionKey = strArrary[0];
            string rowkey = strArrary[1];

            TableOperation retrieveOperation = TableOperation.Retrieve&lt;UserData&gt;(partitionKey, rowkey);
            TableResult retrievedResult = table.Execute(retrieveOperation);

            UserData deleteEntity = (UserData)retrievedResult.Result;
            if (deleteEntity != null)
            {
                TableOperation deleteOperation = TableOperation.Delete(deleteEntity);

                // Execute the operation.
                table.Execute(deleteOperation);

                Response.Write(&quot;Entity deleted.&quot;);
            }
            else
            {
                Response.Write(&quot;could not retrieve the Entity.&quot;);
            }

        }

        private string[] divide(string partitionKeyAndRowKey)
        {
            var strArrary = partitionKeyAndRowKey.Split('&amp;');
            return strArrary;
        }
    }
</pre>
<pre class="hidden">Public Class UserData
    Inherits TableEntity
    Public Property UserName() As String
        Get
            Return m_UserName
        End Get
        Set
            m_UserName = Value
        End Set
    End Property
    Private m_UserName As String
    Public Property Password() As String
        Get
            Return m_Password
        End Get
        Set
            m_Password = Value
        End Set
    End Property
    Private m_Password As String
    Public Property Email() As String
        Get
            Return m_Email
        End Get
        Set
            m_Email = Value
        End Set
    End Property
    Private m_Email As String

    'We need PartionKey and Rowkey when retrive the entity. 
    'But We can only store a String in SelectValue. So I create a 
    'Property to store that.
    'You can use viewstate, session instead if want.

    Public ReadOnly Property PartitionKeyAndRowKey() As String
        Get
            Return MyBase.PartitionKey &#43; &quot;&amp;&quot; &#43; MyBase.RowKey
        End Get
    End Property

End Class

Public Partial Class WebForm1
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs)

        Dim account As CloudStorageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting(&quot;StorageConnectionString&quot;))

        Dim tableClient = account.CreateCloudTableClient()
        Dim table = tableClient.GetTableReference(&quot;LoginTable&quot;)

        Dim query = New TableQuery(Of UserData)()
        Dim tableResults = table.ExecuteQuery(query)
        ddlUsers.DataSource = tableResults




        ddlUsers.DataTextField = &quot;UserName&quot;
        ddlUsers.DataValueField = &quot;PartitionKeyAndRowKey&quot;

        ddlUsers.DataBind()

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Dim account As CloudStorageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting(&quot;StorageConnectionString&quot;))

        Dim tableClient = account.CreateCloudTableClient()
        Dim table = tableClient.GetTableReference(&quot;LoginTable&quot;)

        Dim PartitionKeyAndRowKey As String = ddlUsers.SelectedValue
        Dim strArrary = divide(PartitionKeyAndRowKey)
        Dim partitionKey As String = strArrary(0)
        Dim rowkey As String = strArrary(1)

        Dim retrieveOperation As TableOperation = TableOperation.Retrieve(Of UserData)(partitionKey, rowkey)
        Dim retrievedResult As TableResult = table.Execute(retrieveOperation)

        Dim deleteEntity As UserData = DirectCast(retrievedResult.Result, UserData)
        If deleteEntity IsNot Nothing Then
            Dim deleteOperation As TableOperation = TableOperation.Delete(deleteEntity)

            ' Execute the operation.
            table.Execute(deleteOperation)

            Response.Write(&quot;Entity deleted.&quot;)
        Else
            Response.Write(&quot;could not retrieve the Entity.&quot;)
        End If

    End Sub

    Private Function divide(partitionKeyAndRowKey As String) As String()
        Dim strArrary = partitionKeyAndRowKey.Split(&quot;&amp;&quot;C)
        Return strArrary
    End Function
End Class
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;UserData&nbsp;:&nbsp;TableEntity&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;UserName&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Password&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Email&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//We&nbsp;need&nbsp;PartionKey&nbsp;and&nbsp;Rowkey&nbsp;when&nbsp;retrive&nbsp;the&nbsp;entity.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//But&nbsp;We&nbsp;can&nbsp;only&nbsp;store&nbsp;a&nbsp;String&nbsp;in&nbsp;SelectValue.&nbsp;So&nbsp;I&nbsp;create&nbsp;a&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Property&nbsp;to&nbsp;store&nbsp;that.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//You&nbsp;can&nbsp;use&nbsp;viewstate,&nbsp;session&nbsp;instead&nbsp;if&nbsp;want.</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;PartitionKeyAndRowKey&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">base</span>.PartitionKey&#43;<span class="cs__string">&quot;&amp;&quot;</span>&#43;<span class="cs__keyword">base</span>.RowKey;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;WebForm1&nbsp;:&nbsp;System.Web.UI.Page&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Page_Load(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloudStorageAccount&nbsp;account&nbsp;=&nbsp;CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting(<span class="cs__string">&quot;StorageConnectionString&quot;</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;tableClient&nbsp;=&nbsp;account.CreateCloudTableClient();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;table=tableClient.GetTableReference(<span class="cs__string">&quot;LoginTable&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;query&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;TableQuery&lt;UserData&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;tableResults&nbsp;=&nbsp;table.ExecuteQuery(query);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ddlUsers.DataSource&nbsp;=&nbsp;tableResults;&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ddlUsers.DataTextField&nbsp;=&nbsp;<span class="cs__string">&quot;UserName&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ddlUsers.DataValueField&nbsp;=&nbsp;<span class="cs__string">&quot;PartitionKeyAndRowKey&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ddlUsers.DataBind();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Button1_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloudStorageAccount&nbsp;account&nbsp;=&nbsp;CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting(<span class="cs__string">&quot;StorageConnectionString&quot;</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;tableClient&nbsp;=&nbsp;account.CreateCloudTableClient();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;table=tableClient.GetTableReference(<span class="cs__string">&quot;LoginTable&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;PartitionKeyAndRowKey&nbsp;=&nbsp;ddlUsers.SelectedValue;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;strArrary&nbsp;=&nbsp;divide(PartitionKeyAndRowKey);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;partitionKey&nbsp;=&nbsp;strArrary[<span class="cs__number">0</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;rowkey&nbsp;=&nbsp;strArrary[<span class="cs__number">1</span>];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TableOperation&nbsp;retrieveOperation&nbsp;=&nbsp;TableOperation.Retrieve&lt;UserData&gt;(partitionKey,&nbsp;rowkey);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TableResult&nbsp;retrievedResult&nbsp;=&nbsp;table.Execute(retrieveOperation);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UserData&nbsp;deleteEntity&nbsp;=&nbsp;(UserData)retrievedResult.Result;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(deleteEntity&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TableOperation&nbsp;deleteOperation&nbsp;=&nbsp;TableOperation.Delete(deleteEntity);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Execute&nbsp;the&nbsp;operation.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;table.Execute(deleteOperation);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.Write(<span class="cs__string">&quot;Entity&nbsp;deleted.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.Write(<span class="cs__string">&quot;could&nbsp;not&nbsp;retrieve&nbsp;the&nbsp;Entity.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>[]&nbsp;divide(<span class="cs__keyword">string</span>&nbsp;partitionKeyAndRowKey)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;strArrary&nbsp;=&nbsp;partitionKeyAndRowKey.Split(<span class="cs__string">'&amp;'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;strArrary;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;</pre>
</div>
</div>
</div>
</div>
<div class="endscriptcode">
<h2>More Information</h2>
<p><span style="font-size:small">TableEntity Class</span></p>
<p><span style="font-size:small"><a href="http://msdn.microsoft.com/en-us/library/windowsazure/microsoft.windowsazure.storage.table.tableentity.aspx">http://msdn.microsoft.com/en-us/library/windowsazure/microsoft.windowsazure.storage.table.tableentity.aspx</a></span></p>
<p><span style="font-size:small">CloudStorageAccount Class</span></p>
<p><span style="font-size:small"><a href="http://msdn.microsoft.com/en-us/library/windowsazure/microsoft.windowsazure.cloudstorageaccount.aspx">http://msdn.microsoft.com/en-us/library/windowsazure/microsoft.windowsazure.cloudstorageaccount.aspx</a></span></p>
<p><span style="font-size:small">CloudStorageAccountStorageClientExtensions.CreateCloudTableClient Method</span></p>
<p><span style="font-size:small"><a href="http://msdn.microsoft.com/en-us/library/windowsazure/microsoft.windowsazure.storageclient.cloudstorageaccountstorageclientextensions.createcloudtableclient.aspx">http://msdn.microsoft.com/en-us/library/windowsazure/microsoft.windowsazure.storageclient.cloudstorageaccountstorageclientextensions.createcloudtableclient.aspx</a></span></p>
<p>&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
</div>
