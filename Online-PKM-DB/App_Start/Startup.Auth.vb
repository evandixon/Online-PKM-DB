Imports System.Collections.Generic
Imports System.Linq
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin
Imports Microsoft.Owin.Security.Cookies
Imports Microsoft.Owin.Security.Google
Imports Microsoft.Owin.Security.OAuth
Imports Owin

Public Partial Class Startup
    Private Shared _OAuthOptions As OAuthAuthorizationServerOptions
    Private Shared _PublicClientId As String

    Public Shared Property OAuthOptions() As OAuthAuthorizationServerOptions
        Get
            Return _OAuthOptions
        End Get
        Private Set
            _OAuthOptions = Value
        End Set
    End Property

    Public Shared Property PublicClientId() As String
        Get
            Return _PublicClientId
        End Get
        Private Set
            _PublicClientId = Value
        End Set
    End Property

    ' For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
    Public Sub ConfigureAuth(app As IAppBuilder)
        ' Configure the db context and user manager to use a single instance per request
        app.CreatePerOwinContext(AddressOf ApplicationDbContext.Create)
        app.CreatePerOwinContext(Of ApplicationUserManager)(AddressOf ApplicationUserManager.Create)
        app.CreatePerOwinContext(Of ApplicationSignInManager)(AddressOf ApplicationSignInManager.Create)

        ' Enable the application to use a cookie to store information for the signed in user
        ' and to use a cookie to temporarily store information about a user logging in with a third party login provider
        app.UseCookieAuthentication(New CookieAuthenticationOptions())
        app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie)

        ' Configure the application for OAuth based flow
        ' In production mode set AllowInsecureHttp = False
        PublicClientId = "self"
        OAuthOptions = New OAuthAuthorizationServerOptions() With {
          .TokenEndpointPath = New PathString("/Token"),
          .Provider = New ApplicationOAuthProvider(PublicClientId),
          .AuthorizeEndpointPath = New PathString("/api/Account/ExternalLogin"),
          .AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
          .AllowInsecureHttp = True
        }

        ' Enable the application to use a cookie to store information for the signed in user
        ' and to use a cookie to temporarily store inforation about a user logging in with a third party login provider
        ' Configure the sign in cookie
        ' OnValidateIdentity enables the application to validate the security stamp when the user logs in.
        ' This is a security feature which is used when you change a password or add an external login to your account.
        app.UseCookieAuthentication(New CookieAuthenticationOptions() With {
            .AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            .Provider = New CookieAuthenticationProvider() With {
                .OnValidateIdentity = SecurityStampValidator.OnValidateIdentity(Of ApplicationUserManager, ApplicationUser)(
                    validateInterval:=TimeSpan.FromMinutes(30),
                    regenerateIdentity:=Function(manager, user) user.GenerateUserIdentityAsync(manager))},
            .LoginPath = New PathString("/Account/Login")})

        app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie)

        ' Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
        app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5))

        ' Enables the application to remember the second login verification factor such as phone or email.
        ' Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
        ' This is similar to the RememberMe option when you log in.
        app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie)

        '' Enable the application to use bearer tokens to authenticate users
        'app.UseOAuthBearerTokens(OAuthOptions)

        ' Uncomment the following lines to enable logging in with third party login providers
        'app.UseMicrosoftAccountAuthentication(
        '    clientId:="",
        '    clientSecret:="")

        'app.UseTwitterAuthentication(
        '    consumerKey:="",
        '    consumerSecret:="")

        'app.UseFacebookAuthentication(
        '    appId:="",
        '    appSecret:="")

        'app.UseGoogleAuthentication(New GoogleOAuth2AuthenticationOptions() With {
        '    .ClientId = "",
        '    .ClientSecret = ""})
    End Sub
End Class
