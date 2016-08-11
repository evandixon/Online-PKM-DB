Imports System.ComponentModel.DataAnnotations
Imports Online_PKM_DB.Helpers

Namespace ViewModels
    Public Class PK6ViewModel
        Inherits GeneralPKMViewModel
        Public Sub New(pkm As PKHeX.PK6, pokemonID As Guid, pokemonFormatFriendlyName As String, uploadDate As DateTime, uploaderID As String, uploaderUsername As String, currentUserName As String, isUnlisted As Boolean, isPrivate As Boolean, disableDownloads As Boolean)
            MyBase.New(pkm, pokemonID, pokemonFormatFriendlyName, uploadDate, uploaderID, uploaderUsername, currentUserName, isUnlisted, isPrivate, disableDownloads)
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

        <Display(Name:="Egg Met Date")> <DisplayFormat(DataFormatString:="{0:d}")> Public ReadOnly Property EggMetDate As Date?
            Get
                Return Model.EggMetDate
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

        <Display(Name:="Latest Handler")> Public ReadOnly Property LatestHandler As String
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

