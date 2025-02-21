using DevStore.Produtos.Domain.Entities;
using DevStore.Produtos.Infrastructure.Data.Context;
using DevStore.SharedKernel.Data;

namespace DevStore.Produtos.Infrastructure.Data.Repositories
{
    public class ProdutoRepository : Repository<Produto>
    {
        private readonly ProdutoContext _context;

        public override IUnitOfWork UnitOfWork => _context;

        public ProdutoRepository(ProdutoContext context) : base(context)
        {
            _context = context;
        }
    }
}
