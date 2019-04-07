using Microsoft.EntityFrameworkCore;

namespace MVA_Beginner
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {  }

        public DbSet<Customer> Customers { get; set; }
    }
}