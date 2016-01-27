using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Productos;

namespace Core.Categorias
{
    public class Categoria : IAgregateRoot
    {
        protected Categoria() { }

        public Categoria(string nombre)
        {
            this.Nombre = nombre;
        }

        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public virtual ICollection<Producto> Productos { get; private set; }

    }
}
