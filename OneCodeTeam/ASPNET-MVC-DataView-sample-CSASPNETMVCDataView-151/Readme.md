# ASP.NET MVC DataView sample (CSASPNETMVCDataView)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* ASP.NET
* ASP.NET MVC
## Topics
* login
## IsPublished
* True
## ModifiedDate
* 2012-09-26 12:02:56
## Description

<h1><a name="OLE_LINK9"></a><a name="OLE_LINK8"><span style=""><span style="">How to use DataViews in MVC to handle the data processing work</span>(</span></a><span style=""><span style=""><span style="">CSASPNETMVCDataView</span>)</span></span></h1>
<h2>Introduction </h2>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow the steps below. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Open the CSASPNETMVCDataView.sln file. Press &quot;Ctrl&#43;F5&quot; to view the index page.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/67247/1/image.png" alt="" width="1079" height="530" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Click on the &quot;Open Person List&quot; link, we will see the index page of Person folder.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/67248/1/image.png" alt="" width="995" height="265" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Click on the &quot;Create New&quot; link to create a new item. </span>
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/67249/1/image.png" alt="" width="969" height="507" align="middle">
</span><span style=""><br>
<span style="">Click the button to create. </span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/67250/1/image.png" alt="" width="779" height="242" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">We can click on the &quot;Edit&quot; link to edit the selected item.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/67251/1/image.png" alt="" width="585" height="473" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">We can click on the &quot;Details&quot; to view the item detail. </span>
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/67252/1/image.png" alt="" width="343" height="341" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">We can click on the &quot;Delete&quot; to delete the item. </span>
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/67253/1/image.png" alt="" width="422" height="312" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 3: Validation is completed. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: </span></p>
<p class="MsoNormal" style=""><span style="">Step1. Create a C# ASP.NET MVC 4 Web Application in Visual Studio 2012 and name it as CSASPNETMVCDataView. In the project template tab, select Internet Application and then select ASPX as view engine.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step2. Create PersonalController.cs file in Controllers folder. </span>
The code of the <span style="">PersonalController</span> file will be shown as below:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public class PersonController : Controller
   {
       static List&lt;Person&gt; people = new List&lt;Person&gt;();


       //
       // GET: /Person/


       public ActionResult Index()
       {
           return View(people);
       }


       //
       // GET: /Person/Details/5


       public ActionResult Details(Person p)
       {
           return View(p);
       }


       //
       // GET: /Person/Create


       public ActionResult Create()
       {
           return View();
       } 


       //
       // POST: /Person/Create


       [HttpPost]
       public ActionResult Create(Person p)
       {                      
           if (!ModelState.IsValid)
           {
               return View(&quot;Create&quot;, p);
           }


           people.Add(p);


           return RedirectToAction(&quot;Index&quot;);
       }


       //
       // GET: /Person/Delete/5


       public ActionResult Delete(int id)
       {
           Person p = new Person();
           foreach (Person pn in people)
           {
               if (pn.Id == id)
               {
                   p.Name = pn.Name;
                   p.Age = pn.Age;
                   p.Id = pn.Id;
                   p.Phone = pn.Phone;
                   p.Email = pn.Email;
               }
           }


           return View(p);
       }


       //
       // POST: /Person/Delete/5


       [HttpPost]
       public ActionResult Delete(Person p)
       {
           foreach (Person pn in people)
           {
               if (pn.Id == p.Id)
               {
                   people.Remove(pn);
                   break;
               }
           }


           return RedirectToAction(&quot;Index&quot;);
       }


       //
       // GET: /Person/Edit/5


       public ActionResult Edit(int id)
       {
           Person p = new Person();
           foreach (Person pn in people)
           {
               if (pn.Id == id)
               {
                   p.Name = pn.Name;
                   p.Age = pn.Age;
                   p.Id = pn.Id;
                   p.Phone = pn.Phone;
                   p.Email = pn.Email;
               }
           }


           return View(p);
       }


       //
       // POST: /Person/Edit/5


       [HttpPost]
       public ActionResult Edit(Person p)
       {
           if (!ModelState.IsValid)
           {
               return View(&quot;Edit&quot;, p);
           }


           foreach (Person pn in people)
           {
               if (pn.Id == p.Id)
               {
                   pn.Name = p.Name;
                   pn.Age = p.Age;
                   pn.Id = p.Id;
                   pn.Phone = p.Phone;
                   pn.Email = p.Email;
               }
           }


           return RedirectToAction(&quot;Index&quot;);
       }
   }

