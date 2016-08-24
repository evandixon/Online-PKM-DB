@ModelType Online_PKM_DB.ViewModels.PokemonUploadViewModel
@Code
    ViewData("Title") = Language.General.Create
End Code

<h2>@Language.General.Create</h2>

@If Not My.User.IsAuthenticated Then
    @<p><b>@Language.Create.AnonymousNotice</b></p>
End If

@Using (Html.BeginForm("Create", "Pokemon", FormMethod.Post, New With {.enctype = "multipart/form-data"}))
   @Language.Create.UnlistedLabel
   @Html.CheckBoxFor(Function(x) x.IsUnlisted)
    @<br />

   @Language.Create.PrivateLabel
   @Html.CheckBoxFor(Function(x) x.IsPrivate)
    @<br />

   @Language.Create.DisableDownloadsLabel
   @Html.CheckBoxFor(Function(x) x.DisableDownloading)
    @<br />

   @<input type="file" name="file" id="file" value="@Model.File" />
    @<br />

   @<input type="submit" value="@Language.General.Upload" Class="save" id="btnid" />
End Using