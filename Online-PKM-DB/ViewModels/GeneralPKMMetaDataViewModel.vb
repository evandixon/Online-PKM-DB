﻿Imports System.ComponentModel.DataAnnotations
Imports Online_PKM_DB.Helpers
Imports Online_PKM_DB.Models.Pokemon

Namespace ViewModels
    Public Class GeneralPKMMetaDataViewModel
        Public Sub New(metadata As PokemonGeneralMetadata, pokemonID As Guid)
            Model = metadata
            Me.PokemonID = pokemonID
        End Sub

        Private Property Model As PokemonGeneralMetadata

        Public ReadOnly Property PokemonID As Guid

        Public ReadOnly Property SpeciesID As Integer
            Get
                Return Model.Species
            End Get
        End Property

        <Display(Name:="Species")> Public ReadOnly Property SpeciesName As String
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
                Return Model.Level
            End Get
        End Property

        Public ReadOnly Property Ability As String
            Get
                Return PKHeXResources.GetGen6AbilityName(Model.Ability)
            End Get
        End Property

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
    End Class
End Namespace

