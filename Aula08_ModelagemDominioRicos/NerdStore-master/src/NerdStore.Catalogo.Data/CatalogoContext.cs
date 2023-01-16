using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.Domain;
using NerdStore.Core.Data;
using NerdStore.Core.Messages;

namespace NerdStore.Catalogo.Data
{
    public class CatalogoContext : DbContext, IUnitOfWork
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        
        public CatalogoContext(DbContextOptions<CatalogoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Baixar nugets => Install-Package Microsoft.EntityFrameworkCore.Design  e  Install-Package Microsoft.EntityFrameworkCore.SqlServer;

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string)))) // Para cada propriedade que seja do tipo  String será mapeado como Varchar(100) no Entity Framework para SQL
            {
                property.SetColumnType("varchar(100)");
            }

            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContext).Assembly); // Registrando todos e buscando os Mappings
        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null)) // Buscando todas as colunas e propriedades que possui o Nome "DataCadastro"
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now; // Se existe e está adicionando a Entidade , DataCadastro é igual a Data da operação
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false; // Caso seja mofidicação da entidade, ignorar qualquer dado do campo "DataCadastro", para não sobrescrever o valor com o DateTimeNow
                }
            }

            return await base.SaveChangesAsync() > 0;
        }
    }
}