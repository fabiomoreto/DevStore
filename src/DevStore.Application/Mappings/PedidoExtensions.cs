using DevStore.Application.Models;
using DevStore.Domain.Models;

namespace DevStore.Application.Mappings
{
    public static class PedidoExtensions
    {
        public static PedidoDto ToPedidoDto(this Pedido pedido)
        {
            return new PedidoDto(
                pedido.Id,
                pedido.NomeCliente,
                pedido.EmailCliente.Endereco,
                pedido.Pago,
                pedido.Itens.Sum(x => x.Produto.Valor),
                pedido.Itens.Select(i => new PedidoItemDto(
                    i.Id,
                    i.ProdutoId,
                    i.Produto.Nome,
                    i.Produto.Valor,
                    i.Quantidade
                )).ToList()
            );
        }
    }
}
