using DevStore.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Pedido.Domain
{
    public class PedidoItem : Entity
    {
        public Guid PedidoId { get; set; }
        public Guid ProdutoId { get; private set; }
        public int Quantidade { get; private set; }

        public Pedido Pedido { get; set; }

        protected PedidoItem() { }

        public PedidoItem(Guid produtoId, int quantidade)
        {
            ProdutoId = produtoId;
            Quantidade = quantidade;
        }
    }
}
