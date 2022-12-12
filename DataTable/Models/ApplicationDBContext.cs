using Microsoft.EntityFrameworkCore;

namespace DataTable.Models
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
