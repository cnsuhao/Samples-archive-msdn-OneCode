================================================================================
       WPF APPLICATION: VBWPFSearchAndHighlightTextBlockControl Overview                        
================================================================================

/////////////////////////////////////////////////////////////////////////////
Summary:

The WPF code sample demonstrates how to search and highlight keywords in a 
TextBlock control. 

The sample includes a custom user control "SearchableTextControl" and its search 
method is used to demonstrate how to highlight keywords using 
System.Windows.Documents.Run and System.Windows.Documents.Incline.


////////////////////////////////////////////////////////////////////////////////
Demo:

Step1. Build this project in VS2010. 

Step2. Run VBWPFSearchAndHighlightTextBlockControl.exe.

Step3. Input the source string after the "Source Text" TextBlock.

Step4. Type the keyword string which you want to search in the source string
       after the "Search" TextBlock.

Step5. You can change the Background/Foreground colors by selecting the specific color 
       in drop-list of combobox. 
       

/////////////////////////////////////////////////////////////////////////////
Code Logic:

Step 1. Create a Visual Basic WPF Application in Visual Studio 2010 and name it 
        "VBWPFSearchAndHighlightTextBlockControl".

Step 2. Create a class "SearchableTextControl". Make sure it inherits from the "Control" class.

Step 3. The "SearchableTextControl" class uses DependencyProperty.Register to implement
		a render bound to custom user control such as:

		''' <summary>
		''' SearchText sandbox which is used to get or set the value from  a dependency property,
		''' if it gets a value,it should be forced to bind to a string type.
		''' </summary>
		Public Property SearchText() As String
			Get
				Return CStr(GetValue(SearchTextProperty))
			End Get
			Set(ByVal value As String)
				SetValue(SearchTextProperty, value)
			End Set
		End Property

		''' <summary>
		''' Real implementation about SearchTextProperty which registers a dependency property 
		''' with the specified property name, property type, owner type, and property metadata. 
		''' </summary>
		Public Shared ReadOnly SearchTextProperty As DependencyProperty = 
		DependencyProperty.Register("SearchText", GetType(String), GetType(SearchableTextControl), 
		New UIPropertyMetadata(String.Empty, AddressOf UpdateControlCallBack))

		''' <summary>
		''' Create a call back function which is used to invalidate the rendering of the element, and force 
		''' a complete new layout pass. One such advanced scenario is if you are creating a PropertyChangedCallback 
		''' for a dependency property that is not on a Freezable or FrameworkElement derived class that 
		''' still influences the layout when it changes.
		''' </summary>
		Private Shared Sub UpdateControlCallBack(ByVal d As DependencyObject, ByVal e As 
		DependencyPropertyChangedEventArgs)
			Dim obj As SearchableTextControl = TryCast(d, SearchableTextControl)
			obj.InvalidateVisual()
		End Sub

Step 4. In SearchableTextControl class, there is a override method "OnRender", this method uses 
		String.IndexOf and String.Substring methods to match the target string, and we associate
		those methods with TextBlock.Inlines.Add method in this sample. And in order to implement 
		the behavior which looks like capture of regular expression with several times.

Step 5. The method "GenerateRun" which in class SearchableTextControl is used to alternate the 
		colors of all matched strings.
         If Not String.IsNullOrEmpty(searchedString) Then
            Dim run_Renamed As New Run(searchedString) With {.Background =
                If(isHighlight, Me.HighlightBackground, Me.Background), .Foreground =
                If(isHighlight, Me.HighlightForeground, Me.Foreground),
                 .FontStyle = If(isHighlight, FontStyles.Italic, FontStyles.Normal
                                 ),
            .FontWeight = If(isHighlight, FontWeights.Bold, FontWeights.Normal
                                 )
                   }


            Return run_Renamed
        End If
        Return Nothing
    End Function


/////////////////////////////////////////////////////////////////////////////
References:

Run Class 
http://msdn.microsoft.com/query/dev10.query?appId=Dev10IDEF1&l=EN-US&k=k(SYSTEM.WINDOWS.DOCUMENTS.RUN);k(RUN);k(DevLang-CSHARP)&rd=true

DependencyProperty.OverrideMetadata Method 
http://msdn.microsoft.com/en-us/library/system.windows.dependencyproperty.overridemetadata.aspx

DependencyProperty.Register Method
http://msdn.microsoft.com/en-us/library/system.windows.dependencyproperty.register.aspx

FrameworkTemplate.FindName Method
http://msdn.microsoft.com/query/dev10.query?appId=Dev10IDEF1&l=EN-US&k=k(SYSTEM.WINDOWS.FRAMEWORKTEMPLATE.FINDNAME);k(TargetFrameworkMoniker-%22.NETFRAMEWORK%2cVERSION%3dV4.0%22);k(DevLang-CSHARP)&rd=true

UIElement.InvalidateVisual Method
http://msdn.microsoft.com/en-us/library/system.windows.uielement.invalidatevisual.aspx

/////////////////////////////////////////////////////////////////////////////
