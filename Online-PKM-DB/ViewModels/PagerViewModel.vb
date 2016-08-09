Namespace ViewModels
    Public Class PagerViewModel
        Public Sub New(html As HtmlHelper, routeValues As RouteValueDictionary, countPerPage As Integer, totalCount As Integer)
            Me.Html = html
            Me.ActionName = routeValues("action")
            Me.ControllerName = routeValues("controller")
            Me.RouteValues = routeValues
            Me.CountPerPage = countPerPage
            Me.TotalCount = totalCount
        End Sub
        Public Property Html As HtmlHelper
        Public Property ActionName As String
        Public Property ControllerName As String
        Public Property RouteValues As RouteValueDictionary
        Public Property CountPerPage As Integer
        Public Property TotalCount As Integer

        Public ReadOnly Property CurrentPage As Integer
            Get
                Dim value = HttpContext.Current.Request.QueryString("page")
                If String.IsNullOrEmpty(value) OrElse Not IsNumeric(value) Then
                    Return 0
                Else
                    Return CInt(value)
                End If
            End Get
        End Property

        Public ReadOnly Property TotalPages As Integer
            Get
                Return Math.Ceiling(TotalCount / CountPerPage)
            End Get
        End Property

        Public ReadOnly Property EnableNext As Boolean
            Get
                Return (CurrentPage + 1) < TotalPages
            End Get
        End Property

        Public ReadOnly Property EnablePrevious As Boolean
            Get
                Return CurrentPage > 0
            End Get
        End Property

        Public Function GetPageLink(text As String, page As Integer, htmlAttributes As Dictionary(Of String, Object)) As IHtmlString
            If RouteValues.ContainsKey("page") Then
                RouteValues.Item("page") = page
            Else
                RouteValues.Add("page", page)
            End If

            Return Html.ActionLink(text, ActionName, ControllerName, RouteValues, htmlAttributes)
        End Function

        Public Function GetPageNumberLink(page As Integer) As IHtmlString
            Return GetPageLink((page + 1).ToString, page, Nothing)
        End Function

        Public Function GetPreviousLink() As IHtmlString
            Dim attributes As New Dictionary(Of String, Object)
            attributes.Add("aria-label", "Previous")
            Return GetPageLink("‹", CurrentPage - 1, attributes)
        End Function

        Public Function GetNextLink() As IHtmlString
            Dim attributes As New Dictionary(Of String, Object)
            attributes.Add("aria-label", "Next")
            Return GetPageLink("›", CurrentPage + 1, attributes)
        End Function

        Public Function GetFirstLink() As IHtmlString
            Dim attributes As New Dictionary(Of String, Object)
            attributes.Add("aria-label", "First")
            Return GetPageLink("«", 0, attributes)
        End Function

        Public Function GetLastLink() As IHtmlString
            Dim attributes As New Dictionary(Of String, Object)
            attributes.Add("aria-label", "Last")
            Return GetPageLink("»", TotalPages - 1, attributes)
        End Function

        Public Function GetPagerLIs() As IHtmlString
            Dim output As New StringBuilder

            If EnablePrevious Then
                output.Append("<li>")
                output.Append(GetFirstLink)
                output.Append("</li>")
                output.Append("<li>")
                output.Append(GetPreviousLink)
                output.Append("</li>")

                For count = CurrentPage - 5 To CurrentPage - 1
                    If count >= 0 Then
                        output.Append("<li>")
                        output.Append(GetPageNumberLink(count))
                        output.Append("</li>")
                    End If
                Next
            End If

            output.Append("<li class=""active"">")
            output.Append(GetPageNumberLink(CurrentPage))
            output.Append("</li>")

            If EnableNext Then
                For count = CurrentPage + 1 To CurrentPage + 5
                    If TotalPages > count Then
                        output.Append("<li>")
                        output.Append(GetPageNumberLink(count))
                        output.Append("</li>")
                    End If
                Next

                output.Append("<li>")
                output.Append(GetNextLink)
                output.Append("</li>")
                output.Append("<li>")
                output.Append(GetLastLink)
                output.Append("</li>")
            End If
            Return Html.Raw(output.ToString)
        End Function
    End Class
End Namespace

