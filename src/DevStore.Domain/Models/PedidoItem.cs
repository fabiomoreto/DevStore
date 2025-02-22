using DevStore.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Domain.Models
{
    public class PedidoItem : Entity
    {
        public int PedidoId { get; set; }
        public int ProdutoId { get; private set; }
        public int Quantidade { get; private set; }

        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }

        protected PedidoItem() { }

        public PedidoItem(int produtoId, int quantidade)
        {
            ProdutoId = produtoId;
            Quantidade = quantidade;
        }
    }
}
