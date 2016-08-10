@ModelType Online_PKM_DB.ViewModels.GeneralPKMViewModel
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
        @If Model.MetDate.HasValue Then
            @<dt>
                @Html.DisplayNameFor(Function(model) model.MetDate)
            </dt>
            @<dd>
                @Html.DisplayFor(Function(model) model.MetDate)
            </dd>
        End If


        @* Fateful Encounter *@
        <dt>
            @Html.DisplayNameFor(Function(model) model.FatefulEncounter)
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.FatefulEncounter)
        </dd>

        
        @* Was Egg & Egg Date *@
        @If TypeOf Model Is Online_PKM_DB.ViewModels.PK6ViewModel Then
            Dim pk6 As Online_PKM_DB.ViewModels.PK6ViewModel = Model

            @<dt>
                @Html.DisplayNameFor(Function(x) pk6.MetAsEgg)
            </dt>
            @<dd>
                @Html.DisplayFor(Function(x) pk6.MetAsEgg)
            </dd>

            If pk6.MetAsEgg Then
                @<dt>
                    @Html.DisplayNameFor(Function(x) pk6.EggMetDate)
                </dt>
                @<dd>
                    @Html.DisplayFor(Function(x) pk6.EggMetDate)
                </dd>
            End If

        End If   

    </dl>
</div>
