using Microsoft.EntityFrameworkCore;


namespace MinhaPrimeiraAPI.Model
{
    public class APIDbContext :DbContext


    {

        
        public APIDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Fornecedor> Fornecedores { get; set; }

        //Em vez de fazer na Program/Startup , esse override configura tambem para fazer a Migration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("MeuDbContext");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
