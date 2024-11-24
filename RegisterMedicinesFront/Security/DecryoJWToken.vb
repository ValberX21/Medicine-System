Imports System.Security.Cryptography
Imports System.Text

Public Class DecryoJWToken

    Function DecrypToken(tk As String) As String

        Dim SecretKey = GlobalVariables.SecretyKey

        Try
            Dim parts = tk.Split(":"c)
            If parts.Length <> 2 Then
                Throw New ArgumentException("Invalid token format")
            End If

            Dim iv = Convert.FromBase64String(parts(0))
            Dim encryptedData = Convert.FromBase64String(parts(1))

            Using aesr = Aes.Create()
                aesr.Key = Encoding.UTF8.GetBytes(SecretKey)
                aesr.IV = iv

                Dim decryptor = aesr.CreateDecryptor(aesr.Key, aesr.IV)
                Dim decryptedBytes = decryptor.TransformFinalBlock(encryptedData, 0, encryptedData.Length)

                Return Encoding.UTF8.GetString(decryptedBytes)
            End Using
        Catch ex As Exception
            Throw New InvalidOperationException("Decryption failed", ex)
        End Try
    End Function
End Class
