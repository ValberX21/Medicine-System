Public Class ApiResultMedicine
    Public Property isSuccess As Boolean
    Public Property result As List(Of Medicine)
    Public Property displayMessage As String
    Public Property errorMessage As String
    Public Property errorMessages As List(Of String)
End Class
