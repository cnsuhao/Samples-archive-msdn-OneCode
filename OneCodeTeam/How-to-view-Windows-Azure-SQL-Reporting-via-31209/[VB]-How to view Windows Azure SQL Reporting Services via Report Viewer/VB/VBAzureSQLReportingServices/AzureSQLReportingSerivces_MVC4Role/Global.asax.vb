' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
' visit http://go.microsoft.com/?LinkId=9394802
Imports System.Web.Http
Imports System.Web.Optimization

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Shared Sub RegisterGlobalFilters(ByVal filters As GlobalFilterCollection)
        filters.Add(New HandleErrorAttribute())
    End Sub

    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        routes.MapHttpRoute( _
            name:="DefaultApi", _
            routeTemplate:="api/{controller}/{id}", _
            defaults:=New With {.id = System.Web.Http.RouteParameter.Optional}
        )

        routes.MapRoute( _
            name:="Default", _
            url:="{controller}/{action}/{id}", _
            defaults:=New With {.controller = "Home", .action = "Index", .id = UrlParameter.Optional} _
        )
    End Sub

    Sub Application_Start()
        AreaRegistration.RegisterAllAreas()

        RegisterGlobalFilters(GlobalFilters.Filters)
        RegisterRoutes(RouteTable.Routes)

        BundleConfig.RegisterBundles(BundleTable.Bundles)
    End Sub
End Class
Public Class BundleConfig
    Public Shared Sub RegisterBundles(bundles As BundleCollection)
        bundles.Add(New ScriptBundle("~/Scripts/jquery").Include("~/Scripts/Lib/jquery/jquery-{version}.js", "~/Scripts/Lib/jquery/jquery.*", "~/Scripts/Lib/jquery/jquery-ui-{version}.js"))

        bundles.Add(New ScriptBundle("~/Scripts/knockout").Include("~/Scripts/Lib/knockout/knockout-{version}.js", "~/Scripts/Lib/knockout/knockout-deferred-updates.js"))
    End Sub
End Class
