using DevStore.Pedidos.Domain.Models;
using DevStore.SharedKernel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Pedidos.Domain.Interfaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<IEnumerable<Pedido>> GetAll();
        Task<Pedido> GetById(int id);
        void Add(Pedido pedido);
        void Update(Pedido pedido);
        void Delete(Pedido pedido);
    }
}
