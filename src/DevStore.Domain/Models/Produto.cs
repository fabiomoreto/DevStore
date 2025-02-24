using DevStore.SharedKernel.Domain;

namespace DevStore.Domain.Models
{
    public class Produto : Entity, IAggregateRoot
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        private readonly List<PedidoItem> _itens = new();
        public IReadOnlyCollection<PedidoItem> Itens => _itens.AsReadOnly();

        protected Produto() { }

        public static Result<Produto> CriarProduto(string nome, decimal valor)
        {
            var produto = new Produto();

            var result = produto.SetarNome(nome);
            if (!result.IsSuccessful) return result.Error;

            result = produto.SetarValor(valor);
            if (!result.IsSuccessful) return result.Error;

            return produto;
        }

        public Result SetarNome(string nome)
        {
            if (string.IsNullOrEmpty(nome)) return new Error("Nome do produto não pode ser nulo ou vazio.");

            Nome = nome;

            return Result.Success();
        }

        public Result SetarValor(decimal valor)
        {
            if (valor < 0) return new Error("Valor não pode ser negativo.");

            Valor = valor;

            return Result.Success();
        }
    }
}
