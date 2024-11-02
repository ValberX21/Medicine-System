using Azure;
using GoodAPI.Data;
using GoodAPI.Data.Models;
using GoodAPI.Dto;
using GoodAPI.Erro;
using GoodAPI.Interfaces;
using GoodAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace GoodAPI.Repository
{
    public class Medicine : IMedicine
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;
        //protected ResponseDto _response;

        public Medicine(ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;           
        }

        public async Task<ResponseDto> LoginUser(User usu)
        {
            //string connectionString = _configuration.GetConnectionString("DefaultConnection");

            //string query = "SELECT * FROM Users WHERE FullName = @FullName";

            //string tk = "";

            //string encrypTk = "";

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        command.Parameters.AddWithValue("@FullName", usu.Name);

            //        await connection.OpenAsync();

            //        using (SqlDataReader reader = await command.ExecuteReaderAsync())
            //        {
            //            if (await reader.ReadAsync())  
            //            {
            //                User foundUser = new User
            //                {
            //                    UserId = reader["UserId"] != DBNull.Value ? Convert.ToInt32(reader["UserId"]) : 0,
            //                    Name = reader["FullName"]?.ToString(),
            //                    Password = reader["Password"] != DBNull.Value ? Encoding.UTF8.GetBytes(reader["Password"].ToString()) : null
            //                };

            //                tk = geraToken(foundUser);

            //                encrypTk = JWTEncrypt.EncryptToken(tk);

            //                _response.Result = "User found";
            //            }
            //            else
            //            {
            //                _response.Result = "User not found";
            //            }
            //        }
            //    }
            //}
            return null;
        }



        public async Task<IActionResult> CreateUpdateMedicine(Models.Medicine medicin)
        {
            try
            {
                if (medicin.MedicineId > 0)
                {
                    _db.Medicines.Update(medicin);
                    await _db.SaveChangesAsync();
                    return new StatusCodeResult((int)HttpStatusCode.OK);
                }
                else
                {
                    _db.Medicines.Add(medicin);
                    await _db.SaveChangesAsync();
                    return new StatusCodeResult((int)HttpStatusCode.Created);
                }                
            }
            catch (Exception ex)
            {
                ErroRegister erroRegister = new ErroRegister();

                var errorLog = new ErrorLog
                {
                    ErrorMessage = ex.Message,
                    ErrorSource = ex.Source,
                    StackTrace = ex.StackTrace,
                    InnerException = ex.InnerException?.Message,
                };

                erroRegister.register(errorLog);

                return new StatusCodeResult((int)HttpStatusCode.InternalServerError); 
            }
        }

        public async Task<bool> DeleteMedicine(int MedicineId)
        {
            Models.Medicine medicine = await _db.Medicines.FirstOrDefaultAsync(u => u.MedicineId == MedicineId);

            if (medicine == null)
            {
                return false;
            }
            else
            {
                _db.Medicines.Remove(medicine);
                await _db.SaveChangesAsync();
                return true;
            }           
        }

        public Task<Models.Medicine> GetMedicineById(int MedicineId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Models.Medicine>> GetMedicines()
        {
            List<Models.Medicine> resultQuery = new List<Models.Medicine>();

            try
            {
                resultQuery = await _db.Medicines.ToListAsync(); 
            }
            catch (Exception ex)
            {
                ErroRegister erroRegister = new ErroRegister();

                var errorLog = new ErrorLog
                {
                    ErrorMessage = ex.Message,
                    ErrorSource = ex.Source,
                    StackTrace = ex.StackTrace,
                    InnerException = ex.InnerException?.Message,
                };

                erroRegister.register(errorLog); 
            }

            return resultQuery; 
        }

        public string geraToken(User usu)
        {            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Secret").ToString());
            var tokenDescription = new SecurityTokenDescriptor();

            try
            {
                tokenDescription = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                            new Claim(ClaimTypes.Name,usu.Name,
                                      ClaimTypes.Hash,usu.Password.ToString()
                                        )
                    }),
                    Expires = DateTime.UtcNow.AddHours(24),
                    SigningCredentials =
                            new SigningCredentials(
                                new SymmetricSecurityKey(key),
                                SecurityAlgorithms.HmacSha256Signature)

                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            var finalToken = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(finalToken);
        }
    }
}
