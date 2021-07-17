using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappers
{
    public class GenreMap : IEntityTypeConfiguration<Genre>
    {
        void IEntityTypeConfiguration<Genre>.Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nome).HasColumnName("NOME").HasMaxLength(100).IsRequired();
            builder.Property(t => t.DataCriacao).HasColumnName("DATA_CRIACAO");
            builder.Property(t => t.Ativo).HasColumnName("ATIVO");
        }
    }
}