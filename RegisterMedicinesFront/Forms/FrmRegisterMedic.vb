Imports System.IO
Imports System.Text
Imports System.Text.Json
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports OfficeOpenXml

Public Class FrmRegisterMedic

    Dim accessToken = AppSetting

    Private Async Sub btnAddMedicine_Click(sender As Object, e As EventArgs) Handles btnAddMedicine.Click

        If txtName.Text Is "" Or txtGenericName.Text Is "" Or txtManufacture.Text Is "" Or txtExpiry.Text Is "" Or txtPrice.Text Is "" Or txtDosage.Text Is "" Or txtForm.Text Is "" Or checkPresRq.Text Is "" Or txtDescription.Text Is "" Then

            MessageBox.Show("Please complet the fields", "Invalid inputs", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Else

            Try

                Dim api As New MedicineAPI

                Dim id = txtMedicineId.Text
                Dim name = txtName.Text
                Dim genericName = txtGenericName.Text
                Dim manufacture = txtManufacture.Text
                Dim ExpiryDt = txtExpiry.Text
                Dim price = txtPrice.Text
                Dim dosage = txtDosage.Text
                Dim form = txtForm.Text
                Dim prescReque = checkPresRq.Checked
                Dim descrip = txtDescription.Text

                Dim data As New Medicine With {
                    .MedicineId = If(id = "", 0, id),
                    .Name = name,
                    .GenericName = genericName,
                    .Manufacturer = manufacture,
                    .ExpiryDate = ExpiryDt,
                    .Price = price,
                    .Dosage = dosage,
                    .Form = form,
                    .Description = descrip,
                    .PrescriptionRequired = prescReque
                }

                Dim response = Await api.saveMedicine(data, accessToken)

                Dim responseStatus = api.ParseApiResponse(response)

                If responseStatus.result.statusCode = 201 Then
                    clearFields()
                    MessageBox.Show("Success", "Medicine created !", MessageBoxButtons.OK)
                ElseIf responseStatus.result.statusCode = 200 Then
                    clearFields()
                    MessageBox.Show("Success", "Medicine updated !", MessageBoxButtons.OK)
                End If
            Catch ex As Exception
                MessageBox.Show("ERRO", ex.Message, MessageBoxButtons.OK)
            End Try

        End If
    End Sub

    Async Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        If TabControl1.SelectedTab Is TabPage2 Then

            Dim api As New MedicineAPI

            Dim medicines As List(Of Medicine) = Await api.GetAllMedicines(accessToken)

            dtGridMedicines.DataSource = medicines

            clearFields()

        ElseIf TabControl1.SelectedTab Is TabPage1 Then

        End If
    End Sub

    Sub clearFields()

        txtName.Text = ""
        txtGenericName.Text = ""
        txtManufacture.Text = ""
        txtExpiry.Text = ""
        txtPrice.Text = ""
        txtDosage.Text = ""
        txtForm.Text = ""
        checkPresRq.Checked = 0
        txtDescription.Text = ""

    End Sub

    Private Sub dtGridMedicines_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtGridMedicines.CellClick

        If e.RowIndex >= 0 Then

            Dim selectedRow As DataGridViewRow = dtGridMedicines.Rows(e.RowIndex)

            Dim id = Convert.ToInt32(selectedRow.Cells("MedicineId").Value)
            Dim name = selectedRow.Cells("Name").Value
            Dim genericName = selectedRow.Cells("GenericName").Value
            Dim manufacturer = selectedRow.Cells("Manufacturer").Value
            Dim expiryDate = selectedRow.Cells("ExpiryDate").Value
            Dim price = Convert.ToInt64(selectedRow.Cells("Price").Value)
            Dim dosage = selectedRow.Cells("Dosage").Value
            Dim form = selectedRow.Cells("Form").Value
            Dim description = selectedRow.Cells("Description").Value
            Dim prescript = selectedRow.Cells("PrescriptionRequired").Value

            Dim medicineSelect As New Medicine With {
                    .MedicineId = id,
                    .Name = name,
                    .GenericName = genericName,
                    .Manufacturer = manufacturer,
                    .ExpiryDate = expiryDate,
                    .Price = price,
                    .Dosage = dosage,
                    .Form = form,
                    .Description = description,
                    .PrescriptionRequired = prescript
                }

            txtMedicineId.Text = id
            txtName.Text = name
            txtGenericName.Text = genericName
            txtManufacture.Text = manufacturer
            txtExpiry.Text = expiryDate
            txtPrice.Text = price
            txtDosage.Text = dosage
            txtForm.Text = form
            checkPresRq.Checked = Convert.ToBoolean(prescript)
            txtDescription.Text = description

            TabControl1.SelectedTab = TabPage1

        End If
    End Sub

    Async Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

        Dim api As New MedicineAPI

        Dim medicines As List(Of Medicine) = Await api.GetAllMedicines(accessToken)

        Dim excelFilePath As String = "C:\Temp\Medicines.xlsx"

        ' Generate Excel
        GenerateExcelFromList(medicines, excelFilePath)

        Console.WriteLine("Excel file generated successfully!")
    End Sub

    Private Sub GenerateExcelFromList(medicines As List(Of Medicine), filePath As String)

        ExcelPackage.LicenseContext = LicenseContext.NonCommercial

        Using package As New ExcelPackage()
            Dim worksheet = package.Workbook.Worksheets.Add("Medicines")

            worksheet.Cells(1, 1).Value = "ID"
            worksheet.Cells(1, 2).Value = "Name"
            worksheet.Cells(1, 3).Value = "Description"
            worksheet.Cells(1, 4).Value = "Expiry Date"
            worksheet.Cells(1, 5).Value = "Price"

            Using headerRange = worksheet.Cells(1, 1, 1, 5)
                headerRange.Style.Font.Bold = True
                headerRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                headerRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray)
            End Using

            Dim rowIndex As Integer = 2
            For Each medicine In medicines
                worksheet.Cells(rowIndex, 1).Value = medicine.MedicineId
                worksheet.Cells(rowIndex, 2).Value = medicine.Name
                worksheet.Cells(rowIndex, 3).Value = medicine.Description
                worksheet.Cells(rowIndex, 4).Value = medicine.ExpiryDate.ToShortDateString()
                worksheet.Cells(rowIndex, 5).Value = medicine.Price
                rowIndex += 1
            Next

            worksheet.Cells.AutoFitColumns()

            package.SaveAs(New FileInfo(filePath))

            MessageBox.Show("File saved in directory 'C:\Temp' ")
        End Using
    End Sub

End Class