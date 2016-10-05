@ModelType Online_PKM_DB.ViewModels.PokemonUploadViewModel
@Code
    ViewData("Title") = Language.Create.UploadTitle
End Code

<h2>@Language.Create.UploadTitle</h2>

@If Not My.User.IsAuthenticated Then
    @<p><b>@Language.Create.AnonymousNotice</b></p>
End If

@Using (Html.BeginForm("Create", "Pokemon", FormMethod.Post, New With {.enctype = "multipart/form-data", .class = "form-horizontal"}))

    @<div class="form-group">
        <input type="file" name="file" id="file" value="@Model.File" />
    </div>

    @<div class="form-group">
        <div class="checkbox">
            <label>
                @Html.CheckBoxFor(Function(x) x.IsUnlisted)
                @Language.Create.UnlistedLabel
            </label>
        </div>

        <div class="checkbox">
            <label>
                @Html.CheckBoxFor(Function(x) x.IsPrivate)
                @Language.Create.PrivateLabel
            </label>
        </div>

        <div class="checkbox">
            <label>
                @Html.CheckBoxFor(Function(x) x.DisableDownloading)
                @Language.Create.DisableDownloadsLabel
            </label>
        </div>
    </div>

    @<br />
    @<input type="submit" value="@Language.General.Upload" Class="save" id="btnid" />
End Using
