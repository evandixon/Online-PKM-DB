Namespace ViewModels
    Public Class PKMUserSearchResults
        Inherits PKMSearchResults

        Public Sub New(results As List(Of GeneralPKMMetaDataViewModel), totalCount As Integer, countPerPage As Integer, username As String)
            MyBase.New(results, totalCount, countPerPage)
            Me.Username = username
        End Sub

        Public Property Username As String
    End Class
End Namespace

