@ModelType Online_PKM_DB.ViewModels.PKMSearchResults
@Code
    ViewData("Title") = Language.General.Upload
End Code

<h2>@Language.General.Index</h2>

<p>
    @Html.ActionLink(Language.General.Upload, "Create")
</p>
@Html.Partial("_PokemonList", Model)
