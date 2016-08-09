@ModelType Online_PKM_DB.ViewModels.GeneralPKMViewModel
@Code
    ViewData("Title") = "Details"
End Code

<h2>@Html.DisplayFor(Function(model) model.Nickname)</h2>

<div>
    <h4>General</h4>
    <hr />
    <div class="pkm-image-panel">
        <div class="pkm-image-inner">
            <a href="@Model.SugimoriArtworkUrl"><img alt="@Model.SpeciesName Sugimori Artwork" src="@Model.SugimoriArtworkUrl" class="pkm-image" /></a>
        </div>
    </div>
    <div style="float:left;">
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
    <div style = "clear:both;" />
    @Html.ActionLink("Download PK6", "Download", New With {.id = Model.PokemonID})
</div>
<div>
    <h4>Met</h4>
    <hr />
    <dl class="dl-horizontal">
        @* MetLevel *@
        <dt>
            @Html.DisplayNameFor(Function(model) model.MetLevel)
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.MetLevel)
        </dd>

        @* Met Date *@
        <dt>
            @Html.DisplayNameFor(Function(model) model.MetDate)
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.MetDate)
        </dd>

        @* Fateful Encounter *@
        <dt>
            @Html.DisplayNameFor(Function(model) model.FatefulEncounter)
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.FatefulEncounter)
        </dd>

    </dl>
</div>
<div>
    <h4>Stats</h4>
    <hr />
    <table class="stat-table">
        <thead>
            <tr>
                <td></td>
                <td><b>IVs</b></td>
                <td><b>EVs</b></td>
                @*<td>Stats</td>*@
            </tr>
        </thead>
        <tr>
            <td class="stat-normal">HP</td>
            <td>@Html.DisplayFor(Function(model) model.IV_HP)</td>
            <td>@Html.DisplayFor(Function(model) model.EV_HP)</td>
            @*<td>@Html.DisplayFor(Function(model) model.Stat_HP)</td>*@
        </tr>
        <tr>
            <td class="@Model.LabelClass_Atk">Attack</td>
            <td>@Html.DisplayFor(Function(model) model.IV_Atk)</td>
            <td>@Html.DisplayFor(Function(model) model.EV_Atk)</td>
            @*<td>@Html.DisplayFor(Function(model) model.Stat_Atk)</td>*@
        </tr>
        <tr>
            <td class="@Model.LabelClass_Def">Defense</td>
            <td>@Html.DisplayFor(Function(model) model.IV_Def)</td>
            <td>@Html.DisplayFor(Function(model) model.EV_Def)</td>
            @*<td>@Html.DisplayFor(Function(model) model.Stat_Def)</td>*@
        </tr>
        <tr>
            <td class="@Model.LabelClass_SpA">Sp. Attack</td>
            <td>@Html.DisplayFor(Function(model) model.IV_SpA)</td>
            <td>@Html.DisplayFor(Function(model) model.EV_SpA)</td>
            @*<td>@Html.DisplayFor(Function(model) model.Stat_SpA)</td>*@
        </tr>
        <tr>
            <td class="@Model.LabelClass_SpD">Sp. Defense</td>
            <td>@Html.DisplayFor(Function(model) model.IV_SpD)</td>
            <td>@Html.DisplayFor(Function(model) model.EV_SpD)</td>
            @*<td>@Html.DisplayFor(Function(model) model.Stat_SpD)</td>*@
        </tr>
        <tr>
            <td class="@Model.LabelClass_SpE">Speed</td>
            <td>@Html.DisplayFor(Function(model) model.IV_SpD)</td>
            <td>@Html.DisplayFor(Function(model) model.EV_SpD)</td>
            @*<td>@Html.DisplayFor(Function(model) model.Stat_SpA)</td>*@
        </tr>
        <tfoot>
            <tr>
                <td class="stat-normal">Total</td>
                <td><b>@Html.DisplayFor(Function(model) model.IV_Total)</b></td>
                <td><b>@Html.DisplayFor(Function(model) model.EV_Total)</b></td>
                @*<td></td>*@
            </tr>
        </tfoot>
    </table>
    <dl class="dl-horizontal">

        @* Potential *@
        <dt>
            @Html.DisplayNameFor(Function(model) model.Potential)
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.Potential)
        </dd>

        @* Hidden Power *@
        <dt>
            @Html.DisplayNameFor(Function(model) model.HiddenPowerType)
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.HiddenPowerType)
        </dd>

        @* Characteristic *@
        <dt>
            @Html.DisplayNameFor(Function(model) model.Characteristic)
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.Characteristic)
        </dd>
    </dl>
    <h5>Contest Stats</h5>
    <table class="stat-table">
        <thead>
            <tr>
                <td>Cool</td>
                <td>Beauty</td>
                <td>Cute</td>
                <td>Clever</td>
                <td>Tough</td>
                <td>Sheen</td>
            </tr>
        </thead>
        <tr>
            <td>@Html.DisplayFor(Function(model) model.ContestCool)</td>
            <td>@Html.DisplayFor(Function(model) model.ContestBeauty)</td>
            <td>@Html.DisplayFor(Function(model) model.ContestCute)</td>
            <td>@Html.DisplayFor(Function(model) model.ContestClever)</td>
            <td>@Html.DisplayFor(Function(model) model.ContestTough)</td>
            <td>@Html.DisplayFor(Function(model) model.ContestSheen)</td>
        </tr>
    </table>
</div>
<div>
    <h4>Attacks</h4>
    <hr />
    <h5>Current</h5>
    <table class="stat-table">
        <thead>
            <tr>
                <td></td>
                <td>PP</td>
                <td>PP Up</td>
            </tr>
        </thead>
        <tr>
            <td>@Html.DisplayFor(Function(model) model.Move1)</td>
            <td>@Html.DisplayFor(Function(model) model.MovePP1)</td>
            <td>@Html.DisplayFor(Function(model) model.MovePPUp1)</td>
        </tr>
        <tr>
            <td>@Html.DisplayFor(Function(model) model.Move2)</td>
            <td>@Html.DisplayFor(Function(model) model.MovePP2)</td>
            <td>@Html.DisplayFor(Function(model) model.MovePPUp2)</td>
        </tr>
        <tr>
            <td>@Html.DisplayFor(Function(model) model.Move3)</td>
            <td>@Html.DisplayFor(Function(model) model.MovePP3)</td>
            <td>@Html.DisplayFor(Function(model) model.MovePPUp3)</td>
        </tr>
        <tr>
            <td>@Html.DisplayFor(Function(model) model.Move4)</td>
            <td>@Html.DisplayFor(Function(model) model.MovePP4)</td>
            <td>@Html.DisplayFor(Function(model) model.MovePPUp4)</td>
        </tr>
    </table>    
</div>
<div>
    <h4>OT/Misc</h4>
    <dl class="dl-horizontal">
        @* TID *@
        <dt>
            @Html.DisplayNameFor(Function(model) model.TID)
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.TID)
        </dd>

        @* SID *@
        <dt>
            @Html.DisplayNameFor(Function(model) model.SID)
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.SID)
        </dd>

        @* OT *@
        <dt>
            @Html.DisplayNameFor(Function(model) model.OT)
        </dt>
        <dd>
            <span class="@Model.LabelOTClass">@Html.DisplayFor(Function(model) model.OT)</span>
        </dd>
    </dl>
</div>
<p>
    @*@Html.ActionLink("Edit", "Edit", New With {.id = Model.PrimaryKey}) |*@
    @Html.ActionLink("Back to List", "Index")
</p>
