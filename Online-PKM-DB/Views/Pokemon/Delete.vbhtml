@ModelType Online_PKM_DB.ViewModels.GeneralPKMMetaDataViewModel
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>
<hr />
<h3>Are you sure you want to delete @Html.DisplayFor(Function(model) model.Nickname)?</h3>
<div>
    <dl class="dl-horizontal">

        <dt>
            @Html.DisplayNameFor(Function(model) model.SpeciesName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SpeciesName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Level)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Level)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Ability)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Ability)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Move1)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Move1)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Move2)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Move2)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Move3)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Move3)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Move4)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Move4)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
