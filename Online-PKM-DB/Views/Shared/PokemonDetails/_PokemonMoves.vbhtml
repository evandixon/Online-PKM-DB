@ModelType Online_PKM_DB.ViewModels.GeneralPKMViewModel
<div class="row">
    <div class="col-md-6">
        <h4>Moves</h4>
        <hr />
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
    <div class="col-md-6">
        @If TypeOf Model Is Online_PKM_DB.ViewModels.PK6ViewModel Then
            Dim pk6 As Online_PKM_DB.ViewModels.PK6ViewModel = Model

            @<h4>Relearn Moves</h4>
            @<hr />
            @<ul>
                <li>
                    @Html.DisplayFor(Function(model) pk6.RelearnMove1)
                </li>
                <li>
                    @Html.DisplayFor(Function(model) pk6.RelearnMove2)
                </li>
                <li>
                    @Html.DisplayFor(Function(model) pk6.RelearnMove3)
                </li>
                <li>
                    @Html.DisplayFor(Function(model) pk6.RelearnMove4)
                </li>
            </ul>
        End If
    </div>
</div>