﻿@ModelType Online_PKM_DB.Models.Pokemon.Category
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

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
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
