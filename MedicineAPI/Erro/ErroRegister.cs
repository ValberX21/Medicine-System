using GoodAPI.Data;
using GoodAPI.Models;
using Microsoft.Data.SqlClient;
using System.Text;

namespace GoodAPI.Erro
{
    public  class ErroRegister
    {
        private string connectionString = "Data Source=DESKTOP-ULLM2GO\\SQLEXPRESS;Initial Catalog=DbHospitalAM;Trusted_Connection=True;TrustServerCertificate=True;User Id=issac;password=Wolverine19";
        public ErroRegister()
        {
        }

        public  void register(ErrorLog erro)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO ErrorLogs (ErrorMessage, InnerException, ErrorSource, StackTrace,ErrorDateTime) ");
            sb.Append("VALUES (");
            sb.Append($"'{erro.ErrorMessage}', ");
            sb.Append($"'{erro.InnerException.Replace('\'',' ')}', ");
            sb.Append($"'{erro.ErrorSource}', ");
            sb.Append($"'{erro.StackTrace}', ");
            sb.Append($"'{erro.ErrorDateTime}' ");
            sb.Append(");");

            string query = sb.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Customer inserted successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error inserting customer: " + ex.Message);
                }
            }
        }
    }
}
