using DevStore.SharedKernel.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using DevStore.Domain.Models;
using DevStore.Infra.Data.Mappings;
using DevStore.Domain.ValueObjects;

namespace DevStore.Infra.Data.Context
{
    public class PedidoContext : DbContext, IUnitOfWork
    {
        public PedidoContext(DbContextOptions<PedidoContext> options)
            : base(options) { }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.ApplyConfiguration(new PedidoMappings());
            modelBuilder.ApplyConfiguration(new PedidoItemMappings());
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
