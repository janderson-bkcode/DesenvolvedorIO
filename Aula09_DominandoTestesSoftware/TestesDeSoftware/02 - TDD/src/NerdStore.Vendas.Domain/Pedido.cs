using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Vendas.Domain.Tests
{
    public class Pedido


    {
        public decimal ValorTotal { get; set; }
        public void AdicionarItem(PedidoItem pedidoItem)
        {
            
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

        public Guid  ProdutoId { get; set; }

        public string ProdutoNome { get; set; }

        public int Quantidade { get; set; }

        public decimal ValorUnitario { get; set; }

        

    }

}
