using DevStore.Produtos.Domain.Entities;
using DevStore.Produtos.Domain.Interfaces;
using DevStore.Produtos.Infrastructure.Data.Context;
using DevStore.SharedKernel.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Produtos.Infrastructure.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutoContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public ProdutoRepository(ProdutoContext context)
        {
            _context = context;
        }

        public async Task<Produto> GetById(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _context.Produtos.ToListAsync();
        }

        public void Add(Produto produto)
        {
            _context.Produtos.Add(produto);
        }

        public void Update(Produto produto)
        {
            _context.Produtos.Update(produto);
        }

        public void Delete(Produto produto)
        {
            _context.Produtos.Remove(produto);
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
