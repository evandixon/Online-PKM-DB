@ModelType Online_PKM_DB.ViewModels.GeneralPKMMetaDataViewModel
@Code
    ViewData("Title") = @Language.General.Delete
End Code

<h2>@Language.General.Delete</h2>
<hr />
<h3>@String.Format(Language.Delete.DeleteConfirmation, Html.DisplayFor(Function(model) model.Nickname))</h3>
<div>
<dl Class="dl-horizontal">

        <dt>
            @Language.Delete.SpeciesName
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SpeciesName)
        </dd>

        <dt>
            @Language.Delete.Level
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Level)
        </dd>

        <dt>
            @Language.Delete.Ability
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Ability)
        </dd>

        <dt>
            @Language.Delete.Move1
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Move1)
        </dd>

        <dt>
            @Language.Delete.Move2
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Move2)
        </dd>

        <dt>
            @Language.Delete.Move3
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Move3)
        </dd>

        <dt>
            @Language.Delete.Move4
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Move4)
        </dd>

        @* Uploader *@
        <dt>
            @Language.Delete.DateUploaded
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.UploadedDate)
        </dd>

        @* Upload Date *@
        <dt>
            @Language.Delete.UploadedBy
        </dt>
        <dd>
            @Html.ActionLink(Model.UploaderUsername, "SearchByUser", New With {.username = Model.UploaderUsername})
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="@Language.General.Delete" class="btn btn-default" /> |
            @Html.ActionLink(Language.General.BackToList, "Index")
        </div>
    End Using
</div>
