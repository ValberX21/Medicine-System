using System.ComponentModel.DataAnnotations;

namespace GoodAPI.Models
{
    public class Medicine
    {
        [Key]
        public int MedicineId { get; set; }          // Unique identifier for each medicine
        public string Name { get; set; }             // Medicine name
        public string GenericName { get; set; }      // Generic name of the medicine
        public string Manufacturer { get; set; }     // Company manufacturing the medicine
        public DateTime ExpiryDate { get; set; }     // Expiration date
        public decimal Price { get; set; }           // Price of the medicine
        public string Dosage { get; set; }           // Dosage information
        public string Form { get; set; }             // Form of the medicine (tablet, syrup, etc.)
        public string Description { get; set; }      // Additional information or description
        public bool PrescriptionRequired { get; set; }
    }
}
