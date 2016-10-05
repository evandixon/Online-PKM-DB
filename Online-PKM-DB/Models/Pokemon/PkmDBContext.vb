Imports System.Data.Entity

Namespace Models.Pokemon
    Public Class PkmDBContext
        Inherits DbContext

        Public Sub New()
            MyBase.New("PkmDB")
        End Sub

        Public Property EntityTypes As DbSet(Of EntityType)
        Public Property PokemonFormats As DbSet(Of PokemonFormat)
        Public Property Entities As DbSet(Of Entity)
        Public Property GeneralPokemonMetadata As DbSet(Of PokemonGeneralMetadata)

        Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
            MyBase.OnModelCreating(modelBuilder)
            Database.SetInitializer(New MigrateDatabaseToLatestVersion(Of PkmDBContext, Migrations.Configuration))
        End Sub

        Public Property Categories As System.Data.Entity.DbSet(Of Models.Pokemon.Category)
    End Class
End Namespace

