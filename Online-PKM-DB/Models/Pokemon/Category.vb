Imports System.ComponentModel.DataAnnotations

Namespace Models.Pokemon

    ''' <summary>
    ''' Collection of a particular type of <see cref="Entity"/>.
    ''' </summary>
    ''' <remarks>
    ''' To get the Entities within this category, use the following logical query:
    ''' Inner Join EntityType t on t.ID = Category.EntityTypeID
    ''' Inner Join Entity e on e.
    ''' </remarks>
    Public Class Category

        <Required> <Key> Public Property ID As Guid

        Public Property ParentCategoryID As Guid?

        <Required> Public Property SortOrder As Integer

        ''' <summary>
        ''' (Optional) ID of the user who owns the category.
        ''' </summary>
        Public Property OwnerID As String

        ''' <summary>
        ''' Whether or not the category belongs to the website.
        ''' </summary>
        ''' <remarks>If true, this category will be listed on the main category index, in addition to being displayed with users' categories.
        ''' If false, this category will only be visible on the Owner's page.</remarks>
        <Required> Public Property IsSiteCategory As Boolean

        <Required> Public Property Name As String

        Public Property Description As String

        ''' <summary>
        ''' Type of entity that can be stored in this category.
        ''' </summary>
        <Required> Public Property EntityTypeID As Guid

        ''' <summary>
        ''' Prevents uploads by anyone but moderators and category owners.
        ''' </summary>
        <Required> Public Property IsLocked As Boolean

        ''' <summary>
        ''' Prevents viewing by anyone but moderators and category owners.
        ''' </summary>
        <Required> Public Property IsHidden As Boolean


        ''' <summary>
        ''' Type of entity that can be stored in this category.
        ''' </summary>
        Public Overridable Property EntityType As EntityType

        Public Overridable Property Entities As ICollection(Of Entity)
    End Class

End Namespace