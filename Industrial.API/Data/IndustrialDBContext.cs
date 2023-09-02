using Industrial.API.Entity;
using Microsoft.EntityFrameworkCore;

namespace Industrial.API.Data
{
    public class IndustrialDBContext : DbContext
    {
        public IndustrialDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
