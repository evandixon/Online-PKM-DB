Imports System.ComponentModel.DataAnnotations
Imports Online_PKM_DB.Helpers

Namespace ViewModels
    Public Class GeneralPKMViewModel
        Public Sub New(pkm As PKHeX.PKM, pokemonID As Guid, pokemonFormatFriendlyName As String, uploadDate As DateTime, uploaderID As String, uploaderUsername As String, currentUserID As String)
            Me.Model = pkm
            Me.PokemonID = pokemonID
            Me.PokemonFormatFriendlyName = pokemonFormatFriendlyName
            Me.Legality = New PKHeX.LegalityAnalysis(pkm)
            Me.UploadDate = uploadDate
            Me.UploaderID = uploaderID
            Me.UploaderUsername = uploaderUsername
            Me.CurrentUserID = currentUserID
        End Sub

        Protected Property Model As PKHeX.PKM
        Protected Property Legality As PKHeX.LegalityAnalysis

        Public Property PokemonID As Guid
        Public Property PokemonFormatFriendlyName As String
        Public Property UploadDate As DateTime
        Public Property UploaderID As String
        Public Property UploaderUsername As String
        Protected Property CurrentUserID As String

        Public ReadOnly Property CanDelete() As Boolean
            Get
                Return UploaderID = CurrentUserID OrElse My.User.IsInRole("PKMDB-Moderator")
            End Get
        End Property

#Region "Main"
        Public ReadOnly Property SpeciesID As Integer
            Get
                Return Model.Species
            End Get
        End Property

        Public ReadOnly Property PID As UInteger
            Get
                Return Model.PID
            End Get
        End Property

        <Display(Name:="Species Name")> Public ReadOnly Property SpeciesName As String
            Get
                Return PKHeXResources.GetGen6SpeciesName(Model.Species)
            End Get
        End Property

        Public ReadOnly Property Nickname As String
            Get
                Return Model.Nickname
            End Get
        End Property

        <Display(Name:="Is Nicknamed")> Public ReadOnly Property IsNicknamed As Boolean
            Get
                Return Model.IsNicknamed
            End Get
        End Property

        Public ReadOnly Property Exp As UInteger
            Get
                Return Model.EXP
            End Get
        End Property

        Public ReadOnly Property Level As String
            Get
                Return Model.CurrentLevel
            End Get
        End Property

        Public ReadOnly Property Nature As String
            Get
                Return PKHeXResources.GetGen6NatureName(Model.Nature)
            End Get
        End Property

        <Display(Name:="Held Item")> Public ReadOnly Property HeldItem As String
            Get
                Return PKHeXResources.GetGen6ItemName(Model.HeldItem)
            End Get
        End Property

        Public ReadOnly Property Friendship As Integer
            Get
                Return Model.CurrentFriendship
            End Get
        End Property

        'Public ReadOnly Property Form As String
        '    Get

        '    End Get
        'End Property

        Public ReadOnly Property Ability As String
            Get
                Return PKHeXResources.GetGen6AbilityName(Model.Ability)
            End Get
        End Property

        Public ReadOnly Property Language As String
            Get
                Return PKHeXResources.GetGen6LanguageName(Model.Language)
            End Get
        End Property

        <Display(Name:="Is Egg")> Public ReadOnly Property IsEgg As Boolean
            Get
                Return Model.IsEgg
            End Get
        End Property

        <Display(Name:="Is Infected")> Public ReadOnly Property IsInfected As Boolean
            Get
                Return Model.PKRS_Infected
            End Get
        End Property

        <Display(Name:="Is Cured")> Public ReadOnly Property IsCured As Boolean
            Get
                Return Model.PKRS_Cured
            End Get
        End Property

        ''These are excluded not only because they aren't displaying properly, but could also be a privacy issue since it stores the country and state of whomever uploaded it.
        '<Display(Name:="Country")> Public ReadOnly Property Country As String
        '    Get
        '        Return PKHeXResources.GetGen6CountryName(Model.Country)
        '    End Get
        'End Property

        '<Display(Name:="Console Region")> Public ReadOnly Property ConsoleRegion As String
        '    Get
        '        Return PKHeXResources.GetGen6ConsoleRegionName(Model.ConsoleRegion)
        '    End Get
        'End Property

#End Region

