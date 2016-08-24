Imports Online_PKM_DB.Models.Pokemon
Imports Online_PKM_DB.ViewModels

Namespace Helpers

    ''' <summary>
    ''' Helper methods for interacting with a <see cref="PkmDBContext"/>.
    ''' </summary>
    Public Class PkmDBHelper

        Private Sub New()
        End Sub

        ''' <summary>
        ''' Gets or creates the <see cref="EntityType"/> for PKM files.
        ''' </summary>
        ''' <param name="context">Instance of the current <see cref="PkmDBContext"/>.</param>
        ''' <returns>The ID of the PKM entity type.</returns>
        Public Shared Function GetPKMEntityType(context As PkmDBContext) As Guid
            Return GetEntityType("PKM", context)
        End Function

        ''' <summary>
        ''' Gets or creates the <see cref="EntityType"/> with the given standard code.
        ''' </summary>
        ''' <param name="typeCode">Standard code of the entity type.</param>
        ''' <param name="context">Instance of the current <see cref="PkmDBContext"/>.</param>
        ''' <returns>The ID of the entity type with the given standard code.</returns>
        Public Shared Function GetEntityType(typeCode As String, context As PkmDBContext) As Guid
            Dim match = context.EntityTypes.FirstOrDefault(Function(x) x.StandardCode = typeCode)
            If match Is Nothing Then
                match = New EntityType With {.ID = Guid.NewGuid, .StandardCode = typeCode, .FriendlyName = typeCode}
                context.EntityTypes.Add(match)
                context.SaveChanges()
            End If
            Return match.ID
        End Function

        ''' <summary>
        ''' Gets or creates the PK6 PKM format.
        ''' </summary>
        ''' <param name="context">Instance of the current <see cref="PkmDBContext"/>.</param>
        ''' <returns>The ID of the PK6 PKM format.</returns>
        Public Shared Function GetPK6FormatID(context As PkmDBContext) As Guid
            Return GetFormatID("PK6", context)
        End Function

        ''' <summary>
        ''' Gets or creates the PKM format with the given standard code.
        ''' </summary>
        ''' <param name="formatCode">Standard code of the PKM format.</param>
        ''' <param name="context">Instance of the current <see cref="PkmDBContext"/>.</param>
        ''' <returns>The ID of the PKM format with the given standard code.</returns>
        Public Shared Function GetFormatID(formatCode As String, context As PkmDBContext) As Guid
            Dim match = context.PokemonFormats.FirstOrDefault(Function(x) x.StandardCode = formatCode)
            If match Is Nothing Then
                match = New PokemonFormat With {.ID = Guid.NewGuid, .StandardCode = formatCode, .FriendlyName = formatCode}
                context.PokemonFormats.Add(match)
                context.SaveChanges()
            End If
            Return match.ID
        End Function

        ''' <summary>
        ''' Updates the usernames in the given search results.
        ''' </summary>
        ''' <param name="searchResults"></param>
        Public Shared Sub UpdateUsernames(searchResults As PKMSearchResults)
            Dim IDs As List(Of String) = searchResults.Results.Select(Function(x) x.UploaderUserID).ToList
            Dim matches As Dictionary(Of String, String) 'Key: user ID, Value: username
            Using context As New ApplicationDbContext
                matches = (From u In context.Users
                           Where IDs.Contains(u.Id)
                           Select New With {.ID = u.Id, .Username = u.UserName}).ToDictionary(Function(x) x.ID, Function(x) x.Username)
            End Using
            For Each item In searchResults.Results
                If Not String.IsNullOrEmpty(item.UploaderUserID) AndAlso matches.ContainsKey(item.UploaderUserID) Then
                    item.UploaderUsername = matches(item.UploaderUserID)
                Else
                    item.UploaderUsername = "(Anonymous)"
                End If
            Next
        End Sub
    End Class
End Namespace

