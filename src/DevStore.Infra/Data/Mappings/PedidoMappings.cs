using DevStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevStore.Infra.Data.Mappings
{
    public class PedidoMappings : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(p => p.NomeCliente)
                .IsRequired()
                .HasColumnType("varchar(60)");

            builder.Property(p => p.EmailCliente)
                .IsRequired()
                .HasColumnType("varchar(60)");

            builder.Property(p => p.DataCriacao)
                .IsRequired();

            builder.Property(p => p.Pago)
                .IsRequired();

            builder.HasMany(c => c.Itens)
                .WithOne(c => c.Pedido)
                .HasForeignKey(c => c.PedidoId);

            builder.ToTable("Pedidos");
        }
    }
}
