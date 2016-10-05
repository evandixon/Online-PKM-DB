@ModelType IEnumerable(Of Online_PKM_DB.Models.Pokemon.Category)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.EntityType.StandardCode)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ParentCategoryID)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.SortOrder)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.OwnerID)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.IsSiteCategory)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Description)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.IsLocked)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.IsHidden)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.EntityType.StandardCode)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ParentCategoryID)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.SortOrder)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.OwnerID)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.IsSiteCategory)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Name)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Description)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.IsLocked)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.IsHidden)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>
