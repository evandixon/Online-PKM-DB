Imports System.ComponentModel.DataAnnotations

Namespace Models.Pokemon
    ''' <remarks>Examples: PKHeX/Main Series Pokemon and EoS Pokemon</remarks>
    Public Class PokemonFormat
        <Required> <Key> Public Property ID As Guid
        <Required> Public Property StandardCode As String
        Public Property FriendlyName As String

        Public Overridable Property Entities As ICollection(Of Entity)
    End Class
End Namespace