#Region "Met"
        'Public ReadOnly Property OriginGame As String
        '    Get
        '        Return 'Model.Version
        '    End Get
        'End Property

        'Public ReadOnly Property MetLocation As String
        '    Get

        '    End Get
        'End Property

        'Public ReadOnly Property Ball As String
        '    Get
        '        'Todo: make PKHeX provide a convenient list of ball names
        '    End Get
        'End Property

        <Display(Name:="Met Level")> Public ReadOnly Property MetLevel As Integer
            Get
                Return Model.Met_Level
            End Get
        End Property

        <Display(Name:="Met Date")> <DisplayFormat(DataFormatString:="{0:d}")> Public ReadOnly Property MetDate As Date
            Get
                If Model.Met_Year = 0 OrElse Model.Met_Month = 0 OrElse Model.Met_Day = 0 Then
                    Return Date.MinValue
                Else
                    Return New Date(2000 + Model.Met_Year, Model.Met_Month, Model.Met_Day)
                End If
            End Get
        End Property

        <Display(Name:="Fateful Encounter")> Public ReadOnly Property FatefulEncounter As Boolean
            Get
                Return Model.FatefulEncounter
            End Get
        End Property

        '' Not supported in general yet
        '<Display(Name:="Was Egg")> Public ReadOnly Property MetAsEgg As Boolean
        '    Get
        '        Return Model.WasEgg
        '    End Get
        'End Property

        'Public ReadOnly Property MetAsEggLocation As String
        '    Get
        '        Return 'Model.Egg_Location
        '    End Get
        'End Property

        '<Display(Name:="Egg Met Date")> <DisplayFormat(DataFormatString:="{0:d}")> Public ReadOnly Property EggMetDate As Date
        '    Get
        '        If Model.WasEgg Then
        '            Return New Date(2000 + Model.Egg_Year, Model.Egg_Month, Model.Egg_Day)
        '        Else
        '            Return MetDate
        '        End If
        '    End Get
        'End Property
#End Region

#Region "Stats"
        Public ReadOnly Property IV_HP As Integer
            Get
                Return Model.IV_HP
            End Get
        End Property

        Public ReadOnly Property IV_Atk As Integer
            Get
                Return Model.IV_ATK
            End Get
        End Property

        Public ReadOnly Property IV_Def As Integer
            Get
                Return Model.IV_DEF
            End Get
        End Property

        Public ReadOnly Property IV_SpA As Integer
            Get
                Return Model.IV_SPA
            End Get
        End Property

        Public ReadOnly Property IV_SpD As Integer
            Get
                Return Model.IV_SPD
            End Get
        End Property

        Public ReadOnly Property IV_Spe As Integer
            Get
                Return Model.IV_SPE
            End Get
        End Property

        Public ReadOnly Property IV_Total As Integer
            Get
                Return Model.IVs.Sum()
            End Get
        End Property

        Public ReadOnly Property EV_HP As Integer
            Get
                Return Model.EV_HP
            End Get
        End Property

        Public ReadOnly Property EV_Atk As Integer
            Get
                Return Model.EV_ATK
            End Get
        End Property

        Public ReadOnly Property EV_Def As Integer
            Get
                Return Model.EV_DEF
            End Get
        End Property

        Public ReadOnly Property EV_SpA As Integer
            Get
                Return Model.EV_SPA
            End Get
        End Property

        Public ReadOnly Property EV_SpD As Integer
            Get
                Return Model.EV_SPD
            End Get
        End Property

        Public ReadOnly Property EV_Spe As Integer
            Get
                Return Model.EV_SPE
            End Get
        End Property

        Public ReadOnly Property EV_Total As Integer
            Get
                Return Model.EVs.Sum()
            End Get
        End Property

        '' At least partially dependant on current save
        'Public ReadOnly Property Stat_HP As Integer
        '    Get
        '        Return Model.Stat_HPCurrent
        '    End Get
        'End Property

        'Public ReadOnly Property Stat_Atk As Integer
        '    Get
        '        Return Model.Stat_ATK
        '    End Get
        'End Property

        'Public ReadOnly Property Stat_Def As Integer
        '    Get
        '        Return Model.Stat_DEF
        '    End Get
        'End Property

        'Public ReadOnly Property Stat_SpA As Integer
        '    Get
        '        Return Model.Stat_SPA
        '    End Get
        'End Property

        'Public ReadOnly Property Stat_SpD As Integer
        '    Get
        '        Return Model.Stat_SPD
        '    End Get
        'End Property

        'Public ReadOnly Property Stat_SpE As Integer
        '    Get
        '        Return Model.Stat_SPE
        '    End Get
        'End Property

        Public ReadOnly Property LabelClass_Atk As String
            Get
                If Model.Nature / 5 = Model.Nature Mod 5 Then
                    Return "stat-normal"
                ElseIf Model.Nature / 5 = 0 Then
                    Return "stat-boosted"
                ElseIf Model.Nature Mod 5 = 0 Then
                    Return "stat-lowered"
                Else
                    Return "stat-normal"
                End If
            End Get
        End Property

        Public ReadOnly Property LabelClass_Def As String
            Get
                If Model.Nature / 5 = Model.Nature Mod 5 Then
                    Return "stat-normal"
                ElseIf Model.Nature / 5 = 1 Then
                    Return "stat-boosted"
                ElseIf Model.Nature Mod 5 = 1 Then
                    Return "stat-lowered"
                Else
                    Return "stat-normal"
                End If
            End Get
        End Property

        Public ReadOnly Property LabelClass_SpE As String
            Get
                If Model.Nature / 5 = Model.Nature Mod 5 Then
                    Return "stat-normal"
                ElseIf Model.Nature / 5 = 2 Then
                    Return "stat-boosted"
                ElseIf Model.Nature Mod 5 = 2 Then
                    Return "stat-lowered"
                Else
                    Return "stat-normal"
                End If
            End Get
        End Property

        Public ReadOnly Property LabelClass_SpA As String
            Get
                If Model.Nature / 5 = Model.Nature Mod 5 Then
                    Return "stat-normal"
                ElseIf Model.Nature / 5 = 3 Then
                    Return "stat-boosted"
                ElseIf Model.Nature Mod 5 = 3 Then
                    Return "stat-lowered"
                Else
                    Return "stat-normal"
                End If
            End Get
        End Property

        Public ReadOnly Property LabelClass_SpD As String
            Get
                If Model.Nature / 5 = Model.Nature Mod 5 Then
                    Return "stat-normal"
                ElseIf Model.Nature / 5 = 4 Then
                    Return "stat-boosted"
                ElseIf Model.Nature Mod 5 = 4 Then
                    Return "stat-lowered"
                Else
                    Return "stat-normal"
                End If
            End Get
        End Property

        Public ReadOnly Property Potential As String
            Get
                Return {"★☆☆☆", "★★☆☆", "★★★☆", "★★★★"}(Model.PotentialRating)
            End Get
        End Property

        <Display(Name:="Hidden Power Type")> Public ReadOnly Property HiddenPowerType As String
            Get
                Return PKHeXResources.GetGen6TypeName(Model.HPType)
            End Get
        End Property

        Public ReadOnly Property Characteristic As String
            Get
                If Model.Characteristic < 0 Then
                    Return "N/A"
                Else
                    Return PKHeXResources.GetGen6CharacteristicName(Model.Characteristic)
                End If
            End Get
        End Property

        Public ReadOnly Property ContestCool As Integer
            Get
                Return Model.CNT_Cool
            End Get
        End Property
        Public ReadOnly Property ContestBeauty As Integer
            Get
                Return Model.CNT_Beauty
            End Get
        End Property
        Public ReadOnly Property ContestCute As Integer
            Get
                Return Model.CNT_Cute
            End Get
        End Property
        Public ReadOnly Property ContestClever As Integer
            Get
                Return Model.CNT_Smart
            End Get
        End Property
        Public ReadOnly Property ContestTough As Integer
            Get
                Return Model.CNT_Tough
            End Get
        End Property
        Public ReadOnly Property ContestSheen As Integer
            Get
                Return Model.CNT_Sheen
            End Get
        End Property

