@ModelType Online_PKM_DB.ViewModels.GeneralPKMViewModel
<div>
    <h4>Contest Stats</h4>
    <hr />
    <table class="stat-table">
        <thead>
            <tr>
                <td>@Language.Pokemon.Cool</td>
                <td>@Language.Pokemon.Beauty</td>
                <td>@Language.Pokemon.Cute</td>
                <td>@Language.Pokemon.Clever</td>
                <td>@Language.Pokemon.Tough</td>
                <td>@Language.Pokemon.Sheen</td>
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
