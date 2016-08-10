@ModelType Online_PKM_DB.ViewModels.GeneralPKMViewModel
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
</div>