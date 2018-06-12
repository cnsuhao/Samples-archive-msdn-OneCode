========================================================================
                  VBASPNETSmartDropdownlist Overview
========================================================================

/////////////////////////////////////////////////////////////////////////////
Summary:

The code sample customizes the SelectedValue property of ASP.NET DropDownList 
control so that it handles the situation more nicely when the SelectedValue 
property is set to a value that does not exist in the DropDownList value 
collection.  By default, an ArguementOutOfRangeException exception is thrown 
when SelectedValue is set invalidly.  With the customization, the DropDownList
will select a "None" item when the SelectedValue is invalid. 


/////////////////////////////////////////////////////////////////////////////
Demo the Sample. 

Please follow these demonstration steps below.

Step 1: Open the VBASPNETSmartDropdownlist.sln.

Step 2: Right click TestSqlDataSource.aspx and choose "View in Browser".

Step 3: You will see a DropDownList and a GridView in the page, note the 
        DropDwonList has four valid items while the GridView has six.

Step 4: If you click the "Select DropDownList option" button you may notice that 
		the selected item of DropDownList will change accordingly to the related one. 
		If the item which you selected by clicking button is not contained in 
		DropDownList control, the selected item of DropDownList will be "None".

Step 5: You can also change the selectedValue in page_load event.

Step 6: View and test the TestObjectDataSource.aspx page as above.
        [Note]
		The two test page are ues Sql data source and Object data source to test
		this smart DropDownList control, the Sql data source is not means SqlDataSource
		control, it means generiec data source, we can convert it to DataTable variable,
		and object data source can convert to IEnumerable object variable.
		[/Note]

Step 7: Validation finished.

/////////////////////////////////////////////////////////////////////////////
Code Logical:

Step 1. Create a VB "ASP.NET Server Control" in Visual Studio 2010 or
        Visual Web Developer 2010. Name it as "VBASPNETSmartDropdownlist".

Step 2. Add a Server control and name it as "CustomizedDropDownList.vb".

Step 3. Remove the Text property and override RenderContent method. Override the
        Render method, the VB code as shown below:
		[code]
    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        MyBase.Render(writer)
    End Sub
		[/code]

Step 4. Override the SelectedValue property.
		The code as shown below:
		[code]
    Public Overrides Property SelectedValue As String
        Get
            Return MyBase.SelectedValue
        End Get
        Set(ByVal value As String)
            ' If data source is SqlDataSource.
            If TypeOf DataSource Is DataView Then
                Dim dataView As DataView = TryCast(DataSource, DataView)
                Dim tabView As DataTable = dataView.Table
                Dim typeColumns As Type = tabView.Columns(DataValueField).DataType
                Dim rowFilter As String = String.Empty
                If typeColumns.Equals(Type.[GetType]("System.String")) Then
                    rowFilter = String.Format("{0}='{1}'", DataValueField, value)
                ElseIf typeColumns.Equals(Type.[GetType]("System.Int32")) OrElse typeColumns.Equals(Type.[GetType]("System.Int64")) Then
                    rowFilter = String.Format("{0}={1}", DataValueField, value)
                Else
                    Throw New NotImplementedException("unsupported type")
                End If

                dataView.RowFilter = rowFilter
                If dataView.Count <> 0 Then
                    dataView.RowFilter = String.Empty
                    MyBase.SelectedValue = value
                Else
                    dataView.RowFilter = String.Empty
                    MyBase.SelectedValue = Items(0).Value
                End If
                ' If data source is ObjectDataSource
            ElseIf TypeOf DataSource Is IEnumerable Then
                Dim bolFlag As Boolean = False
                For Each obj As Object In TryCast(DataSource, IEnumerable)
                    Dim typeObj As Type = obj.[GetType]()
                    Dim info As PropertyInfo = typeObj.GetProperty(DataValueField)
                    Dim valueProperty As String = info.GetValue(obj, Nothing).ToString()
                    If valueProperty.Equals(value) Then
                        bolFlag = True
                        Exit For
                    End If
                Next

                If bolFlag Then
                    MyBase.SelectedValue = value
                Else
                    MyBase.SelectedValue = Items(0).Value
                End If
            End If

            ' If user change the selected value after postback.
            If DataSource Is Nothing Then
                Dim bolFlag As Boolean = False
                For i As Integer = 0 To Items.Count - 1
                    If Items(i).Value.Equals(value) Then
                        bolFlag = True
                        Exit For
                    End If
                Next
                If bolFlag Then
                    MyBase.SelectedValue = value
                Else
                    MyBase.SelectedValue = Items(0).Value
                End If
            End If

        End Set
    End Property
		[/code]
		
Step 5. Add an "ASP.NET Empty Web Application" in solution, the project is used to test
        the customized DropDownList we've created. Add two web form pages and named them
		as "TestSqlDataSource.aspx.aspx", "TestObjectDataSource.aspx.aspx". 

