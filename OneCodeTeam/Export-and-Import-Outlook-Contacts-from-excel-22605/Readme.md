# Export and Import Outlook  Contacts  from excel file using VSTO
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Office
* Office Development
## Topics
* Export and import
* Outlook Contacts
## IsPublished
* True
## ModifiedDate
* 2013-06-13 10:08:10
## Description

<h1>How to Export and Import Outlook Contacts from excel file (<span style="">VB</span>OutLookContactsExportImport)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to <span style="">export outlook contacts into excel file and import contacts from excel file to outlook using VSTO.
</span></p>
<p class="MsoNormal"><span style="">This Project creates wrapper class for outlook operation, the class includes export method and import methods and the main form can use this two methods to complete export and import functions directly.
</span></p>
<p class="MsoNormal"><span style="">Export function retrieves contact collection from outlook contacts and then exports the collection to an excel file on disk.
</span></p>
<p class="MsoNormal"><span style="">Import function fills a DataTable with data from an excel file and then imports the DataTable into outlook contacts.
</span></p>
<h2>Building the Sample</h2>
<p class="MsoNormal" style="margin-bottom:7.5pt; line-height:normal">Before you build the sample, you must install Microsoft office 2010 on your Operation System<span style="font-size:12.0pt; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;; color:black">.</span><span style="font-size:12.0pt; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;; color:black">
</span></p>
<p class="MsoNormal" style="margin-bottom:7.5pt; line-height:normal">This project references the
<span style="">P</span>rimary <span style="">I</span>nterop <span style="">A</span>ssembly
<span style="">(PIA) </span>for Microsoft Office <span style="">Outlook </span>20<span style="">10</span><span style="font-size:12.0pt; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;; color:black">
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">The following steps walk through a demonstration of export/import outlook contacts.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step1. Open VBOutLookContactsExportImport.sln and then click F5 to run this project. You will see the following form:
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/84281/1/image.png" alt="" width="322" height="314" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step2. Click &quot;Export&quot; button to call export method in OutlookProvider class, If you don't open outlook 2010 application, you need to select profile and click ok button in dialog. A messagebox will be shown to indicate if the operation
 is successful.</span><span style="font-size:9.5pt; font-family:新宋体; color:#A31515">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step3.<span style="">&nbsp; </span>Click &quot;Browse&quot; button to select the exported excel file in openfiledialog and then click &quot;open&quot; button after you select an excel file.<br style="">
<br style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step4. Click &quot;Import&quot; button to import the contacts from excel file to outlook contacts. A messagebox will be shown to indicate if the operation is successful.</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step5. You can open outlook 2010 application and check the contacts in outlook, you will find the contacts from excel in your outlook contacts list.
</span></p>
<h2>Using the Code<span style=""> </span></h2>
<p class="MsoNormal"><span style="">Step1. Create Windows Form project. On the File Menu, choose New, Project, in the templates pane, select Windows Forms Application and enter the name of the project.
</span></p>
<p class="MsoNormal"><span style="">Step2. Add the Outlook PIA reference to the project. To reference the Outlook PIA, right click the project file and click the &quot;Add Reference…&quot; button. In the Add Reference dialog, navigate to the .Net tab, find
 Microsoft.Office.Interop.Outlook 14.0.0.0 and click OK. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step3. Create a Wrapper class for Outlook 2010 and named it &quot;OutlookProvider&quot;. Import Outlook interop namespace in this class.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Imports Microsoft.Office.Interop.Outlook

</pre>
<pre id="codePreview" class="vb">
Imports Microsoft.Office.Interop.Outlook

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:新宋体; color:green"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step4. Start up an Outlook application by creating an Outloot.Application object
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Define Outlook Application Object
   Private ReadOnly outlook As Application


   ''' &lt;summary&gt;
   ''' Constructor
   ''' Create an instance of the Outlook Application Object 
   ''' &lt;/summary&gt;
   Public Sub New()
       outlook = New Application()
   End Sub

