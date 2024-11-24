using System.ComponentModel.DataAnnotations;

namespace GoodAPI.Models
{
    public class Medicine
    {
        [Key]
        public int MedicineId { get; set; }          
        public string Name { get; set; }             
        public string GenericName { get; set; }      
        public string Manufacturer { get; set; }     
        public DateTime ExpiryDate { get; set; }    
        public decimal Price { get; set; }           
        public string Dosage { get; set; }           
        public string Form { get; set; }             
        public string Description { get; set; }      
        public bool PrescriptionRequired { get; set; }
    }
}
