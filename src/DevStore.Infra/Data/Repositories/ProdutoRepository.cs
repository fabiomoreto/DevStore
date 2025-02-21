using DevStore.Domain.Models;
using DevStore.Infra.Data.Context;
using DevStore.SharedKernel.Data;

namespace DevStore.Infra.Data.Repositories
{
    public class ProdutoRepository : Repository<Produto>
    {
        private readonly AppDbContext _context;

        public override IUnitOfWork UnitOfWork => _context;

        public ProdutoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
