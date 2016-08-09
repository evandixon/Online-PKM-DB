@ModelType IEnumerable(Of Online_PKM_DB.ViewModels.PK6MetaDataViewModel)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>This page is still under construction, so only the first 50 Pokémon are visible.</p>

<p>
    @Html.ActionLink("Upload", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.SpeciesID)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.SpeciesName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Nickname)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Level)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Ability)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Move1)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Move2)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Move3)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Move4)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.SpeciesID)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.SpeciesName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Nickname)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Level)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Ability)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Move1)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Move2)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Move3)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Move4)
        </td>
        <td>
            @*@Html.ActionLink("Edit", "Edit", New With {.id = item.PrimaryKey}) |*@
            @Html.ActionLink("Details", "Details", New With {.id = item.PokemonID}) @*|
            @Html.ActionLink("Delete", "Delete", New With {.id = item.PrimaryKey})*@
        </td>
    </tr>
Next

</table>
