Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations

' Models returned by AccountController actions.
Public Class ExternalLoginViewModel
    Public Property Name As String
    Public Property Url As String
    Public Property State As String
End Class

Public Class ManageInfoViewModel
    Public Property LocalLoginProvider As String
    Public Property Email As String
    Public Property Logins As IEnumerable(Of UserLoginInfoViewModel)
    Public Property ExternalLoginProviders As IEnumerable(Of ExternalLoginViewModel)
End Class

Public Class UserInfoViewModel
    Public Property Email As String
    Public Property HasRegistered As Boolean
    Public Property LoginProvider As String
End Class

Public Class UserLoginInfoViewModel
    Public Property LoginProvider As String
    Public Property ProviderKey As String
End Class

Public Class ExternalLoginConfirmationViewModel
    <Required>
    <Display(Name:="Email")>
    Public Property Email As String
End Class

Public Class ExternalLoginListViewModel
    Public Property ReturnUrl As String
End Class

Public Class SendCodeViewModel
    Public Property SelectedProvider As String
    Public Property Providers As ICollection(Of System.Web.Mvc.SelectListItem)
    Public Property ReturnUrl As String
    Public Property RememberMe As Boolean
End Class

Public Class VerifyCodeViewModel
    <Required>
    Public Property Provider As String

    <Required>
    <Display(Name:="Code")>
    Public Property Code As String

    Public Property ReturnUrl As String

    <Display(Name:="Remember this browser?")>
    Public Property RememberBrowser As Boolean

    Public Property RememberMe As Boolean
End Class

Public Class ForgotViewModel
    <Required>
    <Display(Name:="Email")>
    Public Property Email As String
End Class

Public Class LoginViewModel
    <Required>
    <Display(Name:="Username")>
    Public Property Username As String

    <Required>
    <DataType(DataType.Password)>
    <Display(Name:="Password")>
    Public Property Password As String

    <Display(Name:="Remember me?")>
    Public Property RememberMe As Boolean
End Class

Public Class RegisterViewModel
    <Required>
    <StringLength(100, ErrorMessage:="The {0} must be at least {2} character long.", MinimumLength:=1)>
    <Display(Name:="Username")>
    Public Property Username As String

    <Required>
    <EmailAddress>
    <Display(Name:="Email")>
    Public Property Email As String

    <Required>
    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=6)>
    <DataType(DataType.Password)>
    <Display(Name:="Password")>
    Public Property Password As String

    <DataType(DataType.Password)>
    <Display(Name:="Confirm password")>
    <Compare("Password", ErrorMessage:="The password and confirmation password do not match.")>
    Public Property ConfirmPassword As String
End Class

Public Class ResetPasswordViewModel
    <Required>
    <EmailAddress>
    <Display(Name:="Email")>
    Public Property Email() As String

    <Required>
    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=6)>
    <DataType(DataType.Password)>
    <Display(Name:="Password")>
    Public Property Password() As String

    <DataType(DataType.Password)>
    <Display(Name:="Confirm password")>
    <Compare("Password", ErrorMessage:="The password and confirmation password do not match.")>
    Public Property ConfirmPassword() As String

    Public Property Code() As String
End Class

Public Class ForgotPasswordViewModel
    <Required>
    <EmailAddress>
    <Display(Name:="Email")>
    Public Property Email() As String
End Class
