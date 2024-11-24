Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports System.Text.Json
Imports System.Text.Json.Serialization
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class MedicineAPI
    Public Function PostApiData(userName As String, pass As Byte()) As String

        Try
            Using client As New HttpClient()
                Dim url As String = "https://localhost:44311/api/medicines/authentic"

                Dim data As New With {
                    .Name = userName,
                    .Password = pass
                }

                Dim json As String = System.Text.Json.JsonSerializer.Serialize(data)
                Dim content As New StringContent(json, Encoding.UTF8, "application/json")

                Dim response As HttpResponseMessage = client.PostAsync(url, content).Result

                If response.IsSuccessStatusCode Then
                    Dim responseBody As String = response.Content.ReadAsStringAsync().Result
                    Return responseBody
                Else
                    Return $"Error: {response.StatusCode}"
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Wrong !", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Async Function saveMedicine(data As Object, token As String) As Task(Of String)

        Try
            Using client As New HttpClient()
                Dim url As String = "https://localhost:44311/api/medicines/addUpdateMedicine"

                Dim descpTokenClass As New DecryoJWToken()

                Dim descrpToken = descpTokenClass.DecrypToken(token)

                client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", descrpToken)

                Dim json As String = System.Text.Json.JsonSerializer.Serialize(data)
                Dim content As New StringContent(json, Encoding.UTF8, "application/json")

                Dim response As HttpResponseMessage = client.PostAsync(url, content).Result

                If response.IsSuccessStatusCode Then
                    Return response.Content.ReadAsStringAsync().Result
                Else
                    Return $"Error: {response.StatusCode}"
                End If
            End Using
        Catch ex As Exception
            Return $"Error: {ex.Message}"
        End Try
    End Function


    Public Function ParseApiResponse(json As String) As ApiResultLogin

        Dim apiResponse As ApiResultLogin

        Try
            apiResponse = System.Text.Json.JsonSerializer.Deserialize(Of ApiResultLogin)(json)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            apiResponse.displayMessage = ex.Message
        End Try

        Return apiResponse
    End Function

    Async Function GetAllMedicines(accessToken As String) As Task(Of List(Of Medicine))

        Try
            Using client As New HttpClient()

                Dim listMedicines = New List(Of Medicine)()
                Dim descpTokenClass As New DecryoJWToken()
                Dim descrpToken = descpTokenClass.DecrypToken(accessToken)

                client.DefaultRequestHeaders.Authorization = New Headers.AuthenticationHeaderValue("Bearer", descrpToken)

                Dim url As String = "https://localhost:44311/api/medicines/getAllMedicines"

                Dim response As HttpResponseMessage = Await client.GetAsync(url)

                Dim responseBody As String = response.Content.ReadAsStringAsync().Result

                Dim result As JObject = JObject.Parse(responseBody)
                Dim medicines As List(Of Medicine) = JsonConvert.DeserializeObject(Of List(Of Medicine))(result("result").ToString())

                For Each medicine In medicines
                    listMedicines.Add(medicine)
                Next

                Return listMedicines
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return New List(Of Medicine)()
        End Try
    End Function
End Class
