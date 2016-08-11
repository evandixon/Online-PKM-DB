@ModelType Online_PKM_DB.ViewModels.GeneralPKMViewModel
@Code
    ViewData("Title") = "Details"
End Code

<h2>@Html.DisplayFor(Function(model) model.Nickname)</h2>

@If Model.IsPrivate Then
    @<p><b>This Pokémon is private, so only you and moderators can see it.</b></p>
ElseIf Model.ShowUnlistedNotice Then
    @<p>This Pokémon is unlisted, so you must provide the link for others to see it.</p>
End If
@If Model.ShowDownloadDisabledNotice Then
    @<p><b>Downloads are disabled for this Pokémon, so only you and moderators can download it.</b></p>
End If


<div>
    @Html.Partial("PokemonDetails/_PokemonGeneral", Model)
</div>
<div class="row">
    <div class="col-md-6">
        @Html.Partial("PokemonDetails/_OTMisc", Model)
    </div>
    <div class="col-md-6">
        @Html.Partial("PokemonDetails/_PokemonMet", Model)
    </div>
</div>
<div class="row">
    <div class="col-md-6">
        @Html.Partial("PokemonDetails/_PokemonStats", Model)
    </div>
    <div class="col-md-6">
        @Html.Partial("PokemonDetails/_ContestStats", Model)
    </div>
</div>
<div>
    @Html.Partial("PokemonDetails/_PokemonMoves", Model)
</div>
<div>
    @If TypeOf Model Is Online_PKM_DB.ViewModels.PK6ViewModel Then
        @Html.Partial("PokemonDetails/_PokemonLegality", Model)
    End If
</div>
<p>
    @*@Html.ActionLink("Edit", "Edit", New With {.id = Model.PrimaryKey}) |*@
    @Html.ActionLink("Back to List", "Index")
</p>
