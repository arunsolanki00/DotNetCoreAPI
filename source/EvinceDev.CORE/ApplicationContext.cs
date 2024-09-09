using EvinceDev.Entity;
using Microsoft.EntityFrameworkCore;

namespace EvinceDev.Entity
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) :base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localDB)\local;Database=EvinceDevTestDB;Trusted_Connection=True;TrustServerCertificate=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Employee> Employees { get; set; }

    }
}
