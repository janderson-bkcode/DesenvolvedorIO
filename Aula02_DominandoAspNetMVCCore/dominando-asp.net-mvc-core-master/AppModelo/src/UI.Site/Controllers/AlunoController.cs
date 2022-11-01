using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UI.Site.Data;
using UI.Site.Models;

namespace UI.Site.Controllers
{
    public class AlunoController : Controller
    {
		private readonly MeuDbContext _contexto;
		public AlunoController(MeuDbContext contexto)
		{
			_contexto = contexto;
		}

        public IActionResult Index()
        {
			var aluno = new Aluno() { 
				Nome = "Phillipe",
				DataNascimento = DateTime.Now,
				Email = "phillrog@hotmail.com"
			};

			_contexto.Alunos.Add(aluno);
			_contexto.SaveChanges();

			var aluno2 = _contexto.Alunos.Find(aluno.Id);
			var aluno3 = _contexto.Alunos.FirstOrDefault( a => a.Email ==  aluno.Email);
			var aluno4 = _contexto.Alunos.Where(a => a.Nome == "Phillipe").ToList();

			aluno.Nome = "True Fonseca";
			_contexto.Alunos.Update(aluno);
			_contexto.SaveChanges();

			_contexto.Alunos.Remove(aluno);
			_contexto.SaveChanges();


			return View();
        }
    }
}