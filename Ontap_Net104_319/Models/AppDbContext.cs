using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Ontap_Net104_319.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(){} // constructor ko tham số của nó
        public AppDbContext(DbContextOptions options) : base(options) // constructor kế thừa
        {
        }
        public DbSet<Account> Accounts { get; set; } // Đại diện cho 1 bảng trong CSDL

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SHANGHAIK;Initial Catalog=Ontap319;Integrated Security=True; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
