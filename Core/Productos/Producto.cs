using System;
using System.Collections.Generic;
using Core.Categorias;

namespace Core.Productos
{
    public class Producto: IAgregateRoot
    {
        protected Producto() { }

        public Producto(string nombre, Categoria categoria)
        {
            this.Nombre = nombre;
            this.Categoria = categoria;
            this.CategoriaId = categoria.Id;
        }

        public int Id { get; private set; }
        public int CategoriaId { get; private set; }
        public string Nombre { get; private set; }

        public virtual Categoria Categoria { get; private set; }
    }
}
