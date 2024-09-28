using AutoMapper;
using Azure;
using GoodAPI.Data;
using GoodAPI.Dto;
using GoodAPI.Erro;
using GoodAPI.Interfaces;
using GoodAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace GoodAPI.Repository
{
    public class Medicine : IMedicine
    {
        private readonly ApplicationDbContext _db;

        public Medicine(ApplicationDbContext db)
        {
            _db = db;
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
    }
}
