Imports System.Data.Entity

Namespace Models.Pokemon
    Public Class PkmDBContext
        Inherits DbContext

        Public Sub New()
            MyBase.New("PkmDB")
        End Sub

        Public Property PokemonFormats As DbSet(Of PokemonFormat)
        Public Property Pokemon As DbSet(Of Pokemon)
        Public Property GeneralPokemonMetadata As DbSet(Of PokemonGeneralMetadata)
    End Class
End Namespace

