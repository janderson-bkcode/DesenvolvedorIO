using System;

namespace NerdStore.Vendas.Domain
{
    public class Roteiro
    {
        /*DESENVOLVIMENTO DO DOMINIO DE VENDAS*/

        /*PEDIDO  - ITEM PEDIDO = VOUCHER*/

        /*
            Um item de um pedido representa um produto e pode conter mais de uma unidade
            Independente da ação , um item precisa ser sempre valido:
            Possuir: Id e Nome do produto, quantidade entre 1 e 15 unidades , valor maior que 0

            Um pedido enquanto não iniciado(processo de pagamento) está no estado de rascunho
            e deve pertencer a um cliente.

            1 - Adicionar Item
                1.1 - Ao adicionar um item é necessário calcular o valor total do pedido
                1.2 - Se um item já está na lista então deve acrescer a quantidade do item no pedido
                1.3 -  O item deve ter entre 1 e 15 unidades do produto 

            2 - Atualização do Item
                2.1 - O item precisa estar na lista para ser atualizado
                2.2 Um item pode ser atualizado contendo mais ou menos unidades do que anteriormente
                2.3  - Ao atualizar um item é necessário calcular o valor total do pedido
                2.4 - Um item deve permanecer entre 1 e 15 unidades do produto

            3 - Remoção de Item
                3.1 - O item precisa estar na lista para ser removido
                3.2 - Ao remover um item é necessário calcular o valor total do pedido 

            Um voucher possui um código unico e o desconto pode ser em percentual ou valor fixo
            usar uma flag indicando que um pedido teve um voucjer de desconto aplicado e o valor do desconto gerado
         
            4 - Aplicar voucjer de desconto

            4.1 - O voucher só pode ser aplicado se estiver valido, para isto:
                4.1.1 - Deve possuir um código
                4.1.2 - A data de validade é superior a data atual
                4.1.3 - O voucher está ativo
                4.1.4 - O voucher possui quantidade disponivel
                4.1.5 - Uma das formas de desconto deve estar preenchidas com valor acima de 0
            4.2 - Calcular o desconto conforme tipo do voucher
                4.2.1 - Voucher com desconto percentual
                4.2.2 - Voucher com desconto em valores(reais)
            4.3 - Quando o valor do desconto ultrapassa o total do pedido o pedido recebe o valor :0
            4.4.- Após a aplicação do voucher o desconto deve ser re-calculado após toda mofificação da lista de itens do pedido
        
         
         
         */

        /*PEDIDO DOMMANDS - HANDLER*/
    }
}
