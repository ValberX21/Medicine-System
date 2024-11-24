Imports System.ComponentModel.DataAnnotations

Public Class Medicine
    <Key>
    Public Property MedicineId As Integer

    Public Property Name As String

    Public Property GenericName As String

    Public Property Manufacturer As String

    Public Property ExpiryDate As DateTime

    Public Property Price As Decimal

    Public Property Dosage As String

    Public Property Form As String

    Public Property Description As String

    Public Property PrescriptionRequired As Boolean
End Class
