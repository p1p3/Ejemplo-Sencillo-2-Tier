using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Productos;
using Core.Categorias;

namespace PresentacionMVC.Models.Core
{
    public class ProductViewModel
    {
        public ProductViewModel() { }

        public ProductViewModel(Producto productoCore)
        {
            this.Id = productoCore.Id;
            this.Nombre = productoCore.Nombre;
            this.CategoriaId = productoCore.CategoriaId;
            this.Categoria = new CategoriaViewModel(productoCore.Categoria);
        }

        public Producto ToDomainModel(Categoria cat)
        {
            return new Producto(this.Nombre, cat);
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CategoriaId { get; set; }
        public CategoriaViewModel Categoria { get; set; }

        public IList<CategoriaViewModel> Categorias { get; set; }

    }
}
