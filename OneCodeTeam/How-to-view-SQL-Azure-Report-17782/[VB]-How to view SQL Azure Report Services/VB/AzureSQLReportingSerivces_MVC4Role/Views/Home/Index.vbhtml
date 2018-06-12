@modeltype AzureSQLReportingSerivces_MVC4Role.Person

@Code
    ViewData("Title") = "Sample Code"
End Code

@section featured
<section class="featured">
    <div class="content-wrapper">
        <hgroup class="title">
            <h1>@ViewBag.Title.</h1>
            <h2>@ViewBag.Message</h2>
        </hgroup>
        <p>
           
            The page features <span class="highlight">videos, tutorials, and samples</span> to help you get the most from 
            ASP.NET MVC. If you have any questions about ASP.NET MVC visit 
            <a href="http://forums.asp.net/1146.aspx/1?MVC" title="ASP.NET MVC Forum">our forums</a>.
        </p>
    </div>
</section>
End Section

<table class="sofT" >
<tr>
<td colspan="4" class="helpHed">SQL Azure Reporting Service</td>
</tr>
<tr>
<td class="helpHed">ID</td>
<td class="helpHed">Name</td>
<td class="helpHed">Comments</td>
</tr>
@For i As Integer = 0 To ViewBag.NumTimes - 1
    @<tr><td>
    @ViewBag.List(i).ID
    </td><td>
    @ViewBag.List(i).Name
    </td><td>
    @ViewBag.List(i).Comments
    </td></tr> 
Next
</table>
<br />
<div class="error">
@ViewBag.Status
</div>


