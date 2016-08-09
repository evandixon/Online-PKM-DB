Imports System.Reflection

Namespace Helpers

    Public Class RequireQueryStringValuesAttribute
        Inherits ActionMethodSelectorAttribute
        Public Sub New(valueNames As String())
            Me.ValueNames = valueNames
        End Sub

        Public Overrides Function IsValidForRequest(controllerContext As ControllerContext, methodInfo As MethodInfo) As Boolean
            Dim contains As Boolean = False
            For Each value In ValueNames
                contains = Not String.IsNullOrEmpty(controllerContext.RequestContext.HttpContext.Request.QueryString.Item(value))
                If Not contains Then
                    Exit For
                End If
            Next
            Return contains
        End Function

        Public Property ValueNames() As String()
    End Class

End Namespace