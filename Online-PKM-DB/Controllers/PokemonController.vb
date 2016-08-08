Imports System.Web.Mvc
Imports Microsoft.AspNet.Identity
Imports Online_PKM_DB.Helpers
Imports Online_PKM_DB.Models.Pokemon
Imports Online_PKM_DB.ViewModels

Namespace Controllers
    Public Class PokemonController
        Inherits Controller

        ' GET: Pokemon
        Function Index() As ActionResult
            Dim entries As List(Of PK6MetaDataViewModel)
            Using context As New PkmDBContext
                entries = (From f In context.PokemonFormats
                           From p In f.Pokemon
                           From m In p.GeneralMetadata
                           Where f.StandardCode = "PK6"
                           Order By p.UploadDate Descending
                           Select New With {.Metadata = m, .PokemonID = p.ID}).Take(50).AsEnumerable.Select(Function(x) New PK6MetaDataViewModel(x.Metadata, x.PokemonID)).ToList
            End Using
            Return View(entries)
        End Function

        ' GET: Pokemon/Details/5
        Function Details(ByVal id As Guid) As ActionResult
            'Todo: use a different model or a different view for different PKM types
            Dim pkm As PK6ViewModel
            Using context As New PkmDBContext
                Dim data = (From p In context.Pokemon Where p.ID = id Select p.RawData).FirstOrDefault
                If data Is Nothing Then
                    Return HttpNotFound()
                End If

                pkm = New PK6ViewModel(New PKHeX.PK6(data))
            End Using
            Return View(pkm)
        End Function

        ' GET: Pokemon/Create
        <Authorize>
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Pokemon/Create
        <HttpPost()>
        <Authorize>
        Function Create(ByVal file As HttpPostedFileBase) As ActionResult
            'Try
            'Ensure the size is OK
            If Not PKHeX.PKX.getIsPKM(file.ContentLength) Then
                Throw New Http.HttpResponseException(Net.HttpStatusCode.BadRequest)
            End If

            'Read the file
            Dim data(file.ContentLength - 1) As Byte
            file.InputStream.Read(data, 0, file.ContentLength)

            'Todo: Detect type of file
            'For now, we'll just make sure it's a valid PK6 file
            If Not PKHeX.PKMConverter.getPKMDataFormat(data) = 6 Then
                Throw New Http.HttpResponseException(Net.HttpStatusCode.BadRequest)
            End If

            'Add the data to the database
            Dim pk6 As New PKHeX.PK6(data)
            Dim newPKMID As Guid = Guid.NewGuid
            Using context As New PkmDBContext
                Dim formatID = PkmDBHelper.GetPK6FormatID(context)
                Dim pkm As New Pokemon With
                        {.ID = newPKMID,
                        .FormatID = formatID,
                        .RawData = data,
                        .UploadDate = Date.UtcNow,
                        .UploaderUserID = User.Identity.GetUserId}
                context.Pokemon.Add(pkm)

                Dim meta As New PokemonGeneralMetadata With {
                        .ID = Guid.NewGuid,
                        .PokemonID = pkm.ID,
                        .Ability = pk6.Ability,
                        .Level = pk6.CurrentLevel,
                        .Move1 = pk6.Move1,
                        .Move2 = pk6.Move2,
                        .Move3 = pk6.Move3,
                        .Move4 = pk6.Move4,
                        .Nickname = pk6.Nickname,
                        .OTName = pk6.OT_Name,
                        .Species = pk6.Species}

                context.GeneralPokemonMetadata.Add(meta)

                context.SaveChanges()
            End Using
            Return RedirectToAction("Details", New With {.id = newPKMID})
            'Catch ex As Exception
            '    Return View()
            'End Try
        End Function

        '' GET: Pokemon/Edit/5
        'Function Edit(ByVal id As Integer) As ActionResult
        '    Return View()
        'End Function

        '' POST: Pokemon/Edit/5
        '<HttpPost()>
        'Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        '    Try
        '        ' TODO: Add update logic here

        '        Return RedirectToAction("Index")
        '    Catch
        '        Return View()
        '    End Try
        'End Function

        '' GET: Pokemon/Delete/5
        'Function Delete(ByVal id As Integer) As ActionResult
        '    Return View()
        'End Function

        '' POST: Pokemon/Delete/5
        '<HttpPost()>
        'Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        '    Try
        '        ' TODO: Add delete logic here

        '        Return RedirectToAction("Index")
        '    Catch
        '        Return View()
        '    End Try
        'End Function
    End Class
End Namespace