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
            Dim entries As List(Of GeneralPKMMetaDataViewModel)
            Using context As New PkmDBContext
                entries = (From f In context.PokemonFormats
                           From p In f.Pokemon
                           From m In p.GeneralMetadata
                           Order By p.UploadDate Descending
                           Select New With {.Metadata = m, .PokemonID = p.ID}).Take(50).AsEnumerable.Select(Function(x) New GeneralPKMMetaDataViewModel(x.Metadata, x.PokemonID)).ToList
            End Using
            Return View(entries)
        End Function

        ' GET: Pokemon/Details/5
        Function Details(ByVal id As Guid) As ActionResult
            Dim model As Object
            Using context As New PkmDBContext
                Dim query = (From p In context.Pokemon
                             Let f = p.Format
                             Where p.ID = id
                             Select New With {
                                 .Data = p.RawData,
                                 .Format = f.StandardCode,
                                 .UploadDate = p.UploadDate,
                                 .UploaderID = p.UploaderUserID
                                 }
                            ).FirstOrDefault
                If query Is Nothing Then
                    Return HttpNotFound()
                End If

                Dim uploaderUsername As String
                Dim uploaderUserID As String = query.UploaderID
                Using usersContext As New ApplicationDbContext
                    uploaderUsername = (From u In usersContext.Users Where u.Id = query.UploaderID Select u.UserName).FirstOrDefault
                End Using

                If String.IsNullOrEmpty(uploaderUsername) Then
                    uploaderUsername = "(Anonymous)"
                    uploaderUserID = Guid.Empty.ToString
                End If

                Select Case query.Format
                    Case "PK6"
                        model = New PK6ViewModel(New PKHeX.PK6(query.Data), id, query.UploadDate, uploaderUserID, uploaderUsername)
                        Return View("~/Views/Pokemon/PK6.vbhtml", model)
                    Case "PK5", "PK4", "PK3"
                        model = New GeneralPKMViewModel(PKHeX.PKMConverter.getPKMfromBytes(query.Data), id, query.UploadDate, uploaderUserID, uploaderUsername)
                        Return View("~/Views/Pokemon/GeneralPKM.vbhtml", model)
                    Case Else
                        Return View("~/Views/Pokemon/UnsupportedPKMFormat.vbhtml")
                End Select
            End Using
        End Function

        Function Download(ByVal id As Guid) As ActionResult
            Dim data As Byte()
            Dim name As String
            Using context As New PkmDBContext
                Dim query = (From p In context.Pokemon
                             Let f = p.Format
                             Where p.ID = id
                             Select New With {
                                 .Data = p.RawData,
                                 .Format = f.StandardCode
                             }).FirstOrDefault
                If query Is Nothing Then
                    Return HttpNotFound()
                Else
                    Dim pkm = PKHeX.PKMConverter.getPKMfromBytes(query.Data)
                    data = query.Data
                    name = pkm.Nickname

                    Select Case query.Format
                        Case "PK6"
                            name &= ".pk6"
                        Case "PK5"
                            name &= ".pk5"
                        Case "PK4"
                            name &= ".pk4"
                        Case "PK3"
                            name &= ".pk3"
                    End Select
                End If
            End Using

            'Todo: determine mime type and extension based on format
            Return File(data, "pkhex/pkm", name)
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

            'Detect the type
            Dim formatCode As String
            Dim pkm = PKHeX.PKMConverter.getPKMfromBytes(data)
            Select Case PKHeX.PKMConverter.getPKMDataFormat(data)
                Case 6
                    formatCode = "PK6"
                Case 5
                    formatCode = "PK5"
                Case 4
                    formatCode = "PK4"
                Case 3
                    formatCode = "PK3"
                Case Else
                    Throw New Http.HttpResponseException(Net.HttpStatusCode.BadRequest)
            End Select

            'Add the data to the database
            Dim newPKMID As Guid = Guid.NewGuid
            Using context As New PkmDBContext
                Dim formatID = PkmDBHelper.GetFormatID(formatCode, context)
                Dim pkmModel As New Pokemon With
                        {.ID = newPKMID,
                        .FormatID = formatID,
                        .RawData = data,
                        .UploadDate = Date.UtcNow,
                        .UploaderUserID = User.Identity.GetUserId}
                context.Pokemon.Add(pkmModel)

                Dim meta As New PokemonGeneralMetadata With {
                        .ID = Guid.NewGuid,
                        .PokemonID = pkmModel.ID,
                        .Ability = pkm.Ability,
                        .Level = pkm.CurrentLevel,
                        .Move1 = pkm.Move1,
                        .Move2 = pkm.Move2,
                        .Move3 = pkm.Move3,
                        .Move4 = pkm.Move4,
                        .Nickname = pkm.Nickname,
                        .OTName = pkm.OT_Name,
                        .Species = pkm.Species}

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