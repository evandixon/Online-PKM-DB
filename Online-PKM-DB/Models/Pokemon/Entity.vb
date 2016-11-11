Imports System.ComponentModel.DataAnnotations

Namespace Models.Pokemon
    ''' <summary>
    ''' An uploadable entity such as a Pokémon or a Wondercard
    ''' </summary>
    Public Class Entity
        <Required> <Key> Public Property ID As Guid
        Public Property ParentCategoryID As Guid?
        <Required> Public Property EntityTypeID As Guid
        <Required> Public Property FormatID As Guid
        <Required> Public Property RawData As Byte()
        Public Property UploaderUserID As String
        <Required> Public Property UploadDate As DateTime
        <Required> Public Property IsUnlisted As Boolean
        <Required> Public Property IsPrivate As Boolean
        <Required> Public Property DisableDownloading As Boolean

        Public Overridable Property EntityType As EntityType
        Public Overridable Property Format As PokemonFormat
        Public Overridable Property GeneralMetadata As ICollection(Of PokemonGeneralMetadata)
        Public Overridable Property ParentCategory As Category
    End Class
End Namespace

