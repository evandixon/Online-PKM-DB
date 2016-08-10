@ModelType Online_PKM_DB.ViewModels.GeneralPKMViewModel
<div>
    <h4>OT/Misc</h4>
    <hr />
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

        @* Handler *@
        @If TypeOf Model Is Online_PKM_DB.ViewModels.PK6ViewModel Then
            Dim pk6 As Online_PKM_DB.ViewModels.PK6ViewModel = Model

            @<dt>
                @Html.DisplayNameFor(Function(model) pk6.LatestHandler)
            </dt>
            @<dd>
                <span Class="@pk6.LatestHandlerClass">@Html.DisplayFor(Function(model) pk6.LatestHandler)</span>
            </dd>
        End If        

    </dl>
</div>
