using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Application.Models
{
    public record PedidoDto(int Id, string NomeCliente, string EmailCliente, bool Pago, decimal ValorTotal, List<PedidoItemDto> ItensPedido);

    public record PedidoItemDto(int Id, int ProdutoId, string NomeProduto, decimal ValorUnitario, int Quantidade);
}
