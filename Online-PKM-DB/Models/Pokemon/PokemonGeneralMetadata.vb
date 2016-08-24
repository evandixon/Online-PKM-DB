Imports System.ComponentModel.DataAnnotations

Namespace Models.Pokemon
    Public Class PokemonGeneralMetadata
        <Required> <Key> Public Property ID As Guid
        <Required> Public Property PokemonID As Guid
        <Required> Public Property Species As Integer
        <Required> Public Property Nickname As String
        <Required> Public Property Level As Integer
        <Required> Public Property Ability As Integer
        <Required> Public Property Move1 As Integer
        <Required> Public Property Move2 As Integer
        <Required> Public Property Move3 As Integer
        <Required> Public Property Move4 As Integer
        <Required> Public Property OTName As String

        Public Overridable Property Pokemon As Entity
    End Class
End Namespace

