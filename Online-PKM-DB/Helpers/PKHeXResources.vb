Namespace Helpers
    Public Class PKHeXResources
        'Todo: simplify to use PKHeX.Util.GetMovesList when available
        'Todo: don't hard code "en" as the language
        Public Shared ReadOnly Property SpeciesList As New Lazy(Of String())(Function() PKHeX.Util.getSpeciesList("en"))
        Public Shared ReadOnly Property AbilitiesList As New Lazy(Of String())(Function() PKHeX.Util.getAbilitiesList("en"))
        Public Shared ReadOnly Property MovesList As New Lazy(Of String())(Function() PKHeX.Util.getMovesList("en"))
        Public Shared ReadOnly Property NaturesList As New Lazy(Of String())(Function() PKHeX.Util.getStringList("natures", "en"))
        Public Shared ReadOnly Property ItemsList As New Lazy(Of String())(Function() PKHeX.Util.getStringList("items", "en"))
        Public Shared ReadOnly Property TypesList As New Lazy(Of String())(Function() PKHeX.Util.getStringList("types", "en"))
        Public Shared ReadOnly Property CharacteristicsList As New Lazy(Of String())(Function() PKHeX.Util.getStringList("character", "en"))
        Public Shared ReadOnly Property LanguagesList As New Lazy(Of String())(Function()
                                                                                   'Todo: move functionality to PKHeX
                                                                                   Dim raw = PKHeX.Util.getStringList("languages")
                                                                                   Dim parts = raw.Select(Function(x) x.Split(","))
                                                                                   Dim data(raw.Length) As String
                                                                                   For Each item In parts
                                                                                       If IsNumeric(item(0)) Then
                                                                                           data(CInt(item(0))) = item(1)
                                                                                       End If
                                                                                   Next
                                                                                   Return data
                                                                               End Function)
        Public Shared ReadOnly Property CountriesList As New Lazy(Of String())(Function() PKHeX.Util.getStringList("countries"))
        Public Shared ReadOnly Property ConsoleRegionsList As New Lazy(Of String())(Function() PKHeX.Util.getStringList("regions3ds"))

        Public Shared Function GetGen6MoveName(moveID As Integer) As String
            Return MovesList.Value(moveID)
        End Function

        Public Shared Function GetGen6SpeciesName(pokemonID As Integer) As String
            Return SpeciesList.Value(pokemonID)
        End Function

        Public Shared Function GetGen6AbilityName(abilityID As Integer) As String
            Return AbilitiesList.Value(abilityID)
        End Function

        Public Shared Function GetGen6NatureName(natureID As Integer) As String
            Return NaturesList.Value(natureID)
        End Function

        Public Shared Function GetGen6ItemName(itemID As Integer) As String
            Return ItemsList.Value(itemID)
        End Function

        Public Shared Function GetGen6TypeName(typeID As Integer) As String
            Return TypesList.Value(typeID)
        End Function
        Public Shared Function GetGen6CharacteristicName(charID As Integer) As String
            Return CharacteristicsList.Value(charID)
        End Function

        Public Shared Function GetGen6LanguageName(languageID As Integer) As String
            Return LanguagesList.Value(languageID)
        End Function

        Public Shared Function GetGen6CountryName(countryID As Integer) As String
            Return CountriesList.Value(countryID)
        End Function

        Public Shared Function GetGen6ConsoleRegionName(consoleRegionID As Integer) As String
            Return ConsoleRegionsList.Value(consoleRegionID)
        End Function
    End Class
End Namespace

