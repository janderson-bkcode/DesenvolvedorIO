using ExcelFormLuiza.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcelFormLuiza.Data
{
    public class DataContext
    {
        public class myDataContext : DbContext
        {
            public myDataContext(DbContextOptions<myDataContext> options) : base(options)
            {
            }

            public DbSet<User> users { get; set; }
        }
    }
}
