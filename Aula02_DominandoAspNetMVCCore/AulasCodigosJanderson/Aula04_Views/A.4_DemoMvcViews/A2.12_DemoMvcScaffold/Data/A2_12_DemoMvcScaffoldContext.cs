using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using A2._12_DemoMvcScaffold.Models;

namespace A2._12_DemoMvcScaffold.Data
{
    public class A2_12_DemoMvcScaffoldContext : DbContext
    {
        public A2_12_DemoMvcScaffoldContext (DbContextOptions<A2_12_DemoMvcScaffoldContext> options)
            : base(options)
        {
        }

        public DbSet<A2._12_DemoMvcScaffold.Models.Filme>? Filme { get; set; }
    }
}