</pre>
<pre id="codePreview" class="csharp">
public class PersonController : Controller
   {
       static List&lt;Person&gt; people = new List&lt;Person&gt;();


       //
       // GET: /Person/


       public ActionResult Index()
       {
           return View(people);
       }


       //
       // GET: /Person/Details/5


       public ActionResult Details(Person p)
       {
           return View(p);
       }


       //
       // GET: /Person/Create


       public ActionResult Create()
       {
           return View();
       } 


       //
       // POST: /Person/Create


       [HttpPost]
       public ActionResult Create(Person p)
       {                      
           if (!ModelState.IsValid)
           {
               return View(&quot;Create&quot;, p);
           }


           people.Add(p);


           return RedirectToAction(&quot;Index&quot;);
       }


       //
       // GET: /Person/Delete/5


       public ActionResult Delete(int id)
       {
           Person p = new Person();
           foreach (Person pn in people)
           {
               if (pn.Id == id)
               {
                   p.Name = pn.Name;
                   p.Age = pn.Age;
                   p.Id = pn.Id;
                   p.Phone = pn.Phone;
                   p.Email = pn.Email;
               }
           }


           return View(p);
       }


       //
       // POST: /Person/Delete/5


       [HttpPost]
       public ActionResult Delete(Person p)
       {
           foreach (Person pn in people)
           {
               if (pn.Id == p.Id)
               {
                   people.Remove(pn);
                   break;
               }
           }


           return RedirectToAction(&quot;Index&quot;);
       }


       //
       // GET: /Person/Edit/5


       public ActionResult Edit(int id)
       {
           Person p = new Person();
           foreach (Person pn in people)
           {
               if (pn.Id == id)
               {
                   p.Name = pn.Name;
                   p.Age = pn.Age;
                   p.Id = pn.Id;
                   p.Phone = pn.Phone;
                   p.Email = pn.Email;
               }
           }


           return View(p);
       }


       //
       // POST: /Person/Edit/5


       [HttpPost]
       public ActionResult Edit(Person p)
       {
           if (!ModelState.IsValid)
           {
               return View(&quot;Edit&quot;, p);
           }


           foreach (Person pn in people)
           {
               if (pn.Id == p.Id)
               {
                   pn.Name = p.Name;
                   pn.Age = p.Age;
                   pn.Id = p.Id;
                   pn.Phone = p.Phone;
                   pn.Email = p.Email;
               }
           }


           return RedirectToAction(&quot;Index&quot;);
       }
   }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""><br>
Step3. Create Person.cs file in Models folder.<span style="">&nbsp; </span></span>The code of the
<span style="">Person</span> file will be shown as below:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public class Person
   {
       [Required(ErrorMessage = &quot;The ID is required.&quot;)]
       public int Id { get; set; }


       [Required(ErrorMessage = &quot;The name is required.&quot;)]
       public string Name { get; set; }


       [Range(1, 200, ErrorMessage = &quot;A number between 1 and 200.&quot;)]
       public int Age { get; set; }


       [RegularExpression(@&quot;(^189\d{8}$)|(^13\d{9}$)|(^15\d{9}$)&quot;, 
           ErrorMessage = &quot;Invalid phone number. 11 length and start with 13,15,189 prefix. e.g. 13800138000&quot;)]
       public string Phone { get; set; }


       [RegularExpression(@&quot;^[\w-\.]&#43;@([\w-]&#43;\.)&#43;[\w-]{2,4}$&quot;, 
           ErrorMessage = &quot;Invalid email address.&quot;)]
       public string Email { get; set; }
   }

</pre>
<pre id="codePreview" class="csharp">
public class Person
   {
       [Required(ErrorMessage = &quot;The ID is required.&quot;)]
       public int Id { get; set; }


       [Required(ErrorMessage = &quot;The name is required.&quot;)]
       public string Name { get; set; }


       [Range(1, 200, ErrorMessage = &quot;A number between 1 and 200.&quot;)]
       public int Age { get; set; }


       [RegularExpression(@&quot;(^189\d{8}$)|(^13\d{9}$)|(^15\d{9}$)&quot;, 
           ErrorMessage = &quot;Invalid phone number. 11 length and start with 13,15,189 prefix. e.g. 13800138000&quot;)]
       public string Phone { get; set; }


       [RegularExpression(@&quot;^[\w-\.]&#43;@([\w-]&#43;\.)&#43;[\w-]{2,4}$&quot;, 
           ErrorMessage = &quot;Invalid email address.&quot;)]
       public string Email { get; set; }
   }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span style=""><span style="">&nbsp;</span>Step4. Add Person folder in Views folder and create the corresponding files. We will add 5 ASPX pages: Create.aspx, Delete.aspx, Details.aspx, Edit.aspx and Index.aspx. Create the logics
 for Views according to the sample project.<br>
