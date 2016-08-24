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
            Return RedirectToAction("Latest", New With {.page = 0})
        End Function

        Function Latest(page As Integer) As ActionResult
            Dim pageSize = My.Settings.PokemonListCountPerPage

            Dim currentUserID As String = User.Identity.GetUserId
            Dim isModerator As Boolean = User.IsInRole("PKMDB-Moderator")

            'Get the PKM info
            Dim results As PKMSearchResults
            Using context As New PkmDBContext
                Dim query = (From f In context.PokemonFormats
                             From p In f.Entities
                             From m In p.GeneralMetadata
                             Where Not p.IsUnlisted AndAlso (Not p.IsPrivate OrElse p.UploaderUserID = currentUserID OrElse isModerator)
                             Order By p.UploadDate Descending
                             Select New With {.Metadata = m, .PokemonID = p.ID, .UploadDate = p.UploadDate, .UploaderUserID = p.UploaderUserID})
                Dim entries = query.Skip(page * pageSize).
                                    Take(pageSize).
                                    AsEnumerable.
                                    Select(Function(x) New GeneralPKMMetaDataViewModel(x.Metadata, x.PokemonID, x.UploadDate, x.UploaderUserID, Nothing)).ToList
                Dim count = query.Count
                results = New PKMSearchResults(entries, count, pageSize)
            End Using

            'Get the usernames
            PkmDBHelper.UpdateUsernames(results)

            Return View("Index", results)
        End Function

        ' GET: SearchByUser/evandixon
        <RequireQueryStringValues({"username"})>
        Function SearchByUser(username As String) As ActionResult
            Return SearchByUser(username, 0)
        End Function

        <RequireQueryStringValues({"username", "page"})>
        Function SearchByUser(username As String, page As Integer) As ActionResult
            Dim pageSize = My.Settings.PokemonListCountPerPage

            Dim results As PKMUserSearchResults

            'Get user ID for searching
            Dim userID As String
            If username = "(Anonymous)" Then
                userID = Nothing
            Else
                Using context As New ApplicationDbContext
                    userID = context.Users.Where(Function(x) x.UserName = username).Select(Function(x) x.Id).FirstOrDefault
                End Using
            End If

            Dim currentUserID As String = User.Identity.GetUserId
            Dim isModerator As Boolean = User.IsInRole("PKMDB-Moderator")

            Using context As New PkmDBContext
                Dim query = (From f In context.PokemonFormats
                             From p In f.Entities
                             From m In p.GeneralMetadata
                             Where p.UploaderUserID = userID AndAlso Not p.IsUnlisted AndAlso (Not p.IsPrivate OrElse p.UploaderUserID = currentUserID OrElse isModerator)
                             Order By p.UploadDate Descending
                             Select New With {.Metadata = m, .PokemonID = p.ID, .UploadDate = p.UploadDate, .UploaderUserID = p.UploaderUserID})
                Dim entries = query.Skip(page * pageSize).
                                    Take(pageSize).
                                    AsEnumerable.
                                    Select(Function(x) New GeneralPKMMetaDataViewModel(x.Metadata, x.PokemonID, x.UploadDate, x.UploaderUserID, Nothing)).ToList
                Dim count = query.Count
                results = New PKMUserSearchResults(entries, count, pageSize, username)
            End Using

            'Get the usernames
            PkmDBHelper.UpdateUsernames(results)

            Return View(results)
        End Function

        <Authorize>
        Function MyPokemon(Optional page As Integer = 0) As ActionResult
            Dim pageSize = My.Settings.PokemonListCountPerPage

            Dim results As PKMSearchResults

            Dim currentUserID As String = User.Identity.GetUserId

            Using context As New PkmDBContext
                Dim query = (From f In context.PokemonFormats
                             From p In f.Entities
                             From m In p.GeneralMetadata
                             Where p.UploaderUserID = currentUserID
                             Order By p.UploadDate Descending
                             Select New With {.Metadata = m, .PokemonID = p.ID, .UploadDate = p.UploadDate, .UploaderUserID = p.UploaderUserID})
                Dim entries = query.Skip(page * pageSize).
                                    Take(pageSize).
                                    AsEnumerable.
                                    Select(Function(x) New GeneralPKMMetaDataViewModel(x.Metadata, x.PokemonID, x.UploadDate, x.UploaderUserID, Nothing)).ToList
                Dim count = query.Count
                results = New PKMSearchResults(entries, count, pageSize)
            End Using

            'Get the usernames
            PkmDBHelper.UpdateUsernames(results)

            Return View(results)
        End Function

        ' GET: Pokemon/Details/5
        Function Details(ByVal id As Guid) As ActionResult
            Dim currentUserID As String = User.Identity.GetUserId
            Dim isModerator As Boolean = User.IsInRole("PKMDB-Moderator")

            Dim model As Object
            Using context As New PkmDBContext
                Dim query = (From p In context.Entities
                             Let f = p.Format
                             Where p.ID = id AndAlso (Not p.IsPrivate OrElse p.UploaderUserID = currentUserID OrElse isModerator)
                             Select New With {
                                 .Data = p.RawData,
                                 .Format = f,
                                 .UploadDate = p.UploadDate,
                                 .UploaderID = p.UploaderUserID,
                                 .IsUnlisted = p.IsUnlisted,
                                 .IsPrivate = p.IsPrivate,
                                 .DisableDownloading = p.DisableDownloading
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

                Select Case query.Format.StandardCode
                    Case "PK6"
                        model = New PK6ViewModel(New PKHeX.PK6(query.Data), id, query.Format.FriendlyName, query.UploadDate, uploaderUserID, uploaderUsername, User.Identity.GetUserId, query.IsUnlisted, query.IsPrivate, query.DisableDownloading)
                        Return View("~/Views/Pokemon/GeneralPKM.vbhtml", model)
                    Case "PK5", "PK4", "PK3"
                        model = New GeneralPKMViewModel(PKHeX.PKMConverter.getPKMfromBytes(query.Data), id, query.Format.FriendlyName, query.UploadDate, uploaderUserID, uploaderUsername, User.Identity.GetUserId, query.IsUnlisted, query.IsPrivate, query.DisableDownloading)
                        Return View("~/Views/Pokemon/GeneralPKM.vbhtml", model)
                    Case Else
                        Return View("~/Views/Pokemon/UnsupportedPKMFormat.vbhtml")
                End Select
            End Using
        End Function

        Function Download(ByVal id As Guid) As ActionResult
            Dim currentUserID As String = User.Identity.GetUserId
            Dim isModerator As Boolean = User.IsInRole("PKMDB-Moderator")

            Dim data As Byte()
            Dim name As String
            Using context As New PkmDBContext
                Dim query = (From p In context.Entities
                             Let f = p.Format
                             Where p.ID = id AndAlso (Not p.IsPrivate OrElse p.UploaderUserID = currentUserID OrElse isModerator) AndAlso (Not p.DisableDownloading OrElse p.UploaderUserID = currentUserID OrElse isModerator)
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
        Function Create() As ActionResult
            Return View(New PokemonUploadViewModel)
        End Function

        ' POST: Pokemon/Create
        <HttpPost()>
        Function Create(ByVal model As PokemonUploadViewModel) As ActionResult
            'Try
            'Ensure the size is OK
            If Not PKHeX.PKX.getIsPKM(model.File.ContentLength) Then
                Throw New Http.HttpResponseException(Net.HttpStatusCode.BadRequest)
            End If

            'Read the file
            Dim data(model.File.ContentLength - 1) As Byte
            model.File.InputStream.Read(data, 0, model.File.ContentLength)

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
                Dim userID As String = Nothing
                If My.User.IsAuthenticated Then
                    userID = User.Identity.GetUserId
                End If
                Dim formatID = PkmDBHelper.GetFormatID(formatCode, context)
                Dim pkmModel As New Entity With
                        {.ID = newPKMID,
                        .FormatID = formatID,
                        .RawData = data,
                        .UploadDate = Date.UtcNow,
                        .UploaderUserID = userID,
                        .IsUnlisted = model.IsUnlisted,
                        .IsPrivate = model.IsPrivate,
                        .DisableDownloading = model.DisableDownloading}
                context.Entities.Add(pkmModel)

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

        ' GET/POST: Pokemon/Delete/5
        Function Delete(ByVal id As Guid) As ActionResult
            Select Case HttpContext.Request.HttpMethod
                Case "GET"
                    Dim metadata As GeneralPKMMetaDataViewModel
                    Using context As New PkmDBContext
                        Dim model = (From p In context.Entities
                                     From m In p.GeneralMetadata
                                     Where p.ID = id
                                     Select New With {.Metadata = m, .PokemonID = p.ID, .uploadDate = p.UploadDate, .uploaderID = p.UploaderUserID}).FirstOrDefault
                        If model Is Nothing Then
                            Return HttpNotFound()
                        Else
                            If Not (User.Identity.GetUserId = model.uploaderID OrElse User.IsInRole("PKMDB-Moderator")) Then
                                Throw New Http.HttpResponseException(Net.HttpStatusCode.Unauthorized)
                            Else
                                Dim username As String
                                Using usersContext As New ApplicationDbContext
                                    username = usersContext.Users.Where(Function(x) x.Id = model.uploaderID).Select(Function(x) x.UserName).FirstOrDefault
                                End Using
                                If String.IsNullOrEmpty(username) Then
                                    username = "(Anonymous)"
                                End If

                                metadata = New GeneralPKMMetaDataViewModel(model.Metadata, model.PokemonID, model.uploadDate, model.uploaderID, username)
                                Return View(metadata)
                            End If
                        End If
                    End Using
                Case "POST"
                    Using context As New PkmDBContext
                        Dim uploaderID As String = context.Entities.Where(Function(x) x.ID = id).Select(Function(x) x.UploaderUserID).FirstOrDefault
                        If Not (User.Identity.GetUserId = uploaderID OrElse User.IsInRole("PKMDB-Moderator")) Then
                            Throw New Http.HttpResponseException(Net.HttpStatusCode.Unauthorized)
                        Else
                            context.Entities.RemoveRange(context.Entities.Where(Function(x) x.ID = id))
                            context.SaveChanges()
                        End If
                        context.Entities.RemoveRange(context.Entities.Where(Function(x) x.ID = id))
                        context.SaveChanges()
                    End Using
                    Return RedirectToAction("Index")
                Case Else
                    Return HttpNotFound()
            End Select
        End Function
    End Class
End Namespace