Step 6. Add a GridView and a DropDownList control on TestSqlDataSource page, and add code
        like this:
		[code]
    ''' <summary>
    ''' Normal data source
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Load the xml file and convert it to DataTable variable.
            Dim xmlDoc As XDocument = XDocument.Load(Server.MapPath("~/Data.xml"))
            Dim results = From result In xmlDoc.Element("Root").Elements()
                          Select result
            Dim tabXml As New DataTable()
            tabXml.Columns.Add("ID", Type.[GetType]("System.Int32"))
            tabXml.Columns.Add("Name", Type.[GetType]("System.String"))
            tabXml.Columns.Add("Age", Type.[GetType]("System.Int32"))
            tabXml.Columns.Add("Telephone", Type.[GetType]("System.String"))
            tabXml.Columns.Add("Comment", Type.[GetType]("System.String"))
            Dim row As DataRow = tabXml.NewRow()
            row("ID") = 0
            row("Name") = "None"
            row("Age") = 0
            row("Telephone") = "None"
            row("Comment") = "None"
            tabXml.Rows.Add(row)
            For Each result As Object In results
                Dim tabRow As DataRow = tabXml.NewRow()
                tabRow("ID") = Convert.ToInt32(result.Element("ID").Value)
                tabRow("Name") = result.Element("Name").Value
                tabRow("Age") = Convert.ToInt32(result.Element("Age").Value)
                tabRow("Telephone") = result.Element("Telephone").Value
                tabRow("Comment") = result.Element("Comment").Value
                tabXml.Rows.Add(tabRow)
            Next

            ' Customized DropDownList control data binding by DataTable.
            customizedDropDownList.DataSource = tabXml.AsDataView()
            customizedDropDownList.DataTextField = "Name"
            customizedDropDownList.DataValueField = "ID"
            customizedDropDownList.DataBind()
            customizedDropDownList.SelectedValue = "13"

            ' GridView control data binding by DataTable.
            Dim rowGridView As DataRow = tabXml.NewRow()
            rowGridView("ID") = 1000
            rowGridView("Name") = "Ann Anna"
            rowGridView("Age") = 21
            rowGridView("Telephone") = "111111"
            rowGridView("Comment") = "None"
            tabXml.Rows.Add(rowGridView)
            Dim rowGridView2 As DataRow = tabXml.NewRow()
            rowGridView2("ID") = 1001
            rowGridView2("Name") = "Bill Brand"
            rowGridView2("Age") = 41
            rowGridView2("Telephone") = "111112"
            rowGridView2("Comment") = "None"
            tabXml.Rows.Add(rowGridView2)
            tabXml.Rows.Remove(row)
            gvwDropDownListSource.DataSource = tabXml
            gvwDropDownListSource.DataBind()
        End If

    End Sub

    Protected Sub gvwDropDownListSource_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvwDropDownListSource.RowCommand
        If e.CommandName = "Select" Then
            Dim rowIndex As Integer
            Dim convertFlag As Boolean = Integer.TryParse(e.CommandArgument.ToString(), rowIndex)
            If convertFlag Then
                customizedDropDownList.SelectedValue = gvwDropDownListSource.Rows(rowIndex).Cells(0).Text
            Else
                Response.Write("The row index is not correct.")
            End If
        End If

    End Sub
	    [/code] 

Step 7. Add a GridView and a DropDownList control on TestObjectDataSource.aspx page, and add code
        like this:
		[code]
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Load Xml file and convert it to List<T> variable.
        If Not IsPostBack Then
            Dim xmlDoc As XDocument = XDocument.Load(Server.MapPath("~/Data.xml"))
            Dim entities As List(Of DataEntity) = (From result In xmlDoc.Descendants("Person")
                                                   Select New DataEntity() With { _
             .ID = Convert.ToInt32(result.Element("ID").Value), _
             .Name = result.Element("Name").Value, _
             .Age = Convert.ToInt32(result.Element("Age").Value), _
             .Telephone = result.Element("Telephone").Value, _
             .Comment = result.Element("Comment").Value _
            }).ToList()

            ' Customized DropDownList control data binding by IEnumberable.
            customizedDropDownList.DataSource = TryCast(entities, IEnumerable(Of DataEntity))
            customizedDropDownList.DataTextField = "Name"
            customizedDropDownList.DataValueField = "ID"
            customizedDropDownList.DataBind()
            customizedDropDownList.Items.Insert(0, New ListItem("None", "0"))
            customizedDropDownList.SelectedValue = "12"

            ' GridView control data binding by IEnumberable.
            Dim list As List(Of DataEntity) = TryCast(entities, List(Of DataEntity))
            Dim entitySingle As New DataEntity()
            entitySingle.ID = 1000
            entitySingle.Name = "Ann Anna"
            entitySingle.Age = 21
            entitySingle.Telephone = "111111"
            entitySingle.Comment = "None"
            list.Add(entitySingle)
            Dim entitySingle2 As New DataEntity()
            entitySingle2.ID = 1001
            entitySingle2.Name = "Bill Brand"
            entitySingle2.Age = 41
            entitySingle2.Telephone = "111112"
            entitySingle2.Comment = "None"
            list.Add(entitySingle2)

            gvwDropDownListSource.DataSource = TryCast(entities, IEnumerable(Of DataEntity))
            gvwDropDownListSource.DataBind()
        End If

    End Sub

    Protected Sub gvwDropDownListSource_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvwDropDownListSource.RowCommand
        If e.CommandName = "Select" Then
            Dim rowIndex As Integer
            Dim convertFlag As Boolean = Integer.TryParse(e.CommandArgument.ToString(), rowIndex)
            If convertFlag Then
                Dim num As Integer = gvwDropDownListSource.Rows.Count
                customizedDropDownList.SelectedValue = gvwDropDownListSource.Rows(rowIndex).Cells(0).Text
            Else
                Response.Write("The row index is not correct.")
            End If
        End If

    End Sub
		[/code]

Step 8. Build the application and you can debug it.


/////////////////////////////////////////////////////////////////////////////
References:

MSDN: ASP.NET server controls overview
http://support.microsoft.com/kb/306459

MSDN: ListControl.SelectedValue Property 
http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.listcontrol.selectedvalue.aspx

MSDN: DataView Class
http://msdn.microsoft.com/en-us/library/system.data.dataview.aspx

MSDN: IEnumerable Interface
http://msdn.microsoft.com/en-us/library/system.collections.ienumerable.aspx
/////////////////////////////////////////////////////////////////////////////