Index.aspx </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
&lt;asp:Content ID=&quot;Content2&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;


    <h2>Index</h2>


    <table><tbody><tr><th></th><th>Id </th><th>Name </th><th>Age </th><th>Phone </th><th>Email </th></tr>


    &lt;%foreach (var item in Model) { %&gt;
    
        <tr><td>&lt;%=
 Html.ActionLink(&quot;Edit&quot;, &quot;Edit&quot;, new { id=item.Id }) %&gt; | &lt;%= Html.ActionLink(&quot;Details&quot;, &quot;Details&quot;, item )%&gt; | &lt;%= Html.ActionLink(&quot;Delete&quot;, &quot;Delete&quot;, new { id=item.Id })%&gt; </td><td>&lt;%= Html.Encode(item.Id) %&gt; </td><td>&lt;%= Html.Encode(item.Name) %&gt; </td><td>&lt;%=
 Html.Encode(item.Age) %&gt; </td><td>&lt;%= Html.Encode(item.Phone) %&gt; </td><td>&lt;%= Html.Encode(item.Email) %&gt; </td></tr>
    
    &lt;%} %&gt;


    </tbody></table>


    <p>
        &lt;%= Html.ActionLink(&quot;Create New&quot;, &quot;Create&quot;) %&gt;
    </p>


&lt;/asp:Content&gt;

</pre>
<pre id="codePreview" class="html">
&lt;asp:Content ID=&quot;Content2&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;


    <h2>Index</h2>


    <table><tbody><tr><th></th><th>Id </th><th>Name </th><th>Age </th><th>Phone </th><th>Email </th></tr>


    &lt;%foreach (var item in Model) { %&gt;
    
        <tr><td>&lt;%=
 Html.ActionLink(&quot;Edit&quot;, &quot;Edit&quot;, new { id=item.Id }) %&gt; | &lt;%= Html.ActionLink(&quot;Details&quot;, &quot;Details&quot;, item )%&gt; | &lt;%= Html.ActionLink(&quot;Delete&quot;, &quot;Delete&quot;, new { id=item.Id })%&gt; </td><td>&lt;%= Html.Encode(item.Id) %&gt; </td><td>&lt;%= Html.Encode(item.Name) %&gt; </td><td>&lt;%=
 Html.Encode(item.Age) %&gt; </td><td>&lt;%= Html.Encode(item.Phone) %&gt; </td><td>&lt;%= Html.Encode(item.Email) %&gt; </td></tr>
    
    &lt;%} %&gt;


    </tbody></table>


    <p>
        &lt;%= Html.ActionLink(&quot;Create New&quot;, &quot;Create&quot;) %&gt;
    </p>


&lt;/asp:Content&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span style="">Create.aspx </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
&lt;asp:Content ID=&quot;Content2&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;


    <h2>Create</h2>


    &lt;%using (Html.BeginForm()) {%&gt;


        &lt;fieldset&gt;
            &lt;legend&gt;Fields&lt;/legend&gt;
            
            <div class="editor-label">
                &lt;%= Html.LabelFor(model =&gt; model.Id) %&gt;
            </div>
            <div class="editor-field">
                &lt;%= Html.TextBoxFor(model =&gt; model.Id )%&gt;
                &lt;%= Html.ValidationMessageFor(model =&gt; model.Id) %&gt;
            </div>
            
            <div class="editor-label">
                &lt;%= Html.LabelFor(model =&gt; model.Name) %&gt;
            </div>
            <div class="editor-field">
                &lt;%= Html.TextBoxFor(model =&gt; model.Name) %&gt;
                &lt;%= Html.ValidationMessageFor(model =&gt; model.Name) %&gt;
            </div>
            
            <div class="editor-label">
                &lt;%= Html.LabelFor(model =&gt; model.Age) %&gt;
            </div>
            <div class="editor-field">
                &lt;%= Html.TextBoxFor(model =&gt; model.Age) %&gt;
                &lt;%= Html.ValidationMessageFor(model =&gt; model.Age) %&gt;
            </div>
            
            <div class="editor-label">
                &lt;%= Html.LabelFor(model =&gt; model.Phone) %&gt;
            </div>
            <div class="editor-field">
                &lt;%= Html.TextBoxFor(model =&gt; model.Phone)%&gt;
                &lt;%= Html.ValidationMessageFor(model =&gt; model.Phone)%&gt;
            </div>
            
            <div class="editor-label">
                &lt;%= Html.LabelFor(model =&gt; model.Email) %&gt;
            </div>
            <div class="editor-field">
                &lt;%= Html.TextBoxFor(model =&gt; model.Email)%&gt;
                &lt;%= Html.ValidationMessageFor(model =&gt; model.Email)%&gt;
            </div>
            
            <p>
                &lt;input type=&quot;submit&quot; value=&quot;Create&quot; /&gt;
            </p>
        &lt;/fieldset&gt;


    &lt;%} %&gt;


    <div>
        &lt;%= Html.ActionLink(&quot;Back to List&quot;, &quot;Index&quot;) %&gt;
    </div>


