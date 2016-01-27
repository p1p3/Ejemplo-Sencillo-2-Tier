using System.Data.Entity;
using Core.Productos;
using Core.Categorias;

namespace Persistencia.Contexto
{
    class InicializadorDB : DropCreateDatabaseAlways<ContextoDominio>
    {
        protected override void Seed(ContextoDominio context)
        {
            var Categoria = new Categoria("Prueba1");
            context.Categorias.Add(Categoria);

            var Producto = new Producto("Prueba", Categoria);
            context.Productos.Add(Producto);

            base.Seed(context);
        }
    }
}