#End Region

#Region "Attacks"
        <Display(Name:="Move 1")> Public ReadOnly Property Move1 As String
            Get
                Return PKHeXResources.GetGen6MoveName(Model.Move1)
            End Get
        End Property

        <Display(Name:="Move 2")> Public ReadOnly Property Move2 As String
            Get
                Return PKHeXResources.GetGen6MoveName(Model.Move2)
            End Get
        End Property

        <Display(Name:="Move 3")> Public ReadOnly Property Move3 As String
            Get
                Return PKHeXResources.GetGen6MoveName(Model.Move3)
            End Get
        End Property

        <Display(Name:="Move 4")> Public ReadOnly Property Move4 As String
            Get
                Return PKHeXResources.GetGen6MoveName(Model.Move4)
            End Get
        End Property

        Public ReadOnly Property MovePP1 As String
            Get
                Return Model.Move1_PP
            End Get
        End Property

        Public ReadOnly Property MovePP2 As String
            Get
                Return Model.Move2_PP
            End Get
        End Property

        Public ReadOnly Property MovePP3 As String
            Get
                Return Model.Move3_PP
            End Get
        End Property

        Public ReadOnly Property MovePP4 As String
            Get
                Return Model.Move4_PP
            End Get
        End Property

        Public ReadOnly Property MovePPUp1 As String
            Get
                Return Model.Move1_PPUps
            End Get
        End Property

        Public ReadOnly Property MovePPUp2 As String
            Get
                Return Model.Move2_PPUps
            End Get
        End Property

        Public ReadOnly Property MovePPUp3 As String
            Get
                Return Model.Move3_PPUps
            End Get
        End Property

        Public ReadOnly Property MovePPUp4 As String
            Get
                Return Model.Move4_PPUps
            End Get
        End Property

#End Region

#Region "OT/Misc"
        Public ReadOnly Property TID As Integer
            Get
                Return Model.TID
            End Get
        End Property

        Public ReadOnly Property SID As Integer
            Get
                Return Model.SID
            End Get
        End Property

        Public ReadOnly Property OT As String
            Get
                Return Model.OT_Name
            End Get
        End Property

        Public ReadOnly Property LabelOTClass As String
            Get
                If Model.OT_Gender = 1 Then
                    Return "trainer-female"
                Else
                    Return "trainer-male"
                End If
            End Get
        End Property

#End Region

        Public ReadOnly Property LegalityReport As String
            Get
                Return Legality.VerboseReport
            End Get
        End Property

        Public ReadOnly Property IsLegal As Boolean
            Get
                Return Legality.Valid
            End Get
        End Property

        Public ReadOnly Property SugimoriArtworkUrl As String
            Get
                'Todo: take into account gender and forms
                Return My.Settings.SugimoriArtworkBaseUrl & SpeciesID.ToString & ".png"
            End Get
        End Property
    End Class
End Namespace

