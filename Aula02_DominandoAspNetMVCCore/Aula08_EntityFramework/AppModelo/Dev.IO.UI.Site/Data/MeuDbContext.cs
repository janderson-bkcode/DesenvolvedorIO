using Microsoft.EntityFrameworkCore;

namespace Dev.IO.UI.Site.Data
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options):base(options)
        {

        }

    }
}
