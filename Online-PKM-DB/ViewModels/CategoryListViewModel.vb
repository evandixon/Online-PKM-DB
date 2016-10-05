Namespace ViewModels
    Public Class CategoryListViewModel
        Public Sub New()
            ChildCategories = New List(Of CategoryListViewModel)
        End Sub
        Public Property ID As Guid
        Public Property Name As String
        Public Property Description As String
        Public Property UploadCount As Integer
        Public Property LastUploadDate As DateTime?
        Public Property LastUploadUsername As String
        Public Property LastUploadUserID As String
        Public Property OwnerUploadUsername As String
        Public Property OwnerUploadUserID As String
        Public Property IsSiteCategory As Boolean
        Public Property SortOrder As Integer
        Public Property IsLocked As Boolean
        Public Property IsHidden As Boolean
        Public Property ChildCategories As List(Of CategoryListViewModel)
    End Class
End Namespace
