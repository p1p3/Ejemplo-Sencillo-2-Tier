using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Categorias;

namespace PresentacionMVC.Models.Core
{
    public class CategoriaViewModel
    {
        public CategoriaViewModel(Categoria categoriaCore)
        {
            Nombre = categoriaCore.Nombre;
            Id = categoriaCore.Id;
        }

        public  Categoria ToDomainModel()
        {
            return new Categoria(this.Nombre);
        }


        public string Nombre { get; set; }
        public int Id { get; set; }
    }
}
