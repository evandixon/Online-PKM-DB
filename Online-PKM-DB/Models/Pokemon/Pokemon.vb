Imports System.ComponentModel.DataAnnotations

Namespace Models.Pokemon
    Public Class Pokemon
        <Required> <Key> Public Property ID As Guid
        <Required> Public Property FormatID As Guid
        <Required> Public Property RawData As Byte()
        Public Property UploaderUserID As String
        <Required> Public Property UploadDate As DateTime
        <Required> Public Property IsUnlisted As Boolean
        <Required> Public Property IsPrivate As Boolean
        <Required> Public Property DisableDownloading As Boolean

        Public Overridable Property Format As PokemonFormat
        Public Overridable Property GeneralMetadata As ICollection(Of PokemonGeneralMetadata)
    End Class
End Namespace