</pre>
<pre id="codePreview" class="vb">
' Define Outlook Application Object
   Private ReadOnly outlook As Application


   ''' &lt;summary&gt;
   ''' Constructor
   ''' Create an instance of the Outlook Application Object 
   ''' &lt;/summary&gt;
   Public Sub New()
       outlook = New Application()
   End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:新宋体; color:green"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step5. Get collection of Outlook contacts item and sort collection with contact's Last Name.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
    ''' Collection of Contacts Items
    ''' &lt;/summary&gt;
    Public ReadOnly Property ContactsItems() As IEnumerable(Of ContactItem)
  Get
      Dim folder As MAPIFolder = outlook.GetNamespace(&quot;MAPI&quot;).GetDefaultFolder(OlDefaultFolders.olFolderContacts)
      Dim contacts As IEnumerable(Of ContactItem) = folder.Items.OfType(Of ContactItem)()


      ' Get Collection ordered by LastName
      Dim query = From contact In contacts Order By contact.LastName Select contact
      Return query
  End Get
    End Property

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
    ''' Collection of Contacts Items
    ''' &lt;/summary&gt;
    Public ReadOnly Property ContactsItems() As IEnumerable(Of ContactItem)
  Get
      Dim folder As MAPIFolder = outlook.GetNamespace(&quot;MAPI&quot;).GetDefaultFolder(OlDefaultFolders.olFolderContacts)
      Dim contacts As IEnumerable(Of ContactItem) = folder.Items.OfType(Of ContactItem)()


      ' Get Collection ordered by LastName
      Dim query = From contact In contacts Order By contact.LastName Select contact
      Return query
  End Get
    End Property

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal"><span style="">Step6. Add method to implement exporting contacts into excel.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
    ''' Export Outlook contacts to Excel.
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;strConn&quot;&gt;Connecting String&lt;/param&gt;
    ''' &lt;param name=&quot;contacts&quot;&gt;Collection of Outlook Contacts Items&lt;/param&gt;
    Public Sub ContactsExportToExcel(strConn As String, contacts As IEnumerable(Of ContactItem))
        Using conn As New OleDbConnection(strConn)
            ' Create a new sheet in the Excel spreadsheet.
            Using cmd As New OleDbCommand(&quot;Create table Contact(FirstName varchar(50), LastName varchar(50),EmailAddress varchar(50),EmailDisplayName varchar(50))&quot;, conn)
                ' Open the connection.
                conn.Open()


                ' Execute the OleDbCommand.
                cmd.ExecuteNonQuery()


                cmd.CommandText = &quot;INSERT INTO Contact(FirstName,LastName,EmailAddress,EmailDisplayName) values (@FirstName,@LastName,@EmailAddress,@EmailDisplayName)&quot;


                ' Add the parameters.
                cmd.Parameters.Add(New OleDbParameter(&quot;@FirstName&quot;, OleDbType.VarChar))
                cmd.Parameters.Add(New OleDbParameter(&quot;@LastName&quot;, OleDbType.VarChar))
                cmd.Parameters.Add(New OleDbParameter(&quot;@EmailAddress&quot;, OleDbType.VarChar))
                cmd.Parameters.Add(New OleDbParameter(&quot;@EmailDisplayName&quot;, OleDbType.VarChar))


                For Each dr As ContactItem In contacts
                    cmd.Parameters(&quot;@FirstName&quot;).Value = If((dr.FirstName Is Nothing), String.Empty, dr.FirstName)
                    cmd.Parameters(&quot;@LastName&quot;).Value = If((dr.LastName Is Nothing), String.Empty, dr.LastName)
                    cmd.Parameters(&quot;@EmailAddress&quot;).Value = If((dr.Email1Address Is Nothing), String.Empty, dr.Email1Address)
                    cmd.Parameters(&quot;@EmailDisplayName&quot;).Value = If((dr.Email1DisplayName Is Nothing), String.Empty, dr.Email1DisplayName)


                    ' Insert the data into the Excel spreadsheet.
                    cmd.ExecuteNonQuery()
                Next
            End Using
        End Using


    End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
    ''' Export Outlook contacts to Excel.
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;strConn&quot;&gt;Connecting String&lt;/param&gt;
    ''' &lt;param name=&quot;contacts&quot;&gt;Collection of Outlook Contacts Items&lt;/param&gt;
    Public Sub ContactsExportToExcel(strConn As String, contacts As IEnumerable(Of ContactItem))
        Using conn As New OleDbConnection(strConn)
            ' Create a new sheet in the Excel spreadsheet.
            Using cmd As New OleDbCommand(&quot;Create table Contact(FirstName varchar(50), LastName varchar(50),EmailAddress varchar(50),EmailDisplayName varchar(50))&quot;, conn)
                ' Open the connection.
                conn.Open()


                ' Execute the OleDbCommand.
                cmd.ExecuteNonQuery()


                cmd.CommandText = &quot;INSERT INTO Contact(FirstName,LastName,EmailAddress,EmailDisplayName) values (@FirstName,@LastName,@EmailAddress,@EmailDisplayName)&quot;


                ' Add the parameters.
                cmd.Parameters.Add(New OleDbParameter(&quot;@FirstName&quot;, OleDbType.VarChar))
                cmd.Parameters.Add(New OleDbParameter(&quot;@LastName&quot;, OleDbType.VarChar))
                cmd.Parameters.Add(New OleDbParameter(&quot;@EmailAddress&quot;, OleDbType.VarChar))
                cmd.Parameters.Add(New OleDbParameter(&quot;@EmailDisplayName&quot;, OleDbType.VarChar))


                For Each dr As ContactItem In contacts
                    cmd.Parameters(&quot;@FirstName&quot;).Value = If((dr.FirstName Is Nothing), String.Empty, dr.FirstName)
                    cmd.Parameters(&quot;@LastName&quot;).Value = If((dr.LastName Is Nothing), String.Empty, dr.LastName)
                    cmd.Parameters(&quot;@EmailAddress&quot;).Value = If((dr.Email1Address Is Nothing), String.Empty, dr.Email1Address)
                    cmd.Parameters(&quot;@EmailDisplayName&quot;).Value = If((dr.Email1DisplayName Is Nothing), String.Empty, dr.Email1DisplayName)


                    ' Insert the data into the Excel spreadsheet.
                    cmd.ExecuteNonQuery()
                Next
            End Using
        End Using


    End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal"><span style="">Step7. Add method to implement import contacts from excel.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
   ''' Retrieve data from the Excel spreadsheet.
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;strConn&quot;&gt;Connecting String&lt;/param&gt;
   ''' &lt;returns&gt;DataTable Data&lt;/returns&gt;
   Public Function RetrieveData(strConn As String) As DataTable
       Dim dtExcel As New DataTable()


       Using conn As New OleDbConnection(strConn)
           ' Initialize an OleDbDataAdapter object.
           Using da As New OleDbDataAdapter(&quot;Select * from [Contact$]&quot;, conn)
               ' Fill the DataTable with data from the Excel spreadsheet.
               da.Fill(dtExcel)
           End Using
       End Using


       Return dtExcel
   End Function


   ''' &lt;summary&gt;
   ''' Import Contacts into Outlook Contacts from Excel spreadsheet
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;strConn&quot;&gt;&lt;/param&gt;
   Public Sub ContactsImportFromExcel(strConn As String)
       ' Get the contacts data from Excel files 
       Dim dtexcel As DataTable = RetrieveData(strConn)


       ' foreach Rows of DataTable
       For Each r As DataRow In dtexcel.Rows
           ' Create ContactItem
           Dim c As ContactItem = outlook.CreateItem(OlItemType.olContactItem)
           c.MessageClass = &quot;IPM.Contact&quot;
           c.FirstName = r(0).ToString()
           c.LastName = r(1).ToString()
           c.Email1Address = r(2).ToString()
           c.Email1DisplayName = r(3).ToString()


           ' Save ContactItem
           c.Save()
       Next
   End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
   ''' Retrieve data from the Excel spreadsheet.
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;strConn&quot;&gt;Connecting String&lt;/param&gt;
   ''' &lt;returns&gt;DataTable Data&lt;/returns&gt;
   Public Function RetrieveData(strConn As String) As DataTable
       Dim dtExcel As New DataTable()


       Using conn As New OleDbConnection(strConn)
           ' Initialize an OleDbDataAdapter object.
           Using da As New OleDbDataAdapter(&quot;Select * from [Contact$]&quot;, conn)
               ' Fill the DataTable with data from the Excel spreadsheet.
               da.Fill(dtExcel)
           End Using
       End Using


       Return dtExcel
   End Function


   ''' &lt;summary&gt;
   ''' Import Contacts into Outlook Contacts from Excel spreadsheet
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;strConn&quot;&gt;&lt;/param&gt;
   Public Sub ContactsImportFromExcel(strConn As String)
       ' Get the contacts data from Excel files 
       Dim dtexcel As DataTable = RetrieveData(strConn)


       ' foreach Rows of DataTable
       For Each r As DataRow In dtexcel.Rows
           ' Create ContactItem
           Dim c As ContactItem = outlook.CreateItem(OlItemType.olContactItem)
           c.MessageClass = &quot;IPM.Contact&quot;
           c.FirstName = r(0).ToString()
           c.LastName = r(1).ToString()
           c.Email1Address = r(2).ToString()
           c.Email1DisplayName = r(3).ToString()


           ' Save ContactItem
           c.Save()
       Next
   End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal"><span style="">Step8. Create a main form and add some controls in it. User can complete export/import operation in this form.
