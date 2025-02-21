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

            builder.ToTable("PedidoItens");
        }
    }
}
