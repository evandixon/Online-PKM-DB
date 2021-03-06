﻿@ModelType Online_PKM_DB.ViewModels.PKMSearchResults

@Html.Partial("_Pager", New Online_PKM_DB.ViewModels.PagerViewModel(Html, ViewContext.RouteData.Values, Model.CountPerPage, Model.TotalResultCount))

<table class="table">
    <tr>
        <th></th>
        <th>
            Nickname
        </th>
        <th>
            Level
        </th>
        <th>
            Ability
        </th>
        <th>
            Move 1
        </th>
        <th>
            Move 2
        </th>
        <th>
            Move 3
        </th>
        <th>
            Move 4
        </th>
        <th>Uploaded By</th>
        <th>Uploaded On</th>
        <th></th>
    </tr>

    @For Each item In Model.Results
        @<tr>
            <td>
                <img src="@item.IconUrl" alt="Icon" />
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Nickname)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Level)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Ability)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Move1)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Move2)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Move3)
            </td>
             <td>
                 @Html.DisplayFor(Function(modelItem) item.Move4)
             </td>
             <td>
                 @Html.ActionLink(item.UploaderUsername, "SearchByUser", New With {.username = item.UploaderUsername})
             </td>
             <td>
                 @Html.DisplayFor(Function(modelItem) item.UploadedDate)
             </td>
            <td>
                @*@Html.ActionLink("Edit", "Edit", New With {.id = item.PrimaryKey}) |*@
                @Html.ActionLink("Details", "Details", New With {.id = item.PokemonID}) @*|
                    @Html.ActionLink("Delete", "Delete", New With {.id = item.PrimaryKey})*@
            </td>
        </tr>
    Next
</table>

@Html.Partial("_Pager", New Online_PKM_DB.ViewModels.PagerViewModel(Html, ViewContext.RouteData.Values, Model.CountPerPage, Model.TotalResultCount))