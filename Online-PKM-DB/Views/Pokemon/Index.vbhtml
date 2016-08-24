@ModelType Online_PKM_DB.ViewModels.PKMSearchResults
@Code
ViewData("Title") = "Index"
End Code

<h2>@Language.Index.Index</h2>

<p>
    @Html.ActionLink(Language.Index.Upload, "Create")
</p>
@Html.Partial("_PokemonList", Model)
