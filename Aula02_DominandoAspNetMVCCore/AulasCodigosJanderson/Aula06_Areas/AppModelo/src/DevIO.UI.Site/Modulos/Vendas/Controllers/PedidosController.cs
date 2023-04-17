 using DevIO.UI.Site.Modulos.Vendas.Data;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.UI.Site.Areas.Vendas.Controllers
{
    [Area("Vendas")]
    public class PedidosController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidosController(IPedidoRepository pedidoRepository)
        {
            this._pedidoRepository = pedidoRepository;
        }

        public IActionResult Index()
        {
            var pedido = _pedidoRepository.ObterPedido();
            return View();
        }
        public IActionResult Teste()
        {
            return View();
        }
        //No caso em que não consegue injetar direto  num construtor em sitema legado
        //existe uma alternativa não recomendada para fazer injeção dependencia
        //direto método baixo

        public IActionResult Teste3([FromServices] IPedidoRepository pedidoRepository1)
        {
            var pedido = _pedidoRepository.ObterPedido();
            return View();
        }


    }
}
