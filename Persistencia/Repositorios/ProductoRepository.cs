using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Core.Repositorios;
using Core.Productos;
using Persistencia.Contexto;

namespace Persistencia.Repositorios
{
    internal class ProductoRepository:GenericRepository<Producto>, IProductoRepository
    {
        internal ProductoRepository(ContextoDominio contexto) : base(contexto) { }
    }
}
