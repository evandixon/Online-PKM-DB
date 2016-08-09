Imports Online_PKM_DB.Models.Pokemon
Imports Online_PKM_DB.ViewModels

Namespace Helpers
    Public Class PkmDBHelper
        Public Shared Function GetPK6FormatID(context As PkmDBContext) As Guid
            Dim match = context.PokemonFormats.FirstOrDefault(Function(x) x.StandardCode = "PK6")
            If match Is Nothing Then
                match = New PokemonFormat With {.ID = Guid.NewGuid, .StandardCode = "PK6", .FriendlyName = "PK6"}
                context.PokemonFormats.Add(match)
                context.SaveChanges()
            End If
            Return match.ID
        End Function

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

