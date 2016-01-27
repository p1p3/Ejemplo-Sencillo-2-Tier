using System.Data.Entity.ModelConfiguration;
using Core.Categorias;

namespace Persistencia.MapeoDB
{
    internal class CategoriaMap : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMap()
        {
            ToTable("Categorias");

            HasKey(x => x.Id);

            Property(x => x.Id).
               HasColumnName("Id").
               IsRequired();

            Property(x => x.Nombre).
                HasColumnName("Nombre").
                HasMaxLength(250).
                IsRequired();

            HasMany(x => x.Productos)
                .WithRequired(x => x.Categoria)
                .HasForeignKey(x => x.CategoriaId);

        }
    }
}
