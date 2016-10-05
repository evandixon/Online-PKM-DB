@ModelType Online_PKM_DB.Models.Pokemon.Category
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Category</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.EntityType.StandardCode)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.EntityType.StandardCode)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ParentCategoryID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ParentCategoryID)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.SortOrder)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SortOrder)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.OwnerID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.OwnerID)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.IsSiteCategory)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IsSiteCategory)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Description)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.IsLocked)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IsLocked)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.IsHidden)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IsHidden)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
