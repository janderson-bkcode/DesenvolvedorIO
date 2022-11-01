using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Site.Models;

namespace UI.Site.Data
{
	public class MeuDbContext : DbContext
	{
		public MeuDbContext(DbContextOptions options)
		:base(options)
		{

		}

		public DbSet<Aluno> Alunos { get; set; }
	}
}
