using DevStore.Pedidos.Domain.Models;
using DevStore.Pedidos.Infrastructure.Data.Context;
using DevStore.SharedKernel.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Pedidos.Infra.Data.Repositories
{
    public class PedidoRepository : Repository<Pedido>
    {
        private readonly PedidoContext _context;
        public override IUnitOfWork UnitOfWork => _context;

        public PedidoRepository(PedidoContext context) : base(context) 
        {
            _context = context;
        }
    }
}
