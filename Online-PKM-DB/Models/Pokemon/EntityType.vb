Imports System.ComponentModel.DataAnnotations

Namespace Models.Pokemon
    ''' <remarks>Examples: Pokemon and Wondercards</remarks>
    Public Class EntityType
        <Required> <Key> Public Property ID As Guid
        <Required> Public Property StandardCode As String
        Public Property FriendlyName As String
    End Class
End Namespace

