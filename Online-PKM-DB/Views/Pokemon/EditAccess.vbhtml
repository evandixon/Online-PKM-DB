@ModelType Online_PKM_DB.ViewModels.PokemonEditAccessViewModel
@Code
    ViewData("Title") = "Edit Access"
End Code

<h2>Edit Access</h2>

@Using (Html.BeginForm("EditAccess", "Pokemon", FormMethod.Post, New With {.enctype = "multipart/form-data", .class = "form-horizontal"}))

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
    @<input type="submit" value="@Language.General.Save" Class="save" id="btnid" />
End Using
