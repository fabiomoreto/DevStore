using DevStore.Domain.ValueObjects;
using DevStore.SharedKernel.Domain;

namespace DevStore.Domain.Models
{
    public class Pedido : Entity, IAggregateRoot
    {
        public string NomeCliente { get; private set; }
        public string EmailCliente { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public bool Pago { get; private set; }

        private readonly List<PedidoItem> _itens = new();
        public IReadOnlyCollection<PedidoItem> Itens => _itens.AsReadOnly();

        protected Pedido() { }

        public Pedido(string nomeCliente, string emailCliente)
        {
            NomeCliente = nomeCliente;
            EmailCliente = emailCliente;
            DataCriacao = DateTime.UtcNow;
            Pago = false;
        }

        public void AdicionarItem(PedidoItem item)
        {
            _itens.Add(item);
        }

        public void RemoverItem(PedidoItem item)
        {
            _itens.Remove(item);
        }

        public int ObterValorTotal()
        {
            throw new NotImplementedException();
        }

        public void ConfirmarPagamento()
        {
            Pago = true;
        }
    }
}
