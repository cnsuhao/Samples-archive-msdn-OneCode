# Use a web role to serve files from blob storage
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Microsoft Azure
## Topics
* BLOB
* Web Role
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:34:35
## Description

<p style="font-family:Courier New">&nbsp;<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420" target="_blank"><img id="79969" src="http://i1.code.msdn.s-msft.com/csazurebingmaps-bab92df1/image/file/79969/1/120x90_azure_web_en_us.jpg" alt="" width="360" height="90"></a></p>
<p class="MsoNormal">The sample code demonstrates a way to serve files from storage via a web role.<span>
</span>A file from blob storage (such as http://xxx.cloudapp.net/files/File1) can be<span>
</span>reached as the normal files in your application by relative path (&quot;files/File1&quot;).<span>
</span>And this http module can also filter some specify types files.<span> There is a HttpModule runs before every http request to check the types of requested files and get it from blob storage, and it can also check if the file exists.
</span></p>
<p class="MsoNormal"><span>Before running this sample, please install Windows Azure SDK 1.6 and Windows Azure Toolkit for Visual Studio
</span></p>
<p class="MsoNormal"><span><a href="http://www.windowsazure.com/en-us/develop/downloads/">http://www.windowsazure.com/en-us/develop/downloads/</a>
</span></p>
<p class="MsoNormal"><span>SQL Server 2008 R2 Express: </span></p>
<p class="MsoNormal"><span><a href="http://www.microsoft.com/download/en/details.aspx?id=23650">http://www.microsoft.com/download/en/details.aspx?id=23650</a>
</span></p>
<p class="MsoNormal">Please follow these demonstration steps below.</p>
<p class="MsoNormal">Step 1:&nbsp;Open the CSAzureServeFilesFromBlobStorage.sln<span> as Administrator</span>. Expand the CSAzureServeFilesFromBlobStorage
<span>application</span> and <span>set CSAzureServeFilesFromBlobStorage azure application as the startup project, press F5 for show Default.aspx page</span>.</p>
<p class="MsoNormal">Step 2: <span>If please add your Windows Azure <strong>Storage Account and Key</strong> in the Windows Azure settings, &quot;StorageConnections&quot;. If you do not have one, please use Windows Azure Storage Emulator.<span>&nbsp;
</span>We will see a web page with two unavailable links on the page</span>. <span>
Please click the link &quot;Add default resources page&quot; button to redirect to default resources adding page.</span></p>
<p class="MsoNormal"><span><img src="/site/view/file/73982/1/image.png" alt="" width="576" height="396" align="middle">
</span></p>
<p class="MsoNormal">Step 3:<span>&nbsp; </span><span>Click the &quot;Click to upload the default resources&quot; button to upload your resources in Windows Azure Blob Storage and Table Storage</span>.<span> You can find them upon the &quot;Files&quot; folder, Microsoft.jpg,
 MSDN.jpg and Site.css. The file itself will be uploaded on the blob and file's information will be stored in table.</span></p>
<p class="MsoNormal"><span><img src="/site/view/file/73983/1/image.png" alt="" width="576" height="394" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoNormal"><span>Step 4: The files has been uploaded now, you can go to
<a href="http://windows.azure.com/">Microsoft Windows Azure Management Portal</a> for view your resources or use Azure Storage Explore tool to view them, the default blob container's name is &quot;container&quot; and default table name is &quot;files&quot;.
</span></p>
<p class="MsoNormal"><span><img src="/site/view/file/73984/1/image.png" alt="" width="576" height="393" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoNormal"><span><img src="/site/view/file/73985/1/image.png" alt="" width="576" height="139" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoNormal"><span>Step 5: Go back to the Default.aspx page and your will find the uploaded resources displays, please try to click the link to view them.
</span></p>
<p class="MsoNormal"><span><img src="/site/view/file/73986/1/image.png" alt="" width="576" height="393" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoNormal"><span>Step 6: In this sample, you can access jpg and css files (also include .aspx file), other types of file cannot be reached, such as .htm file.
</span></p>
<p class="MsoNormal"><span><img src="/site/view/file/73987/1/image.png" alt="" width="576" height="393" align="middle">
</span><span><span>&nbsp;</span> </span></p>
<p class="MsoNormal">Step <span>7</span>: Validation finished.</p>
<p class="MsoNormal">Code Logical: <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoNormal">Step 1. Create a C# &quot;<span>Windows Azure Project</span>&quot; in Visual Studio 201<span>0</span>. Name it as &quot;<span>CSAzureServeFilesFromBlobStorage</span>&quot;.
<span>Add a Web Role and named it as &quot;ServeFilesFromBlobStorageWebRole&quot;, a class library &quot;TableStorageManager&quot;, and make sure the class library's target framework is .NET Framework 4 (Not .NET Framework 4 Client Profile).
</span></p>
<p class="MsoNormal">Step 2. <span>Add 3 class files in TableStorageManager class library, this library is used to package the bottom table storage methods. Try to add Windows Azure references and Data Service client reference.
</span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><strong><span>Microsoft.WindowsAzure.Diagonostics </span></strong></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><strong><span>Microsoft.WindowsAzure.ServiceRuntime </span></strong></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><strong><span>Microsoft.WindowsAzure.StorageClient </span></strong></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><strong><span>System.Data.Service.Client </span></strong></p>
<p class="MsoNormal"><span>The FileEntity class is a table storage entity class, it includes some basic properties. The FileContext class is used to create queries for table services. You can also add paging method for table storage. The FileDataSource package
 the bottom layer methods (about cloud account, TableServiceContext, credentials, etc)
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class FileDataSource
{
    private static CloudStorageAccount account;
    private FileContext context;


    public FileDataSource()
    {
        // Create table storage client via cloud account.
        account = CloudStorageAccount.FromConfigurationSetting(&quot;StorageConnections&quot;);
        CloudTableClient client = account.CreateCloudTableClient();
        client.CreateTableIfNotExist(&quot;files&quot;);


        // Table context properties.
        context = new FileContext(account.TableEndpoint.AbsoluteUri, account.Credentials);
        context.RetryPolicy = RetryPolicies.Retry(3, TimeSpan.FromSeconds(1));
        context.IgnoreResourceNotFoundException = true;
        context.IgnoreMissingProperties = true;
        
    }


    /// &lt;summary&gt;
    /// Get all entities method.
    /// &lt;/summary&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    public IEnumerable&lt;FileEntity&gt; GetAllEntities()
    {
        var list = from m in this.context.GetEntities
                   select m;
        return list;
    }


    /// &lt;summary&gt;
    /// Get table rows by partitionKey.
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;partitionKey&quot;&gt;&lt;/param&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    public IEnumerable&lt;FileEntity&gt; GetEntities(string partitionKey)
    {
        var list = from m in this.context.GetEntities
                   where m.PartitionKey == partitionKey
                   select m;
        return list;
    }


    /// &lt;summary&gt;
    /// Get specify entity.
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;partitionKey&quot;&gt;&lt;/param&gt;
    /// &lt;param name=&quot;fileName&quot;&gt;&lt;/param&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    public FileEntity GetEntitiesByName(string partitionKey, string fileName)
    {
        var list = from m in this.context.GetEntities
                   where m.PartitionKey == partitionKey &amp;&amp; m.FileName == fileName
                   select m;
        if (list.Count() &gt; 0)
            return list.First&lt;FileEntity&gt;();
        else
            return null;
    }


    /// &lt;summary&gt;
    /// Add an entity.
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;entity&quot;&gt;&lt;/param&gt;
    public void AddFile(FileEntity entity)
    {
        this.context.AddObject(&quot;files&quot;, entity);
        this.context.SaveChanges();
    }


    /// &lt;summary&gt;
    /// Make a judgment to check if file is exists.
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;filename&quot;&gt;&lt;/param&gt;
    /// &lt;param name=&quot;partitionKey&quot;&gt;&lt;/param&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    public bool FileExists(string filename, string partitionKey)
    {
        IEnumerable&lt;FileEntity&gt; list = from m in this.context.GetEntities
                   where m.FileName == filename &amp;&amp; m.PartitionKey == partitionKey
                   select m;
        if (list.Count()&gt;0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

</pre>
<pre id="codePreview" class="csharp">public class FileDataSource
{
    private static CloudStorageAccount account;
    private FileContext context;


    public FileDataSource()
    {
        // Create table storage client via cloud account.
        account = CloudStorageAccount.FromConfigurationSetting(&quot;StorageConnections&quot;);
        CloudTableClient client = account.CreateCloudTableClient();
        client.CreateTableIfNotExist(&quot;files&quot;);


        // Table context properties.
        context = new FileContext(account.TableEndpoint.AbsoluteUri, account.Credentials);
        context.RetryPolicy = RetryPolicies.Retry(3, TimeSpan.FromSeconds(1));
        context.IgnoreResourceNotFoundException = true;
        context.IgnoreMissingProperties = true;
        
    }


    /// &lt;summary&gt;
    /// Get all entities method.
    /// &lt;/summary&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    public IEnumerable&lt;FileEntity&gt; GetAllEntities()
    {
        var list = from m in this.context.GetEntities
                   select m;
        return list;
    }


    /// &lt;summary&gt;
    /// Get table rows by partitionKey.
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;partitionKey&quot;&gt;&lt;/param&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    public IEnumerable&lt;FileEntity&gt; GetEntities(string partitionKey)
    {
        var list = from m in this.context.GetEntities
                   where m.PartitionKey == partitionKey
                   select m;
        return list;
    }


    /// &lt;summary&gt;
    /// Get specify entity.
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;partitionKey&quot;&gt;&lt;/param&gt;
    /// &lt;param name=&quot;fileName&quot;&gt;&lt;/param&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    public FileEntity GetEntitiesByName(string partitionKey, string fileName)
    {
        var list = from m in this.context.GetEntities
                   where m.PartitionKey == partitionKey &amp;&amp; m.FileName == fileName
                   select m;
        if (list.Count() &gt; 0)
            return list.First&lt;FileEntity&gt;();
        else
            return null;
    }


    /// &lt;summary&gt;
    /// Add an entity.
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;entity&quot;&gt;&lt;/param&gt;
    public void AddFile(FileEntity entity)
    {
        this.context.AddObject(&quot;files&quot;, entity);
        this.context.SaveChanges();
    }


    /// &lt;summary&gt;
    /// Make a judgment to check if file is exists.
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;filename&quot;&gt;&lt;/param&gt;
    /// &lt;param name=&quot;partitionKey&quot;&gt;&lt;/param&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    public bool FileExists(string filename, string partitionKey)
    {
        IEnumerable&lt;FileEntity&gt; list = from m in this.context.GetEntities
                   where m.FileName == filename &amp;&amp; m.PartitionKey == partitionKey
                   select m;
        if (list.Count()&gt;0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span>&nbsp;</span></p>
<p class="MsoNormal">Step 3. <span>Then we need add a class in ServeFilesFromBlobStorageWebRole project as a HttpModuler to check the requested file types and access the file in Blob Storage.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public void Init(HttpApplication context)
{           
    context.BeginRequest &#43;= new EventHandler(this.Application_BeginRequest);
}


/// &lt;summary&gt;
/// Check file types and request it by cloud blob API.
/// &lt;/summary&gt;
/// &lt;param name=&quot;source&quot;&gt;&lt;/param&gt;
/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
private void Application_BeginRequest(Object source,EventArgs e)
{
    string url = HttpContext.Current.Request.Url.ToString();
    string fileName = url.Substring(url.LastIndexOf('/') &#43; 1).ToString();
    string extensionName = string.Empty;
    if (fileName.Substring(fileName.LastIndexOf('.') &#43; 1).ToString().Equals(&quot;aspx&quot;))
    {
        return;
    }


    if (!fileName.Equals(string.Empty))
    {
        extensionName = fileName.Substring(fileName.LastIndexOf('.') &#43; 1).ToString();
        if (!extensionName.Equals(string.Empty))
        {
            string contentType = this.GetContentType(fileName);
            if (contentType.Equals(string.Empty))
            {
                HttpContext.Current.Server.Transfer(&quot;NoHandler.aspx&quot;);
            };
            {
                FileDataSource dataSource = new FileDataSource();
                string paritionKey = this.GetPartitionName(extensionName);
                if (String.IsNullOrEmpty(paritionKey))
                {
                    HttpContext.Current.Server.Transfer(&quot;NoHandler.aspx&quot;);
                }
                FileEntity entity = dataSource.GetEntitiesByName(paritionKey, &quot;Files/&quot; &#43; fileName);
                if (entity != null)
                    HttpContext.Current.Response.Redirect(entity.FileUrl);
                else
                    HttpContext.Current.Server.Transfer(&quot;NoResources.aspx&quot;);
            }
        }
    }
}


/// &lt;summary&gt;
/// Get file's Content-Type.
/// &lt;/summary&gt;
/// &lt;param name=&quot;filename&quot;&gt;&lt;/param&gt;
/// &lt;returns&gt;&lt;/returns&gt;
public string GetContentType(string filename)
{
    string res = string.Empty;


    switch (filename.Substring(filename.LastIndexOf('.') &#43; 1).ToString().ToLower())
    {
        case &quot;jpg&quot;:
            res = &quot;image/jpg&quot;;
            break;
        case &quot;css&quot;:
            res = &quot;text/css&quot;;
            break;
    }


    return res;
}


/// &lt;summary&gt;
/// Get file's partitionKey.
/// &lt;/summary&gt;
/// &lt;param name=&quot;extensionName&quot;&gt;&lt;/param&gt;
/// &lt;returns&gt;&lt;/returns&gt;
public string GetPartitionName(string extensionName)
{
    string partitionName = string.Empty;
    switch(extensionName)
    {
        case &quot;jpg&quot;:
            partitionName = &quot;image&quot;;
            break;
        case &quot;css&quot;:
            partitionName = &quot;css&quot;;
            break;
    }
    return partitionName;
}

</pre>
<pre id="codePreview" class="csharp">public void Init(HttpApplication context)
{           
    context.BeginRequest &#43;= new EventHandler(this.Application_BeginRequest);
}


/// &lt;summary&gt;
/// Check file types and request it by cloud blob API.
/// &lt;/summary&gt;
/// &lt;param name=&quot;source&quot;&gt;&lt;/param&gt;
/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
private void Application_BeginRequest(Object source,EventArgs e)
{
    string url = HttpContext.Current.Request.Url.ToString();
    string fileName = url.Substring(url.LastIndexOf('/') &#43; 1).ToString();
    string extensionName = string.Empty;
    if (fileName.Substring(fileName.LastIndexOf('.') &#43; 1).ToString().Equals(&quot;aspx&quot;))
    {
        return;
    }


    if (!fileName.Equals(string.Empty))
    {
        extensionName = fileName.Substring(fileName.LastIndexOf('.') &#43; 1).ToString();
        if (!extensionName.Equals(string.Empty))
        {
            string contentType = this.GetContentType(fileName);
            if (contentType.Equals(string.Empty))
            {
                HttpContext.Current.Server.Transfer(&quot;NoHandler.aspx&quot;);
            };
            {
                FileDataSource dataSource = new FileDataSource();
                string paritionKey = this.GetPartitionName(extensionName);
                if (String.IsNullOrEmpty(paritionKey))
                {
                    HttpContext.Current.Server.Transfer(&quot;NoHandler.aspx&quot;);
                }
                FileEntity entity = dataSource.GetEntitiesByName(paritionKey, &quot;Files/&quot; &#43; fileName);
                if (entity != null)
                    HttpContext.Current.Response.Redirect(entity.FileUrl);
                else
                    HttpContext.Current.Server.Transfer(&quot;NoResources.aspx&quot;);
            }
        }
    }
}


/// &lt;summary&gt;
/// Get file's Content-Type.
/// &lt;/summary&gt;
/// &lt;param name=&quot;filename&quot;&gt;&lt;/param&gt;
/// &lt;returns&gt;&lt;/returns&gt;
public string GetContentType(string filename)
{
    string res = string.Empty;


    switch (filename.Substring(filename.LastIndexOf('.') &#43; 1).ToString().ToLower())
    {
        case &quot;jpg&quot;:
            res = &quot;image/jpg&quot;;
            break;
        case &quot;css&quot;:
            res = &quot;text/css&quot;;
            break;
    }


    return res;
}


/// &lt;summary&gt;
/// Get file's partitionKey.
/// &lt;/summary&gt;
/// &lt;param name=&quot;extensionName&quot;&gt;&lt;/param&gt;
/// &lt;returns&gt;&lt;/returns&gt;
public string GetPartitionName(string extensionName)
{
    string partitionName = string.Empty;
    switch(extensionName)
    {
        case &quot;jpg&quot;:
            partitionName = &quot;image&quot;;
            break;
        case &quot;css&quot;:
            partitionName = &quot;css&quot;;
            break;
    }
    return partitionName;
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal">Step <span>4. Try to add a Default web page to shows the some example links, and FileUploadPage for upload some default resources to Storage for testing.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public partial class FileUploadPage : System.Web.UI.Page
{
    private static CloudStorageAccount account;
    public List&lt;FileEntity&gt; files = new List&lt;FileEntity&gt;();
    protected void Page_Load(object sender, EventArgs e)
    {
        account = CloudStorageAccount.FromConfigurationSetting(&quot;StorageConnections&quot;);
    }


    /// &lt;summary&gt;
    /// Upload existing resources. (&quot;Files&quot; folder)
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
    /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        FileDataSource source = new FileDataSource();
        List&lt;string&gt; nameList = new List&lt;string&gt;() { &quot;Files/Microsoft.jpg&quot;, &quot;Files/MSDN.jpg&quot;, &quot;Files/Site.css&quot; };
        CloudBlobClient client = account.CreateCloudBlobClient();
        CloudBlobContainer container = client.GetContainerReference(&quot;container&quot;);
        container.CreateIfNotExist();
        var permission = container.GetPermissions();
        permission.PublicAccess = BlobContainerPublicAccessType.Container;
        container.SetPermissions(permission);
        bool flag = false;
        
        foreach (string name in nameList)
        {
            if (name.Substring(name.LastIndexOf('.') &#43; 1).Equals(&quot;jpg&quot;) &amp;&amp; File.Exists(Server.MapPath(name)))
            {
                if (!source.FileExists(name, &quot;image&quot;))
                {
                    flag = true;
                    CloudBlob blob = container.GetBlobReference(name);
                    blob.UploadFile(Server.MapPath(name));


                    FileEntity entity = new FileEntity(&quot;image&quot;);
                    entity.FileName = name;
                    entity.FileUrl = blob.Uri.ToString();
                    source.AddFile(entity);
                    lbContent.Text &#43;= String.Format(&quot;The image file {0} is uploaded successes. <br>&quot;, name);
                }
            }
            else if (name.Substring(name.LastIndexOf('.') &#43; 1).Equals(&quot;css&quot;) &amp;&amp; File.Exists(Server.MapPath(name)))
            {
                if (!source.FileExists(name, &quot;css&quot;))
                {
                    flag = true;
                    CloudBlob blob = container.GetBlobReference(name);
                    blob.UploadFile(Server.MapPath(name));


                    FileEntity entity = new FileEntity(&quot;css&quot;);
                    entity.FileName = name;
                    entity.FileUrl = blob.Uri.ToString();
                    source.AddFile(entity);
                    lbContent.Text &#43;= String.Format(&quot;The css file {0} is uploaded successes. <br>&quot;, name);
                }
            }
        }


        if (!flag)
        {
            lbContent.Text = &quot;You had uploaded these resources&quot;;
        }
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect(&quot;Default.aspx&quot;);
    }
}

</pre>
<pre id="codePreview" class="csharp">public partial class FileUploadPage : System.Web.UI.Page
{
    private static CloudStorageAccount account;
    public List&lt;FileEntity&gt; files = new List&lt;FileEntity&gt;();
    protected void Page_Load(object sender, EventArgs e)
    {
        account = CloudStorageAccount.FromConfigurationSetting(&quot;StorageConnections&quot;);
    }


    /// &lt;summary&gt;
    /// Upload existing resources. (&quot;Files&quot; folder)
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
    /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        FileDataSource source = new FileDataSource();
        List&lt;string&gt; nameList = new List&lt;string&gt;() { &quot;Files/Microsoft.jpg&quot;, &quot;Files/MSDN.jpg&quot;, &quot;Files/Site.css&quot; };
        CloudBlobClient client = account.CreateCloudBlobClient();
        CloudBlobContainer container = client.GetContainerReference(&quot;container&quot;);
        container.CreateIfNotExist();
        var permission = container.GetPermissions();
        permission.PublicAccess = BlobContainerPublicAccessType.Container;
        container.SetPermissions(permission);
        bool flag = false;
        
        foreach (string name in nameList)
        {
            if (name.Substring(name.LastIndexOf('.') &#43; 1).Equals(&quot;jpg&quot;) &amp;&amp; File.Exists(Server.MapPath(name)))
            {
                if (!source.FileExists(name, &quot;image&quot;))
                {
                    flag = true;
                    CloudBlob blob = container.GetBlobReference(name);
                    blob.UploadFile(Server.MapPath(name));


                    FileEntity entity = new FileEntity(&quot;image&quot;);
                    entity.FileName = name;
                    entity.FileUrl = blob.Uri.ToString();
                    source.AddFile(entity);
                    lbContent.Text &#43;= String.Format(&quot;The image file {0} is uploaded successes. <br>&quot;, name);
                }
            }
            else if (name.Substring(name.LastIndexOf('.') &#43; 1).Equals(&quot;css&quot;) &amp;&amp; File.Exists(Server.MapPath(name)))
            {
                if (!source.FileExists(name, &quot;css&quot;))
                {
                    flag = true;
                    CloudBlob blob = container.GetBlobReference(name);
                    blob.UploadFile(Server.MapPath(name));


                    FileEntity entity = new FileEntity(&quot;css&quot;);
                    entity.FileName = name;
                    entity.FileUrl = blob.Uri.ToString();
                    source.AddFile(entity);
                    lbContent.Text &#43;= String.Format(&quot;The css file {0} is uploaded successes. <br>&quot;, name);
                }
            }
        }


        if (!flag)
        {
            lbContent.Text = &quot;You had uploaded these resources&quot;;
        }
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect(&quot;Default.aspx&quot;);
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><span>Step 5. Please add your Windows Azure Storage account name and key in the Azure project. If you do not have one, use Windows Azure Storage Emulator for testing.
</span></p>
<p class="MsoNormal">Step <span>6</span>. Build the application and you can debug it.</p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/windowsazure/dd135733.aspx">Blob Service REST API</a></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/windowsazure/dd179423.aspx">Table Service REST API</a></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/aa719858(v=VS.71).aspx"><span class="SpellE">HttpModule</span></a><span class="SpellE">r</span></p>
<p class="MsoNormal">&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
