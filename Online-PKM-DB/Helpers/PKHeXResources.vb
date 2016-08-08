Namespace Helpers
    Public Class PKHeXResources
        'Todo: simplify to use PKHeX.Util.GetMovesList when available
        'Todo: don't hard code "en" as the language
        Public Shared ReadOnly Property SpeciesList As New Lazy(Of String())(Function() PKHeX.Util.getStringList("species", "en"))
        Public Shared ReadOnly Property AbilitiesList As New Lazy(Of String())(Function() PKHeX.Util.getStringList("abilities", "en"))
        Public Shared ReadOnly Property MovesList As New Lazy(Of String())(Function() PKHeX.Util.getStringList("moves", "en"))
        Public Shared Function GetGen6MoveName(moveID As Integer) As String
            Return MovesList.Value(moveID)
        End Function
        Public Shared Function GetGen6SpeciesName(pokemonID As Integer) As String
            Return SpeciesList.Value(pokemonID)
        End Function
        Public Shared Function GetGen6AbilityName(abilityID As Integer) As String
            Return AbilitiesList.Value(abilityID)
        End Function
    End Class
End Namespace

