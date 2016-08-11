@ModelType Online_PKM_DB.ViewModels.PokemonUploadViewModel
@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

@If Not My.User.IsAuthenticated Then
    @<p><b>Note: you are not logged in.  If you proceed to upload this Pokémon, you will be unable to modify or delete it (when these features are available).</b></p>
End If

@Using (Html.BeginForm("Create", "Pokemon", FormMethod.Post, New With {.enctype = "multipart/form-data"}))
   @Html.Raw("Unlisted: ")
   @Html.CheckBoxFor(Function(x) x.IsUnlisted)
    @<br />

   @Html.Raw("Private: ")
   @Html.CheckBoxFor(Function(x) x.IsPrivate)
    @<br />

   @Html.Raw("Disable Downloads: ")
   @Html.CheckBoxFor(Function(x) x.DisableDownloading)
    @<br />

   @<input type="file" name="file" id="file" value="@Model.File" />
    @<br />

   @<input type="submit" value="Upload" Class="save" id="btnid" />
End Using