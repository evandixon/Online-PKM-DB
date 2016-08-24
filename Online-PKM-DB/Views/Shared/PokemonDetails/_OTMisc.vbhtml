@ModelType Online_PKM_DB.ViewModels.GeneralPKMViewModel
<div>
    <h4>@Language.Pokemon.OTMisc</h4>
    <hr />
    <dl class="dl-horizontal">
        @* TID *@
        <dt>
            @Language.Pokemon.TID
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.TID)
        </dd>

        @* SID *@
        <dt>
            @Language.Pokemon.SID
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.SID)
        </dd>

        @* OT *@
        <dt>
            @Language.Pokemon.OT
        </dt>
        <dd>
            <span class="@Model.LabelOTClass">@Html.DisplayFor(Function(model) model.OT)</span>
        </dd>

        @* Handler *@
        @If TypeOf Model Is Online_PKM_DB.ViewModels.PK6ViewModel Then
            Dim pk6 As Online_PKM_DB.ViewModels.PK6ViewModel = Model

            @<dt>
                @Language.Pokemon.LatestHandler
            </dt>
            @<dd>
                <span Class="@pk6.LatestHandlerClass">@Html.DisplayFor(Function(model) pk6.LatestHandler)</span>
            </dd>
        End If        

    </dl>
</div>
