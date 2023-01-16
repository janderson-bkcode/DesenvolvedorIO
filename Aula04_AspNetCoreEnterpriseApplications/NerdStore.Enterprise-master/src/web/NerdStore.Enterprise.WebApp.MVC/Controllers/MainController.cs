﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Enterprise.Core.Communication;

namespace NerdStore.Enterprise.WebApp.MVC.Controllers
{
    public class MainController : Controller
    {
        protected bool ResponsePossuiErros(ResponseResult response)
        {
            if (response != null && response.Errors.Mensagens.Any())
            {
                foreach (var mensagem in response.Errors.Mensagens)
                    ModelState.AddModelError(string.Empty, mensagem);

                return true;
            }

            return false;
        }

        protected void AdicionarErroValidacao(string mensagem)
        {
            ModelState.AddModelError(string.Empty, mensagem);
        }

        protected bool OperacaoValida() => ModelState.ErrorCount == 0;
    }
}