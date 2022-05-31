﻿using Dev.IO.UI.Site.Data;
using Dev.IO.UI.Site.Models;
using Microsoft.AspNetCore.Mvc;

//Aula 08.04 CRUD passo 3
namespace Dev.IO.UI.Site.Controllers
{
    public class TesteCrudController : Controller
    {

        private readonly MeuDbContext _contexto;

        public TesteCrudController(MeuDbContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {

            var aluno = new Aluno
            {
                Nome = "Eduardo",
                DataNascimento = DateTime.Now,
                Email = "eduardo@eduardopires.net.br"
            };
            _contexto.Alunos.Add(aluno);

            //Salvar  o aluno banco
            _contexto.SaveChanges();

            //Recuperar dados pelo id
            var aluno2 = _contexto.Alunos.Find(aluno.Id);

            //Recuperar dados pelo email
            var aluno3 = _contexto.Alunos.FirstOrDefault(a => a.Email == "eduardo@eduardopires.net.br");

            //Recuperando uma coleção de alunos em que todos tem o nome Eduardo, todos alunos com este nome
            var aluno4 = _contexto.Alunos.Where(a => a.Nome == "Eduardo");

            //Atualizando nome
            aluno.Nome = "Joao";
            _contexto.Alunos.Update(aluno);
            _contexto.SaveChanges();


            //Excluindo
            _contexto.Alunos.Remove(aluno);


            return View();
        }
    }
}
