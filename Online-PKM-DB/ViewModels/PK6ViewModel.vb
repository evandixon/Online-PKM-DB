Imports System.ComponentModel.DataAnnotations
Imports Online_PKM_DB.Helpers

Namespace ViewModels
    Public Class PK6ViewModel
        Inherits GeneralPKMViewModel
        Public Sub New(pkm As PKHeX.PK6, pokemonID As Guid)
            MyBase.New(pkm, pokemonID)
        End Sub

        Protected Shadows Property Model As PKHeX.PK6
            Get
                Return MyBase.Model
            End Get
            Set(value As PKHeX.PK6)
                MyBase.Model = value
            End Set
        End Property

#Region "Met"

        <Display(Name:="Was Egg")> Public ReadOnly Property MetAsEgg As Boolean
            Get
                Return Model.WasEgg
            End Get
        End Property

        'Public ReadOnly Property MetAsEggLocation As String
        '    Get
        '        Return 'Model.Egg_Location
        '    End Get
        'End Property

        <Display(Name:="Egg Met Date")> <DisplayFormat(DataFormatString:="{0:d}")> Public ReadOnly Property EggMetDate As Date
            Get
                If Model.WasEgg Then
                    Return New Date(2000 + Model.Egg_Year, Model.Egg_Month, Model.Egg_Day)
                Else
                    Return MetDate
                End If
            End Get
        End Property
#End Region

#Region "Attacks"

        <Display(Name:="Relearn Move 1")> Public ReadOnly Property RelearnMove1 As String
            Get
                Return PKHeXResources.GetGen6MoveName(Model.RelearnMove1)
            End Get
        End Property

        <Display(Name:="Relearn Move 2")> Public ReadOnly Property RelearnMove2 As String
            Get
                Return PKHeXResources.GetGen6MoveName(Model.RelearnMove2)
            End Get
        End Property

        <Display(Name:="Relearn Move 3")> Public ReadOnly Property RelearnMove3 As String
            Get
                Return PKHeXResources.GetGen6MoveName(Model.RelearnMove3)
            End Get
        End Property

        <Display(Name:="Relearn Move 4")> Public ReadOnly Property RelearnMove4 As String
            Get
                Return PKHeXResources.GetGen6MoveName(Model.RelearnMove4)
            End Get
        End Property
#End Region

#Region "OT/Misc"

        Public ReadOnly Property LatestHandler As String
            Get
                Return Model.HT_Name
            End Get
        End Property

        Public ReadOnly Property LatestHandlerClass As String
            Get
                If Model.HT_Gender = 1 Then
                    Return "trainer-female"
                Else
                    Return "trainer-male"
                End If
            End Get
        End Property
#End Region

    End Class
End Namespace

