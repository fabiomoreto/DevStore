using DevStore.Application.Models;
using DevStore.Domain.Models;

namespace DevStore.Application.ModelMappings
{
    public static class ModelMappings
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

        public static ProdutoDto ToProdutoDto(this Produto produto) => new ProdutoDto(produto.Id, produto.Nome, produto.Valor);
    }
}
