using DevStore.SharedKernel.Domain;

namespace DevStore.Pedido.Domain
{
    public class Pedido : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public Email EmailCliente { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public bool Pago { get; private set; }

        private readonly List<PedidoItem> _itens = new();
        public IReadOnlyCollection<PedidoItem> Itens => _itens.AsReadOnly();

        public Pedido(string nomeCliente, string emailCliente)
        {
            Nome = nomeCliente;
            EmailCliente = new Email(emailCliente);
            DataCriacao = DateTime.UtcNow;
            Pago = false;
        }

        public void AdicionarItem(Guid produtoId, int quantidade)
        {
            var item = new PedidoItem(produtoId, quantidade);
            _itens.Add(item);
        }

        public void ConfirmarPagamento()
        {
            Pago = true;
        }
    }
}
