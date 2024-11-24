<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegisterMedic
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRegisterMedic))
        GroupBox1 = New GroupBox()
        txtMedicineId = New TextBox()
        checkPresRq = New CheckBox()
        btnAddMedicine = New Button()
        PictureBox1 = New PictureBox()
        txtDescription = New TextBox()
        txtForm = New TextBox()
        txtDosage = New TextBox()
        txtPrice = New TextBox()
        txtExpiry = New TextBox()
        txtManufacture = New TextBox()
        txtGenericName = New TextBox()
        txtName = New TextBox()
        Label8 = New Label()
        Label7 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        TabControl1 = New TabControl()
        TabPage1 = New TabPage()
        TabPage2 = New TabPage()
        Label9 = New Label()
        PictureBox2 = New PictureBox()
        dtGridMedicines = New DataGridView()
        GroupBox1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        TabControl1.SuspendLayout()
        TabPage1.SuspendLayout()
        TabPage2.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(dtGridMedicines, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(txtMedicineId)
        GroupBox1.Controls.Add(checkPresRq)
        GroupBox1.Controls.Add(btnAddMedicine)
        GroupBox1.Controls.Add(PictureBox1)
        GroupBox1.Controls.Add(txtDescription)
        GroupBox1.Controls.Add(txtForm)
        GroupBox1.Controls.Add(txtDosage)
        GroupBox1.Controls.Add(txtPrice)
        GroupBox1.Controls.Add(txtExpiry)
        GroupBox1.Controls.Add(txtManufacture)
        GroupBox1.Controls.Add(txtGenericName)
        GroupBox1.Controls.Add(txtName)
        GroupBox1.Controls.Add(Label8)
        GroupBox1.Controls.Add(Label7)
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Location = New Point(6, 5)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(715, 501)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Register Medicines"
        ' 
        ' txtMedicineId
        ' 
        txtMedicineId.Location = New Point(7, 40)
        txtMedicineId.Name = "txtMedicineId"
        txtMedicineId.Size = New Size(22, 27)
        txtMedicineId.TabIndex = 21
        txtMedicineId.Visible = False
        ' 
        ' checkPresRq
        ' 
        checkPresRq.AutoSize = True
        checkPresRq.Location = New Point(131, 311)
        checkPresRq.Name = "checkPresRq"
        checkPresRq.RightToLeft = RightToLeft.Yes
        checkPresRq.Size = New Size(173, 24)
        checkPresRq.TabIndex = 20
        checkPresRq.Text = "Prescription Required"
        checkPresRq.TextAlign = ContentAlignment.MiddleCenter
        checkPresRq.UseVisualStyleBackColor = True
        ' 
        ' btnAddMedicine
        ' 
        btnAddMedicine.Location = New Point(355, 375)
        btnAddMedicine.Name = "btnAddMedicine"
        btnAddMedicine.Size = New Size(345, 49)
        btnAddMedicine.TabIndex = 19
        btnAddMedicine.Text = "Add Medicine"
        btnAddMedicine.UseVisualStyleBackColor = True
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(355, 41)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(345, 323)
        PictureBox1.TabIndex = 18
        PictureBox1.TabStop = False
        ' 
        ' txtDescription
        ' 
        txtDescription.Location = New Point(27, 375)
        txtDescription.Multiline = True
        txtDescription.Name = "txtDescription"
        txtDescription.Size = New Size(322, 116)
        txtDescription.TabIndex = 16
        ' 
        ' txtForm
        ' 
        txtForm.Location = New Point(131, 265)
        txtForm.Name = "txtForm"
        txtForm.Size = New Size(174, 27)
        txtForm.TabIndex = 15
        ' 
        ' txtDosage
        ' 
        txtDosage.Location = New Point(131, 229)
        txtDosage.Name = "txtDosage"
        txtDosage.Size = New Size(174, 27)
        txtDosage.TabIndex = 14
        ' 
        ' txtPrice
        ' 
        txtPrice.Location = New Point(131, 187)
        txtPrice.Name = "txtPrice"
        txtPrice.Size = New Size(174, 27)
        txtPrice.TabIndex = 13
        ' 
        ' txtExpiry
        ' 
        txtExpiry.Location = New Point(131, 155)
        txtExpiry.Name = "txtExpiry"
        txtExpiry.Size = New Size(174, 27)
        txtExpiry.TabIndex = 12
        ' 
        ' txtManufacture
        ' 
        txtManufacture.Location = New Point(131, 117)
        txtManufacture.Name = "txtManufacture"
        txtManufacture.Size = New Size(174, 27)
        txtManufacture.TabIndex = 11
        ' 
        ' txtGenericName
        ' 
        txtGenericName.Location = New Point(131, 79)
        txtGenericName.Name = "txtGenericName"
        txtGenericName.Size = New Size(174, 27)
        txtGenericName.TabIndex = 10
        ' 
        ' txtName
        ' 
        txtName.Location = New Point(131, 41)
        txtName.Name = "txtName"
        txtName.Size = New Size(174, 27)
        txtName.TabIndex = 9
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(27, 343)
        Label8.Name = "Label8"
        Label8.Size = New Size(85, 20)
        Label8.TabIndex = 7
        Label8.Text = "Description"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(86, 268)
        Label7.Name = "Label7"
        Label7.Size = New Size(43, 20)
        Label7.TabIndex = 6
        Label7.Text = "Form"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(69, 228)
        Label6.Name = "Label6"
        Label6.Size = New Size(60, 20)
        Label6.TabIndex = 5
        Label6.Text = "Dosage"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(86, 187)
        Label5.Name = "Label5"
        Label5.Size = New Size(41, 20)
        Label5.TabIndex = 4
        Label5.Text = "Price"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(46, 153)
        Label4.Name = "Label4"
        Label4.Size = New Size(81, 20)
        Label4.TabIndex = 3
        Label4.Text = "ExpiryDate"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(30, 117)
        Label3.Name = "Label3"
        Label3.Size = New Size(97, 20)
        Label3.TabIndex = 2
        Label3.Text = "Manufacturer"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(24, 75)
        Label2.Name = "Label2"
        Label2.Size = New Size(103, 20)
        Label2.TabIndex = 1
        Label2.Text = "Generic Name"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(78, 44)
        Label1.Name = "Label1"
        Label1.Size = New Size(49, 20)
        Label1.TabIndex = 0
        Label1.Text = "Name"
        Label1.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Controls.Add(TabPage2)
        TabControl1.Location = New Point(11, 12)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(735, 536)
        TabControl1.TabIndex = 3
        ' 
        ' TabPage1
        ' 
        TabPage1.Controls.Add(GroupBox1)
        TabPage1.Location = New Point(4, 29)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3, 3, 3, 3)
        TabPage1.Size = New Size(727, 503)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Register"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' TabPage2
        ' 
        TabPage2.Controls.Add(Label9)
        TabPage2.Controls.Add(PictureBox2)
        TabPage2.Controls.Add(dtGridMedicines)
        TabPage2.Location = New Point(4, 29)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3, 3, 3, 3)
        TabPage2.Size = New Size(727, 503)
        TabPage2.TabIndex = 1
        TabPage2.Text = "List Medicines"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label9.Location = New Point(24, 461)
        Label9.Name = "Label9"
        Label9.Size = New Size(139, 28)
        Label9.TabIndex = 3
        Label9.Text = "Generate Excel"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(50, 391)
        PictureBox2.Margin = New Padding(3, 4, 3, 4)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(72, 67)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 2
        PictureBox2.TabStop = False
        ' 
        ' dtGridMedicines
        ' 
        dtGridMedicines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dtGridMedicines.Location = New Point(6, 5)
        dtGridMedicines.Name = "dtGridMedicines"
        dtGridMedicines.ReadOnly = True
        dtGridMedicines.RowHeadersWidth = 51
        dtGridMedicines.RowTemplate.Height = 29
        dtGridMedicines.Size = New Size(715, 367)
        dtGridMedicines.TabIndex = 1
        ' 
        ' FrmRegisterMedic
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(759, 560)
        Controls.Add(TabControl1)
        Name = "FrmRegisterMedic"
        Text = "FrmRegisterMedic"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        TabControl1.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        TabPage2.ResumeLayout(False)
        TabPage2.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(dtGridMedicines, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents txtForm As TextBox
    Friend WithEvents txtDosage As TextBox
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents txtExpiry As TextBox
    Friend WithEvents txtManufacture As TextBox
    Friend WithEvents txtGenericName As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnAddMedicine As Button
    Friend WithEvents checkPresRq As CheckBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents dtGridMedicines As DataGridView
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents txtMedicineId As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents PictureBox2 As PictureBox
End Class
