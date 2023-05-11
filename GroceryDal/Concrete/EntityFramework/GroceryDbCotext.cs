using Microsoft.EntityFrameworkCore;

namespace GroceryDal.Concrete.EntityFramework
{
    public class GroceryDbCotext : DbContext
    {
        //public GroceryDbCotext(DbContextOptions<GroceryDbCotext> options) : base(options)
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=GroceryDB;Trusted_Connection=true;TrustServerCertificate=True");
        }

        public DbSet<GroceryItem> GroceryItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}