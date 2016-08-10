@ModelType Online_PKM_DB.ViewModels.GeneralPKMViewModel
<div>
    <h4>Contest Stats</h4>
    <hr />
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
