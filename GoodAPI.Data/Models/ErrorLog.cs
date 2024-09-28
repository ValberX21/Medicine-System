using System.ComponentModel.DataAnnotations;

namespace GoodAPI.Models
{
    public class ErrorLog
    {
        [Key]
        public int ErrorId { get; set; }  // Primary key

        [Required]
        public string ErrorMessage { get; set; }  // Error message

        public string ErrorSource { get; set; }  // Source of the error (e.g., class or method)

        public string StackTrace { get; set; }  // Stack trace of the error

        [Required]
        public DateTime ErrorDateTime { get; set; } = DateTime.Now;  // Error occurrence time

        public string InnerException { get; set; }  // Inner exception details, if applicable
    }
}
