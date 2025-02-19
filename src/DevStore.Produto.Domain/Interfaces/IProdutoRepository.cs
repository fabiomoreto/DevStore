using DevStore.Produtos.Domain.Entities;
using DevStore.SharedKernel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Produtos.Domain.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> GetAll();
        Task<Produto> GetById(int id);
        void Add(Produto produto);
        void Update(Produto produto);
        void Delete(Produto produto);
    }
}
