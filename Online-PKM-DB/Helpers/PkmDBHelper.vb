Imports Online_PKM_DB.Models.Pokemon

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
    End Class
End Namespace

