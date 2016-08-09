@ModelType Online_PKM_DB.ViewModels.PKMUserSearchResults
@Code
    ViewData("Title") = "SearchByUser"
End Code

<h2>Search</h2>

<div>
    <h4>@Html.DisplayFor(Function(model) model.TotalResultCount) Pokémon Uploaded By @Html.DisplayFor(Function(model) model.Username)</h4>
    <hr />
    @Html.Partial("_PokemonList", Model)
</div>
<p>
    @*@Html.ActionLink("Edit", "Edit", New With {.id = Model.PrimaryKey}) |*@
    @Html.ActionLink("Back to List", "Index")
</p>
