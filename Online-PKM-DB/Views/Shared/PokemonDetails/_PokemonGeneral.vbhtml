@ModelType Online_PKM_DB.ViewModels.GeneralPKMViewModel
<div>
    <h4>General</h4>
    <hr />
    <div class="row">
        <div class="col-md-8">
            <dl class="dl-horizontal">
                @* PID *@
                <dt>
                    @Html.DisplayNameFor(Function(model) model.PID)
                </dt>
                <dd>
                    @Html.DisplayFor(Function(model) model.PID)
                </dd>

                @* Species *@
                <dt>
                    @Html.DisplayNameFor(Function(model) model.SpeciesName)
                </dt>
                <dd>
                    @Html.DisplayFor(Function(model) model.SpeciesName)
                </dd>

                @* Nickname *@
                <dt>
                    @Html.DisplayNameFor(Function(model) model.Nickname)
                </dt>
                <dd>
                    @Html.DisplayFor(Function(model) model.Nickname)
                </dd>
                <dt>
                    @Html.DisplayNameFor(Function(model) model.IsNicknamed)
                </dt>
                <dd>
                    @Html.DisplayFor(Function(model) model.IsNicknamed)
                </dd>

                @* Exp *@
                <dt>
                    @Html.DisplayNameFor(Function(model) model.Exp)
                </dt>
                <dd>
                    @Html.DisplayFor(Function(model) model.Exp)
                </dd>

                @* Level *@
                <dt>
                    @Html.DisplayNameFor(Function(model) model.Level)
                </dt>
                <dd>
                    @Html.DisplayFor(Function(model) model.Level)
                </dd>

                @* Nature *@
                <dt>
                    @Html.DisplayNameFor(Function(model) model.Nature)
                </dt>
                <dd>
                    @Html.DisplayFor(Function(model) model.Nature)
                </dd>

                @* Held Item *@
                <dt>
                    @Html.DisplayNameFor(Function(model) model.HeldItem)
                </dt>
                <dd>
                    @Html.DisplayFor(Function(model) model.HeldItem)
                </dd>

                @* Friendship *@
                <dt>
                    @Html.DisplayNameFor(Function(model) model.Friendship)
                </dt>
                <dd>
                    @Html.DisplayFor(Function(model) model.Friendship)
                </dd>

                @* Ability *@
                <dt>
                    @Html.DisplayNameFor(Function(model) model.Ability)
                </dt>
                <dd>
                    @Html.DisplayFor(Function(model) model.Ability)
                </dd>

                @* Language *@
                <dt>
                    @Html.DisplayNameFor(Function(model) model.Language)
                </dt>
                <dd>
                    @Html.DisplayFor(Function(model) model.Language)
                </dd>

                @* Is Egg *@
                <dt>
                    @Html.DisplayNameFor(Function(model) model.IsEgg)
                </dt>
                <dd>
                    @Html.DisplayFor(Function(model) model.IsEgg)
                </dd>

                @* Infected *@
                <dt>
                    @Html.DisplayNameFor(Function(model) model.IsInfected)
                </dt>
                <dd>
                    @Html.DisplayFor(Function(model) model.IsInfected)
                </dd>

                @* Cured *@
                <dt>
                    @Html.DisplayNameFor(Function(model) model.IsCured)
                </dt>
                <dd>
                    @Html.DisplayFor(Function(model) model.IsCured)
                </dd>

                @* Is Legal *@
                @If TypeOf Model Is Online_PKM_DB.ViewModels.PK6ViewModel Then
                    @<dt>
                        @Html.DisplayNameFor(Function(model) model.IsLegal)
                    </dt>
                    @<dd>
                        @Html.DisplayFor(Function(model) model.IsLegal)
                        @*@If Not Model.IsLegal Then*@
                        <span> - <a href="#legality-report"> See Report</a></span>
                        @*End If*@
                    </dd>
                End If                

                @* Uploader *@
                <dt>
                    Date Uploaded
                </dt>
                <dd>
                    @Html.DisplayFor(Function(model) model.UploadDate)
                </dd>

                @* Upload Date *@
                <dt>
                    Uploaded By
                </dt>
                <dd>
                    @Html.ActionLink(Model.UploaderUsername, "SearchByUser", New With {.username = Model.UploaderUsername})
                </dd>

                @*@* Country
            <dt>
                @Html.DisplayNameFor(Function(model) model.Country)
            </dt>
            <dd>
                @Html.DisplayFor(Function(model) model.Country)
            </dd>

            @* Console Region
            <dt>
                @Html.DisplayNameFor(Function(model) model.ConsoleRegion)
            </dt>
            <dd>
                @Html.DisplayFor(Function(model) model.ConsoleRegion)
            </dd>*@

            </dl>
        </div>
        <div class="col-md-4">
            <div class="pkm-image-panel">
                <div class="pkm-image-inner">
                    <a href="@Model.SugimoriArtworkUrl"><img alt="@Model.SpeciesName Sugimori Artwork" src="@Model.SugimoriArtworkUrl" class="pkm-image" /></a>
                </div>
            </div>
        </div>
    </div>
    @If Model.CanDownload Then
        @Html.ActionLink("Download " & Model.PokemonFormatFriendlyName, "Download", New With {.id = Model.PokemonID})
    End If
    @If Model.CanDownload AndAlso Model.CanDelete Then
        @Html.Raw(" | ")
    End If
    @If Model.CanDelete() Then
        @<span>@Html.ActionLink("Delete", "Delete", New With {.id = Model.PokemonID})</span>
    End If
</div>