using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Repositorios;
using Core.Categorias;
using Persistencia.Contexto;
namespace Persistencia.Repositorios
{
    internal class CategoriaRepository:GenericRepository<Categoria>, ICategoriaRepository
    {
        internal CategoriaRepository(ContextoDominio contexto) : base(contexto) { }
    }
}