&lt;/asp:Content&gt;

</pre>
<pre id="codePreview" class="html">
&lt;asp:Content ID=&quot;Content2&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;


    <h2>Create</h2>


    &lt;%using (Html.BeginForm()) {%&gt;


        &lt;fieldset&gt;
            &lt;legend&gt;Fields&lt;/legend&gt;
            
            <div class="editor-label">
                &lt;%= Html.LabelFor(model =&gt; model.Id) %&gt;
            </div>
            <div class="editor-field">
                &lt;%= Html.TextBoxFor(model =&gt; model.Id )%&gt;
                &lt;%= Html.ValidationMessageFor(model =&gt; model.Id) %&gt;
            </div>
            
            <div class="editor-label">
                &lt;%= Html.LabelFor(model =&gt; model.Name) %&gt;
            </div>
            <div class="editor-field">
                &lt;%= Html.TextBoxFor(model =&gt; model.Name) %&gt;
                &lt;%= Html.ValidationMessageFor(model =&gt; model.Name) %&gt;
            </div>
            
            <div class="editor-label">
                &lt;%= Html.LabelFor(model =&gt; model.Age) %&gt;
            </div>
            <div class="editor-field">
                &lt;%= Html.TextBoxFor(model =&gt; model.Age) %&gt;
                &lt;%= Html.ValidationMessageFor(model =&gt; model.Age) %&gt;
            </div>
            
            <div class="editor-label">
                &lt;%= Html.LabelFor(model =&gt; model.Phone) %&gt;
            </div>
            <div class="editor-field">
                &lt;%= Html.TextBoxFor(model =&gt; model.Phone)%&gt;
                &lt;%= Html.ValidationMessageFor(model =&gt; model.Phone)%&gt;
            </div>
            
            <div class="editor-label">
                &lt;%= Html.LabelFor(model =&gt; model.Email) %&gt;
            </div>
            <div class="editor-field">
                &lt;%= Html.TextBoxFor(model =&gt; model.Email)%&gt;
                &lt;%= Html.ValidationMessageFor(model =&gt; model.Email)%&gt;
            </div>
            
            <p>
                &lt;input type=&quot;submit&quot; value=&quot;Create&quot; /&gt;
            </p>
        &lt;/fieldset&gt;


    &lt;%} %&gt;


    <div>
        &lt;%= Html.ActionLink(&quot;Back to List&quot;, &quot;Index&quot;) %&gt;
    </div>


&lt;/asp:Content&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span style="">Step5. <span style="">&nbsp;</span>Create the logics for models and controllers according to the sample project.
</span></p>
<p class="MsoNormal" style=""><span style="">[<b style="">NOTE</b>] For views pages, the mapping model register info will be added automatically.
</span></p>
<p class="MsoNormal" style=""><span style="">For more details of how to process data in MVC2.0, see:http://www.asp.net/mvc/tutorials/creating-model-classes-with-the-entity-framework-cs
</span></p>
<p class="MsoNormal" style=""><span style="">Step6: Add other codes to corresponding files according to the sample.
</span></p>
<p class="MsoNormal" style=""><span style="">Step7: Now, you can run the page to see the achievement we did before :)</span></p>
<h2>More Information</h2>
<p class="MsoNormal">MVC Tutorials<br>
<a href="http://www.asp.net/mvc/tutorials">http://www.asp.net/mvc/tutorials</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
