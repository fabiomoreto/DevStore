using DevStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevStore.Infra.Data.Mappings
{
    public class PedidoItemMappings : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(p => p.Quantidade)
                .IsRequired();

            builder.HasOne(c => c.Pedido)
                .WithMany(c => c.Itens)
                .HasForeignKey(c => c.PedidoId);

            builder.HasOne(c => c.Produto)
                .WithMany(c => c.Itens)
                .HasForeignKey(c => c.ProdutoId);

            builder.ToTable("PedidoItens");
        }
    }
}
