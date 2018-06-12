'***************************** Module Header ******************************\
' Module Name:  StoreData.vb
' Project:      VBWindowsStoreAppAddItem
' Copyright (c) Microsoft Corporation.
'  
' This is the sample data which bind to the GridView
'   
'  
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
'  
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/


Imports System.Globalization

Public Class StoreData
    Public Shared ReadOnly BaseUri As New Uri("ms-appx:///")

    Private ReadOnly _collection As New ItemCollection()

    ''' <summary>
    ''' Initializes a new instance of the <see cref="StoreData"/> class.
    ''' </summary>
    Public Sub New()
        Dim item As Item
        Dim LONG_LOREM_IPSUM As String = String.Format("{0}" & vbCrLf & vbCrLf & "{0}" & vbCrLf & vbCrLf & "{0}" & vbCrLf & vbCrLf & "{0}", "Curabitur class aliquam vestibulum nam curae maecenas sed integer cras phasellus suspendisse quisque donec dis praesent accumsan bibendum pellentesque condimentum adipiscing etiam consequat vivamus dictumst aliquam duis convallis scelerisque est parturient ullamcorper aliquet fusce suspendisse nunc hac eleifend amet blandit facilisi condimentum commodo scelerisque faucibus aenean ullamcorper ante mauris dignissim consectetuer nullam lorem vestibulum habitant conubia elementum pellentesque morbi facilisis arcu sollicitudin diam cubilia aptent vestibulum auctor eget dapibus pellentesque inceptos leo egestas interdum nulla consectetuer suspendisse adipiscing pellentesque proin lobortis sollicitudin augue elit mus congue fermentum parturient fringilla euismod feugiat")        

	 item = New Item
        item.Title = "Banana Blast Frozen Yogurt"
        item.Subtitle = "Maecenas class nam praesent cras aenean mauris aliquam nullam aptent accumsan duis nunc curae donec integer auctor sed congue amet"
        item.SetImage(BaseUri, "SampleData/Images/60Banana.png")
        item.Link = "http://www.adatum.com/"
        item.Category = "Low-fat frozen yogurt"
        item.Description = "Curabitur class aliquam vestibulum nam curae maecenas sed integer cras phasellus suspendisse quisque donec dis praesent accumsan bibendum pellentesque condimentum adipiscing etiam consequat vivamus dictumst aliquam duis convallis scelerisque est parturient ullamcorper aliquet fusce suspendisse nunc hac eleifend amet blandit facilisi condimentum commodo scelerisque faucibus aenean ullamcorper ante mauris dignissim consectetuer nullam lorem vestibulum habitant conubia elementum pellentesque morbi facilisis arcu sollicitudin diam cubilia aptent vestibulum auctor eget dapibus pellentesque inceptos leo egestas interdum nulla consectetuer suspendisse adipiscing pellentesque proin lobortis sollicitudin augue elit mus congue fermentum parturient fringilla euismod feugiat"
        item.Content = LONG_LOREM_IPSUM
        _collection.Add(item)

        item = New Item
        item.Title = "Lavish Lemon Ice"
        item.Subtitle = "Quisque vivamus bibendum cursus dictum dictumst dis aliquam aliquet etiam lectus eleifend fusce libero ante facilisi ligula est"
        item.SetImage(BaseUri, "SampleData/Images/60Lemon.png")
        item.Link = "http://www.adventure-works.com/"
        item.Category = "Sorbet"
        item.Description = "Enim cursus nascetur dictum habitasse hendrerit nec gravida vestibulum pellentesque vestibulum adipiscing iaculis erat consectetuer pellentesque parturient lacinia himenaeos pharetra condimentum non sollicitudin eros dolor vestibulum per lectus pellentesque nibh imperdiet laoreet consectetuer placerat libero malesuada pellentesque fames penatibus ligula scelerisque litora nisi luctus vestibulum nisl ullamcorper sed sem natoque suspendisse felis sit condimentum pulvinar nunc posuere magnis vel scelerisque sagittis porttitor potenti tincidunt mattis ipsum adipiscing sollicitudin parturient mauris nam senectus ullamcorper mollis tristique sociosqu suspendisse ultricies montes sed condimentum dis nostra suscipit justo ornare pretium odio pellentesque lacus lorem torquent orci"
        item.Content = LONG_LOREM_IPSUM
        _collection.Add(item)

        item = New Item
        item.Title = "Marvelous Mint"
        item.Subtitle = "Litora luctus magnis arcu lorem morbi blandit faucibus mattis commodo hac habitant inceptos conubia cubilia nulla mauris diam proin augue eget dolor mollis interdum lobortis"
        item.SetImage(BaseUri, "SampleData/Images/60Mint.png")
        item.Link = "http://www.adventure-works.com/"
        item.Category = "Gelato"
        item.Description = "Vestibulum vestibulum magna scelerisque ultrices consectetuer vehicula rhoncus pellentesque massa adipiscing platea primis sodales parturient metus sollicitudin morbi vestibulum pellentesque consectetuer pellentesque volutpat rutrum sollicitudin sapien pellentesque vestibulum venenatis consectetuer viverra est aliquam semper hac maecenas integer adipiscing sociis vulputate ullamcorper curabitur pellentesque parturient praesent neque sollicitudin pellentesque vestibulum suspendisse consectetuer leo quisque phasellus pede vestibulum quam pellentesque sollicitudin quis mus adipiscing parturient pellentesque vestibulum"
        item.Content = LONG_LOREM_IPSUM
        _collection.Add(item)

        item = New Item
        item.Title = "Creamy Orange"
        item.Subtitle = "Leo mus nec nascetur dapibus non fames per felis ipsum pharetra egestas montes elit nostra placerat euismod enim justo ornare feugiat platea pulvinar sed sagittis"
        item.SetImage(BaseUri, "SampleData/Images/60Orange.png")
        item.Link = "http://www.alpineskihouse.com/"
        item.Category = "Sorbet"
        item.Description = "Consequat condimentum consectetuer vivamus urna vestibulum netus pellentesque cras nec taciti non scelerisque adipiscing parturient tellus sollicitudin per vestibulum pellentesque aliquam convallis ullamcorper nulla porta aliquet accumsan suspendisse duis bibendum nunc condimentum consectetuer pellentesque scelerisque tempor sed dictumst eleifend amet vestibulum sem tempus facilisi ullamcorper adipiscing tortor ante purus parturient sit dignissim vel nam turpis sed sollicitudin elementum arcu vestibulum risus blandit suspendisse faucibus pellentesque commodo dis condimentum consectetuer varius aenean conubia cubilia facilisis velit mauris nullam aptent dapibus habitant"
        item.Content = LONG_LOREM_IPSUM
        _collection.Add(item)

        item = New Item
        item.Title = "Succulent Strawberry"
        item.Subtitle = "Senectus sem lacus erat sociosqu eros suscipit primis nibh nisi nisl gravida torquent"
        item.SetImage(BaseUri, "SampleData/Images/60Strawberry.png")
        item.Link = "http://www.baldwinmuseumofscience.com/"
        item.Category = "Sorbet"
        item.Description = "Est auctor inceptos congue interdum egestas scelerisque pellentesque fermentum ullamcorper cursus dictum lectus suspendisse condimentum libero vitae vestibulum lobortis ligula fringilla euismod class scelerisque feugiat habitasse diam litora adipiscing sollicitudin parturient hendrerit curae himenaeos imperdiet ullamcorper suspendisse nascetur hac gravida pharetra eget donec leo mus nec non malesuada vestibulum pellentesque elit penatibus vestibulum per condimentum porttitor sed adipiscing scelerisque ullamcorper etiam iaculis enim tincidunt erat parturient sem vestibulum eros"
        item.Content = LONG_LOREM_IPSUM
        _collection.Add(item)

        item = New Item
        item.Title = "Very Vanilla"
        item.Subtitle = "Ultrices rutrum sapien vehicula semper lorem volutpat sociis sit maecenas praesent taciti magna nunc odio orci vel tellus nam sed accumsan iaculis dis est"
        item.SetImage(BaseUri, "SampleData/Images/60Vanilla.png")
        item.Link = "http://www.blueyonderairlines.com/"
        item.Category = "Ice Cream"
        item.Description = "Consectetuer lacinia vestibulum tristique sit adipiscing laoreet fusce nibh suspendisse natoque placerat pulvinar ultricies condimentum scelerisque nisi ullamcorper nisl parturient vel suspendisse nam venenatis nunc lorem sed dis sagittis pellentesque luctus sollicitudin morbi posuere vestibulum potenti magnis pellentesque vulputate mattis mauris mollis consectetuer pellentesque pretium montes vestibulum condimentum nulla adipiscing sollicitudin scelerisque ullamcorper pellentesque odio orci rhoncus pede sodales suspendisse parturient viverra curabitur proin aliquam integer augue quam condimentum quisque senectus quis urna scelerisque nostra phasellus ullamcorper cras duis suspendisse sociosqu dolor vestibulum condimentum consectetuer vivamus est fames felis suscipit hac"
        item.Content = LONG_LOREM_IPSUM
        _collection.Add(item)

        item = New Item
        item.Title = "Creamy Caramel Frozen Yogurt"
        item.Subtitle = "Maecenas class nam praesent cras aenean mauris aliquam nullam aptent accumsan duis nunc curae donec integer auctor sed congue amet"
        item.SetImage(BaseUri, "SampleData/Images/60SauceCaramel.png")
        item.Link = "http://www.adatum.com/"
        item.Category = "Low-fat frozen yogurt"
        item.Description = "Curabitur class aliquam vestibulum nam curae maecenas sed integer cras phasellus suspendisse quisque donec dis praesent accumsan bibendum pellentesque condimentum adipiscing etiam consequat vivamus dictumst aliquam duis convallis scelerisque est parturient ullamcorper aliquet fusce suspendisse nunc hac eleifend amet blandit facilisi condimentum commodo scelerisque faucibus aenean ullamcorper ante mauris dignissim consectetuer nullam lorem vestibulum habitant conubia elementum pellentesque morbi facilisis arcu sollicitudin diam cubilia aptent vestibulum auctor eget dapibus pellentesque inceptos leo egestas interdum nulla consectetuer suspendisse adipiscing pellentesque proin lobortis sollicitudin augue elit mus congue fermentum parturient fringilla euismod feugiat"
        item.Content = LONG_LOREM_IPSUM
        _collection.Add(item)

        item = New Item
        item.Title = "Chocolate Lovers Frozen Yougurt"
        item.Subtitle = "Quisque vivamus bibendum cursus dictum dictumst dis aliquam aliquet etiam lectus eleifend fusce libero ante facilisi ligula est"
        item.SetImage(BaseUri, "SampleData/Images/60SauceChocolate.png")
        item.Link = "http://www.adventure-works.com/"
        item.Category = "Low-fat frozen yogurt"
        item.Description = "Enim cursus nascetur dictum habitasse hendrerit nec gravida vestibulum pellentesque vestibulum adipiscing iaculis erat consectetuer pellentesque parturient lacinia himenaeos pharetra condimentum non sollicitudin eros dolor vestibulum per lectus pellentesque nibh imperdiet laoreet consectetuer placerat libero malesuada pellentesque fames penatibus ligula scelerisque litora nisi luctus vestibulum nisl ullamcorper sed sem natoque suspendisse felis sit condimentum pulvinar nunc posuere magnis vel scelerisque sagittis porttitor potenti tincidunt mattis ipsum adipiscing sollicitudin parturient mauris nam senectus ullamcorper mollis tristique sociosqu suspendisse ultricies montes sed condimentum dis nostra suscipit justo ornare pretium odio pellentesque lacus lorem torquent orci"
        item.Content = LONG_LOREM_IPSUM
        _collection.Add(item)

        item = New Item
        item.Title = "Roma Strawberry"
        item.Subtitle = "Litora luctus magnis arcu lorem morbi blandit faucibus mattis commodo hac habitant inceptos conubia cubilia nulla mauris diam proin augue eget dolor mollis interdum lobortis"
        item.SetImage(BaseUri, "SampleData/Images/60Strawberry.png")
        item.Link = "http://www.adventure-works.com/"
        item.Category = "Gelato"
        item.Description = "Vestibulum vestibulum magna scelerisque ultrices consectetuer vehicula rhoncus pellentesque massa adipiscing platea primis sodales parturient metus sollicitudin morbi vestibulum pellentesque consectetuer pellentesque volutpat rutrum sollicitudin sapien pellentesque vestibulum venenatis consectetuer viverra est aliquam semper hac maecenas integer adipiscing sociis vulputate ullamcorper curabitur pellentesque parturient praesent neque sollicitudin pellentesque vestibulum suspendisse consectetuer leo quisque phasellus pede vestibulum quam pellentesque sollicitudin quis mus adipiscing parturient pellentesque vestibulum"
        item.Content = LONG_LOREM_IPSUM
        _collection.Add(item)

        item = New Item
        item.Title = "Italian Rainbow"
        item.Subtitle = "Leo mus nec nascetur dapibus non fames per felis ipsum pharetra egestas montes elit nostra placerat euismod enim justo ornare feugiat platea pulvinar sed sagittis"
        item.SetImage(BaseUri, "SampleData/Images/60SprinklesRainbow.png")
        item.Link = "http://www.alpineskihouse.com/"
        item.Category = "Gelato"
        item.Description = "Consequat condimentum consectetuer vivamus urna vestibulum netus pellentesque cras nec taciti non scelerisque adipiscing parturient tellus sollicitudin per vestibulum pellentesque aliquam convallis ullamcorper nulla porta aliquet accumsan suspendisse duis bibendum nunc condimentum consectetuer pellentesque scelerisque tempor sed dictumst eleifend amet vestibulum sem tempus facilisi ullamcorper adipiscing tortor ante purus parturient sit dignissim vel nam turpis sed sollicitudin elementum arcu vestibulum risus blandit suspendisse faucibus pellentesque commodo dis condimentum consectetuer varius aenean conubia cubilia facilisis velit mauris nullam aptent dapibus habitant"
        item.Content = LONG_LOREM_IPSUM
        _collection.Add(item)

        item = New Item
        item.Title = "Straweberry"
        item.Subtitle = "Ultrices rutrum sapien vehicula semper lorem volutpat sociis sit maecenas praesent taciti magna nunc odio orci vel tellus nam sed accumsan iaculis dis est"
        item.SetImage(BaseUri, "SampleData/Images/60Strawberry.png")
        item.Link = "http://www.blueyonderairlines.com/"
        item.Category = "Ice Cream"
        item.Description = "Consectetuer lacinia vestibulum tristique sit adipiscing laoreet fusce nibh suspendisse natoque placerat pulvinar ultricies condimentum scelerisque nisi ullamcorper nisl parturient vel suspendisse nam venenatis nunc lorem sed dis sagittis pellentesque luctus sollicitudin morbi posuere vestibulum potenti magnis pellentesque vulputate mattis mauris mollis consectetuer pellentesque pretium montes vestibulum condimentum nulla adipiscing sollicitudin scelerisque ullamcorper pellentesque odio orci rhoncus pede sodales suspendisse parturient viverra curabitur proin aliquam integer augue quam condimentum quisque senectus quis urna scelerisque nostra phasellus ullamcorper cras duis suspendisse sociosqu dolor vestibulum condimentum consectetuer vivamus est fames felis suscipit hac"
        item.Content = LONG_LOREM_IPSUM
        _collection.Add(item)

        item = New Item
        item.Title = "Strawberry Frozen Yogurt"
        item.Subtitle = "Maecenas class nam praesent cras aenean mauris aliquam nullam aptent accumsan duis nunc curae donec integer auctor sed congue amet"
        item.SetImage(BaseUri, "SampleData/Images/60Strawberry.png")
        item.Link = "http://www.adatum.com/"
        item.Category = "Low-fat frozen yogurt"
        item.Description = "Curabitur class aliquam vestibulum nam curae maecenas sed integer cras phasellus suspendisse quisque donec dis praesent accumsan bibendum pellentesque condimentum adipiscing etiam consequat vivamus dictumst aliquam duis convallis scelerisque est parturient ullamcorper aliquet fusce suspendisse nunc hac eleifend amet blandit facilisi condimentum commodo scelerisque faucibus aenean ullamcorper ante mauris dignissim consectetuer nullam lorem vestibulum habitant conubia elementum pellentesque morbi facilisis arcu sollicitudin diam cubilia aptent vestibulum auctor eget dapibus pellentesque inceptos leo egestas interdum nulla consectetuer suspendisse adipiscing pellentesque proin lobortis sollicitudin augue elit mus congue fermentum parturient fringilla euismod feugiat"
        item.Content = LONG_LOREM_IPSUM
        _collection.Add(item)

        item = New Item
        item.Title = "Bongo Banana"
        item.Subtitle = "Quisque vivamus bibendum cursus dictum dictumst dis aliquam aliquet etiam lectus eleifend fusce libero ante facilisi ligula est"
        item.SetImage(BaseUri, "SampleData/Images/60Banana.png")
        item.Link = "http://www.adventure-works.com/"
        item.Category = "Sorbet"
        item.Description = "Enim cursus nascetur dictum habitasse hendrerit nec gravida vestibulum pellentesque vestibulum adipiscing iaculis erat consectetuer pellentesque parturient lacinia himenaeos pharetra condimentum non sollicitudin eros dolor vestibulum per lectus pellentesque nibh imperdiet laoreet consectetuer placerat libero malesuada pellentesque fames penatibus ligula scelerisque litora nisi luctus vestibulum nisl ullamcorper sed sem natoque suspendisse felis sit condimentum pulvinar nunc posuere magnis vel scelerisque sagittis porttitor potenti tincidunt mattis ipsum adipiscing sollicitudin parturient mauris nam senectus ullamcorper mollis tristique sociosqu suspendisse ultricies montes sed condimentum dis nostra suscipit justo ornare pretium odio pellentesque lacus lorem torquent orci"
        item.Content = LONG_LOREM_IPSUM
        _collection.Add(item)

        item = New Item
        item.Title = "Firenze Vanilla"
        item.Subtitle = "Litora luctus magnis arcu lorem morbi blandit faucibus mattis commodo hac habitant inceptos conubia cubilia nulla mauris diam proin augue eget dolor mollis interdum lobortis"
        item.SetImage(BaseUri, "SampleData/Images/60Vanilla.png")
        item.Link = "http://www.adventure-works.com/"
        item.Category = "Gelato"
        item.Description = "Vestibulum vestibulum magna scelerisque ultrices consectetuer vehicula rhoncus pellentesque massa adipiscing platea primis sodales parturient metus sollicitudin morbi vestibulum pellentesque consectetuer pellentesque volutpat rutrum sollicitudin sapien pellentesque vestibulum venenatis consectetuer viverra est aliquam semper hac maecenas integer adipiscing sociis vulputate ullamcorper curabitur pellentesque parturient praesent neque sollicitudin pellentesque vestibulum suspendisse consectetuer leo quisque phasellus pede vestibulum quam pellentesque sollicitudin quis mus adipiscing parturient pellentesque vestibulum"
        item.Content = LONG_LOREM_IPSUM
        _collection.Add(item)

        item = New Item
        item.Title = "Choco-wocko"
        item.Subtitle = "Leo mus nec nascetur dapibus non fames per felis ipsum pharetra egestas montes elit nostra placerat euismod enim justo ornare feugiat platea pulvinar sed sagittis"
        item.SetImage(BaseUri, "SampleData/Images/60SauceChocolate.png")
        item.Link = "http://www.alpineskihouse.com/"
        item.Category = "Sorbet"
        item.Description = "Consequat condimentum consectetuer vivamus urna vestibulum netus pellentesque cras nec taciti non scelerisque adipiscing parturient tellus sollicitudin per vestibulum pellentesque aliquam convallis ullamcorper nulla porta aliquet accumsan suspendisse duis bibendum nunc condimentum consectetuer pellentesque scelerisque tempor sed dictumst eleifend amet vestibulum sem tempus facilisi ullamcorper adipiscing tortor ante purus parturient sit dignissim vel nam turpis sed sollicitudin elementum arcu vestibulum risus blandit suspendisse faucibus pellentesque commodo dis condimentum consectetuer varius aenean conubia cubilia facilisis velit mauris nullam aptent dapibus habitant"
        item.Content = LONG_LOREM_IPSUM
        _collection.Add(item)

        item = New Item
        item.Title = "Chocolate"
        item.Subtitle = "Ultrices rutrum sapien vehicula semper lorem volutpat sociis sit maecenas praesent taciti magna nunc odio orci vel tellus nam sed accumsan iaculis dis est"
        item.SetImage(BaseUri, "SampleData/Images/60SauceChocolate.png")
        item.Link = "http://www.blueyonderairlines.com/"
        item.Category = "Ice Cream"
        item.Description = "Consectetuer lacinia vestibulum tristique sit adipiscing laoreet fusce nibh suspendisse natoque placerat pulvinar ultricies condimentum scelerisque nisi ullamcorper nisl parturient vel suspendisse nam venenatis nunc lorem sed dis sagittis pellentesque luctus sollicitudin morbi posuere vestibulum potenti magnis pellentesque vulputate mattis mauris mollis consectetuer pellentesque pretium montes vestibulum condimentum nulla adipiscing sollicitudin scelerisque ullamcorper pellentesque odio orci rhoncus pede sodales suspendisse parturient viverra curabitur proin aliquam integer augue quam condimentum quisque senectus quis urna scelerisque nostra phasellus ullamcorper cras duis suspendisse sociosqu dolor vestibulum condimentum consectetuer vivamus est fames felis suscipit hac"
        item.Content = LONG_LOREM_IPSUM
        _collection.Add(item)
    End Sub

    ''' <summary>
    ''' Gets the collection.
    ''' </summary>
    Public ReadOnly Property Collection() As ItemCollection
        Get
            Return _collection
        End Get
    End Property

    ''' <summary>
    ''' The method returns the list of groups, each containing a key and a list of items. 
    ''' The key of each group is the category of the item. 
    ''' </summary>
    ''' <returns>
    ''' The List of groups of items. 
    ''' </returns>
    Friend Function GetGroupsByCategory() As ObservableCollection(Of GroupInfoCollection(Of Item))
        Dim groups As New ObservableCollection(Of GroupInfoCollection(Of Item))()

        Dim query = From item In _collection
                        Order By (CType(item, Item)).Category
                        Group item By GroupKey = (CType(item, Item)).Category Into g = Group
                        Select New With {Key .GroupName = GroupKey, Key .Items = g}

        For Each g In query
            Dim info As New GroupInfoCollection(Of Item)
            info.Key = g.GroupName

            For Each item In g.Items
                info.Add(item)
            Next item

            groups.Add(info)
        Next g

        Return groups
    End Function

End Class
