using UI.Site.Models;

namespace UI.Site.Data
{
	public class PedidoRepository : IPedidoRespository
	{
		public Pedido ObeterPedido()
		{
			return new Pedido();
		}
	}
}
