using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace NerdStore.Vendas.Domain.Tests
{
    public class Pedido

    {
        public Pedido()
        {
            _pedidoItens = new List<PedidoItem>();
        }
        public decimal ValorTotal { get; private set; }
        // public Collection<PedidoItem> pedidoItems { get; private set; }

        private readonly List<PedidoItem> _pedidoItens;

        public IReadOnlyCollection<PedidoItem> PedidoItem => _pedidoItens;
        public void AdicionarItem(PedidoItem pedidoItem)
        {
            _pedidoItens.Add(pedidoItem);
            ValorTotal = _pedidoItens.Sum(i => i.Quantidade * i.ValorUnitario);
        }
    }
    public class PedidoItem
    {
        public PedidoItem(Guid produtoId, string produtoNome, int quantidade, decimal valorUnitario)
        {
            ProdutoId = produtoId;
            ProdutoNome = produtoNome;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        public Guid  ProdutoId { get; private set; }

        public string ProdutoNome { get; private set; }

        public int Quantidade { get; private set; }

        public decimal ValorUnitario { get; private set; }

        

    }

}
