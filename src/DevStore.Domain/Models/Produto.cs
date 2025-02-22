using DevStore.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Domain.Models
{
    public class Produto : Entity, IAggregateRoot
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        private readonly List<PedidoItem> _itens = new();
        public IReadOnlyCollection<PedidoItem> Itens => _itens.AsReadOnly();

        protected Produto() { }

        public Produto(string nome, decimal valor)
        {
            Nome = nome;
            Valor = valor;
        }
    }
}
