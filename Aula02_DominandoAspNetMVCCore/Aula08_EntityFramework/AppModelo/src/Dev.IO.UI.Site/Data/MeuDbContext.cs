using Dev.IO.UI.Site.Models;
using Microsoft.EntityFrameworkCore;

namespace Dev.IO.UI.Site.Data
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options):base(options)
        {

        }
        //Aula 08.04 CRUD  passo 2
        //Trazendo a model para o contexto do banco e que seja entendida como uma tabela para ser mapeada
        public DbSet<Aluno> Alunos { get; set; }
    }
}
