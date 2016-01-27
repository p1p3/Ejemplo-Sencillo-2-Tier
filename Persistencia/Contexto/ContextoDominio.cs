using System.Data.Entity;
using Core.Productos;
using Core.Categorias;
using Persistencia.MapeoDB;

namespace Persistencia.Contexto
{
    public class ContextoDominio : DbContext
    {
        public DbSet<Producto> Productos { get; private set; }
        public DbSet<Categoria> Categorias { get; private set; }

        static ContextoDominio()
        {
            Database.SetInitializer(new InicializadorDB());
        }

        public ContextoDominio(string nameOrConnectionString = "Plantilla") : base(nameOrConnectionString)
        {

            base.Configuration.ProxyCreationEnabled = true;
            base.Configuration.LazyLoadingEnabled = true;

            Productos = base.Set<Producto>();
            Categorias = base.Set<Categoria>();

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductoMap());
            modelBuilder.Configurations.Add(new CategoriaMap());
        }

    }
}
