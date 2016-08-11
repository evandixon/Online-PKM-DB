@ModelType Online_PKM_DB.ViewModels.PKMSearchResults
@Code
    ViewData("Title") = "My Pokémon"
End Code

<h2>My Pokémon</h2>

<p>
    @Html.ActionLink("Upload", "Create")
</p>
@Html.Partial("_PokemonList", Model)
