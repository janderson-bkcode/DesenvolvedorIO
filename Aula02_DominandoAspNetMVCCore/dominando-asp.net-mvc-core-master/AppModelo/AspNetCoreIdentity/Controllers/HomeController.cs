using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNetCoreIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using AspNetCoreIdentity.Extensions;

namespace AspNetCoreIdentity.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}

		//[Authorize]
		public IActionResult Privacy()
		{
			throw new Exception("Erro");
			return View();
		}

		[Authorize(Roles = "Admin, Gestor")]
		public IActionResult Secret()
		{
			return View();
		}

		[Authorize(Policy = "PodeExcluir")]
		public IActionResult SecretClaim()
		{
			return View("Secret");
		}

		[Authorize(Policy = "PodeEscrever")]
		public IActionResult SecretClaimGravar()
		{
			return View("Secret");
		}


		[ClaimsAuthorize("Produtos", "Ler")]
		public IActionResult ClaimCustom()
		{
			return View("Secret");
		}

		//[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		[Route("erro/[id:length(3,3)]")]
		public IActionResult Error(int id)
		{
			//return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

			var modelErro = new ErrorViewModel() { ErrorCode = id };

			if (id == 500)
			{
				modelErro.Mensagem = "Ocorreu um erro ! Tente novamente mais tarde ou contate nosso suporte.";
				modelErro.Titulo = "Ocorreu um erro!";
			}
			else if (id == 404)
			{
				modelErro.Mensagem = "A página que está procurando não existe <br />Em caso de dúvidas entre em contato com nosso suporte";
				modelErro.Titulo = "Opa! Página não encontrada.";
			}
			else if (id == 403)
			{
				modelErro.Mensagem = "Você não tem permissão para fazer isso.";
				modelErro.Titulo = "Acesso negado";
			}
			else
			{
				return StatusCode(404);
			}
			return View("Error", modelErro);
		}
	}
}
