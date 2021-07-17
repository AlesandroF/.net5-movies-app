using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappers
{
    public class MovieMap : IEntityTypeConfiguration<Movie>
    {
        void IEntityTypeConfiguration<Movie>.Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nome).HasColumnName("NOME").HasMaxLength(200).IsRequired();
            builder.Property(t => t.DataCriacao).HasColumnName("DATA_CRIACAO").IsRequired();
            builder.Property(t => t.Ativo).HasColumnName("ATIVO");
            
            builder.HasOne(x => x.Genre).WithMany(x => x.Movie).HasForeignKey(x => x.GenreId);
        }
    }
}