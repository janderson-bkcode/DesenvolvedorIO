using DevIO.UI.Site.Modulos.Vendas.Models;

namespace DevIO.UI.Site.Modulos.Vendas.Data
{
    public interface IPedidoRepository
    {
        Pedido ObterPedido();
    }
}