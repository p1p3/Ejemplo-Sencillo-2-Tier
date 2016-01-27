using System.Data.Entity.ModelConfiguration;
using Core.Productos;

namespace Persistencia.MapeoDB
{
    internal class ProductoMap : EntityTypeConfiguration<Producto>
    {
        public ProductoMap()
        {
            ToTable("Productos");

            HasKey(x => x.Id);

            Property(x => x.Id).
               HasColumnName("Id").
               IsRequired();

            Property(x => x.Nombre).
                HasColumnName("Nombre").
                HasMaxLength(250).
                IsRequired();

            HasRequired(x => x.Categoria).
                WithMany(x => x.Productos).
                HasForeignKey(x => x.CategoriaId);
        }
    }
}
