using DevStore.Domain.Models;
using DevStore.Infra.Data.Context;
using DevStore.SharedKernel.Data;
using Microsoft.EntityFrameworkCore;

namespace DevStore.Infra.Data.Repositories
{
    public class PedidoRepository : Repository<Pedido>
    {
        private readonly AppDbContext _context;
        public override IUnitOfWork UnitOfWork => _context;

        public PedidoRepository(AppDbContext context) : base(context) 
        {
            _context = context;
        }

        public override async Task<Pedido?> GetById(int id)
        {
            return await _context.Pedidos
                            .Include(x => x.Itens)
                                .ThenInclude(x => x.Produto)
                            .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
