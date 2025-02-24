using DevStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevStore.Infra.Data.Mappings
{
    public class ProdutoMappings : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(p => p.Valor)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.ToTable("Produtos");
        }
    }
}
