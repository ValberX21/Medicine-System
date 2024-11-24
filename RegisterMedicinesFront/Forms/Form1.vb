Imports System.Text
Imports System.Configuration

Public Class Form1

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Dim userName, userPass As String

        If txtUserName.Text = "" Or txtPassword.Text = "" Then
            MessageBox.Show("Please complet the fields", "Invalid inputs", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else

            userName = txtUserName.Text
            userPass = txtPassword.Text

            processoLogin(userName, userPass)

        End If

    End Sub

    Sub processoLogin(name, pass)

        Dim convPass As Byte() = Encoding.UTF8.GetBytes(pass)

        Dim api As New MedicineAPI()

        Dim rt = api.PostApiData(name, convPass)

        Dim response As ApiResultLogin = api.ParseApiResponse(rt)

        GlobalVariables.AppSetting = response.result.encrypToken

        If response.isSuccess = True Then
            Dim frmRegisterMed As New FrmRegisterMedic()
            frmRegisterMed.Show()
            Me.Hide()
        Else
            MessageBox.Show("ERRO !", "Some problem in API (authentication)", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

End Class
