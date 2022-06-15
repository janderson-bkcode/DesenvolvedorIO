using Microsoft.EntityFrameworkCore;
using MinhaPrimeiraAPI2.Models;

namespace MinhaPrimeiraAPI2.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Fornecedor> Fornecedores { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