</span></p>
<p class="MsoNormal"><span style="">Step9. In click event of export button, call the export function in OutlookProvider class.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
    ''' Export outlook contacts to excel
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
    ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ' Exported excel file path
        Dim exportpath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & &quot;\ContactsExport.xlsx&quot;


        ' Initialize Connecting String
        Dim connectingstr As String = &quot;Provider=Microsoft.ACE.OLEDB.12.0;Data Source=&quot; & exportpath & &quot;;Extended Properties='Excel 12.0 Xml;HDR=Yes'&quot;
        Try
            If File.Exists(exportpath) Then
                ' If the excel file has existed in directory
                ' Delete the existing excel and create a new excel file to store the contacts.
                File.Delete(exportpath)
                outlook.ContactsExportToExcel(connectingstr, outlook.ContactsItems)
            Else
                outlook.ContactsExportToExcel(connectingstr, outlook.ContactsItems)
            End If


            MessageBox.Show(&quot;Export success! Exported file path is: &quot; & exportpath)
        Catch ex As Exception
            MessageBox.Show(&quot;Export Exception is: &quot; &#43; ex.Message, &quot;Exception&quot;)
        End Try
    End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
    ''' Export outlook contacts to excel
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
    ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ' Exported excel file path
        Dim exportpath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & &quot;\ContactsExport.xlsx&quot;


        ' Initialize Connecting String
        Dim connectingstr As String = &quot;Provider=Microsoft.ACE.OLEDB.12.0;Data Source=&quot; & exportpath & &quot;;Extended Properties='Excel 12.0 Xml;HDR=Yes'&quot;
        Try
            If File.Exists(exportpath) Then
                ' If the excel file has existed in directory
                ' Delete the existing excel and create a new excel file to store the contacts.
                File.Delete(exportpath)
                outlook.ContactsExportToExcel(connectingstr, outlook.ContactsItems)
            Else
                outlook.ContactsExportToExcel(connectingstr, outlook.ContactsItems)
            End If


            MessageBox.Show(&quot;Export success! Exported file path is: &quot; & exportpath)
        Catch ex As Exception
            MessageBox.Show(&quot;Export Exception is: &quot; &#43; ex.Message, &quot;Exception&quot;)
        End Try
    End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal"><span style="">Step10. Select an excel file with contacts data and import the contacts into outlook.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
   ''' Import contacts from Excel spreadsheet
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
   ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
   Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
       Try
           If tbxImportExcel.Text = String.Empty Then
               MessageBox.Show(&quot;Please select an Excel spreadsheet to import!&quot;, &quot;Tips&quot;, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
               Return
           End If


           ' Initialize Connecting String
           connectingstr = &quot;Provider=Microsoft.ACE.OLEDB.12.0;Data Source=&quot; &#43; tbxImportExcel.Text & &quot;;Extended Properties='Excel 12.0 Xml;HDR=Yes'&quot;


           ' call import method to import contacts into outlook
           outlook.ContactsImportFromExcel(connectingstr)
           MessageBox.Show(&quot;Import success!&quot;)
       Catch ex As Exception
           MessageBox.Show(&quot;Import Exception is: &quot; &#43; ex.Message, &quot;Exception&quot;)
       End Try
   End Sub


   ''' &lt;summary&gt;
   ''' Select excel spreadsheet to import
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
   ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
   Private Sub btnBrowseImp_Click(sender As Object, e As EventArgs) Handles btnBrowseImp.Click
       Using openFileDialog As New OpenFileDialog()
           openFileDialog.InitialDirectory = Application.StartupPath
           openFileDialog.Filter = &quot;All files (*.*)|*.*&quot;
           If openFileDialog.ShowDialog() = DialogResult.OK Then
               tbxImportExcel.Text = openFileDialog.FileName
           End If
       End Using
   End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
   ''' Import contacts from Excel spreadsheet
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
   ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
   Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
       Try
           If tbxImportExcel.Text = String.Empty Then
               MessageBox.Show(&quot;Please select an Excel spreadsheet to import!&quot;, &quot;Tips&quot;, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
               Return
           End If


           ' Initialize Connecting String
           connectingstr = &quot;Provider=Microsoft.ACE.OLEDB.12.0;Data Source=&quot; &#43; tbxImportExcel.Text & &quot;;Extended Properties='Excel 12.0 Xml;HDR=Yes'&quot;


           ' call import method to import contacts into outlook
           outlook.ContactsImportFromExcel(connectingstr)
           MessageBox.Show(&quot;Import success!&quot;)
       Catch ex As Exception
           MessageBox.Show(&quot;Import Exception is: &quot; &#43; ex.Message, &quot;Exception&quot;)
       End Try
   End Sub


   ''' &lt;summary&gt;
   ''' Select excel spreadsheet to import
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
   ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
   Private Sub btnBrowseImp_Click(sender As Object, e As EventArgs) Handles btnBrowseImp.Click
       Using openFileDialog As New OpenFileDialog()
           openFileDialog.InitialDirectory = Application.StartupPath
           openFileDialog.Filter = &quot;All files (*.*)|*.*&quot;
           If openFileDialog.ShowDialog() = DialogResult.OK Then
               tbxImportExcel.Text = openFileDialog.FileName
           End If
       End Using
   End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<h2>More Information</h2>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/office/ff870432.aspx">MSDN: Outlook 2010 Developer Reference</a>
</span></p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/office/bb644956.aspx">ContactItem Interface</a>
</span></p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/system.data.oledb.oledbconnection.aspx">OleDbConnection Class</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
