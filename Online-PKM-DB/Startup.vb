Imports Microsoft.Owin
Imports Owin
<Assembly: OwinStartup(GetType(Online_PKM_DB.Startup))>
Partial Public Class Startup
    Public Sub Configuration(app As IAppBuilder)
        ConfigureAuth(app)
    End Sub
End Class
