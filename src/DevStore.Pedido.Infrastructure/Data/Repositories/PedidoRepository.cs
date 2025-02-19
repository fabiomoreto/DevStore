using DevStore.Pedidos.Domain.Interfaces;
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
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public PedidoRepository(PedidoContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
