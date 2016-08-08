Imports Online_PKM_DB.Helpers

Namespace ViewModels
    Public Class PK6ViewModel
        Public Sub New(pkm As PKHeX.PK6)
            Model = pkm
        End Sub

        Private Property Model As PKHeX.PK6

        Public ReadOnly Property SpeciesID As Integer
            Get
                Return Model.Species
            End Get
        End Property

        Public ReadOnly Property SpeciesName As String
            Get
                Return PKHeXResources.GetGen6SpeciesName(Model.Species)
            End Get
        End Property

        Public ReadOnly Property Nickname As String
            Get
                Return Model.Nickname
            End Get
        End Property

        Public ReadOnly Property Level As String
            Get
                Return Model.CurrentLevel
            End Get
        End Property

        Public ReadOnly Property Ability As String
            Get
                Return PKHeXResources.GetGen6AbilityName(Model.Ability)
            End Get
        End Property

        Public ReadOnly Property Move1 As String
            Get
                Return PKHeXResources.GetGen6MoveName(Model.Move1)
            End Get
        End Property

        Public ReadOnly Property Move2 As String
            Get
                Return PKHeXResources.GetGen6MoveName(Model.Move2)
            End Get
        End Property

        Public ReadOnly Property Move3 As String
            Get
                Return PKHeXResources.GetGen6MoveName(Model.Move3)
            End Get
        End Property

        Public ReadOnly Property Move4 As String
            Get
                Return PKHeXResources.GetGen6MoveName(Model.Move4)
            End Get
        End Property
    End Class
End Namespace

