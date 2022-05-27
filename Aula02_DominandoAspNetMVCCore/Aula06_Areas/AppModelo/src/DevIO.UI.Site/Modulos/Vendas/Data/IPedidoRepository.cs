using DevIO.UI.Site.Models;

namespace DevIO.UI.Site.Modulos.Vendas.Data
{
    public interface IPedidoRepository
    {
        Pedido ObterPedido();
    }
}