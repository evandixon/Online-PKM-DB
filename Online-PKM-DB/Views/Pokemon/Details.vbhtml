@ModelType Online_PKM_DB.ViewModels.PK6ViewModel
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>PK6ViewModel</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.SpeciesID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SpeciesID)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.SpeciesName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SpeciesName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Nickname)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Nickname)
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
</div>
<p>
    @*@Html.ActionLink("Edit", "Edit", New With {.id = Model.PrimaryKey}) |*@
    @Html.ActionLink("Back to List", "Index")
</p>
