using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repositorios;
using System.Threading;

namespace Core
{
    public interface IUnitOfWork
    {
        IProductoRepository ProductoRepository { get; }
        ICategoriaRepository CategoriaRepository { get; }


        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
