using GoodAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace GoodAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }

    }
}
