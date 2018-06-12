Imports System.Web.Mvc
Imports System.Web.Routing
Imports System.Web.Http

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Protected Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
        GlobalConfiguration.Configure(AddressOf WebApiConfig.Register)
        RouteConfig.RegisterRoutes(RouteTable.Routes)

        'Start Table Service Initialization when project start.
        AzureClient.TableServiceInitialization()
    End Sub
End Class
