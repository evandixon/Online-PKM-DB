Namespace ViewModels
    Public Class PKMSearchResults
        Public Sub New(results As List(Of GeneralPKMMetaDataViewModel), totalCount As Integer, countPerPage As Integer)
            Me.Results = results
            Me.TotalResultCount = totalCount
            Me.CountPerPage = countPerPage
        End Sub

        Public Property Results As List(Of GeneralPKMMetaDataViewModel)

        Public Property TotalResultCount As Integer
        Public Property CountPerPage As Integer
    End Class
End Namespace

