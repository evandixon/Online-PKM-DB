@ModelType Online_PKM_DB.ViewModels.PKMSearchResults
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Upload", "Create")
</p>
@Html.Partial("_PokemonList", Model)
