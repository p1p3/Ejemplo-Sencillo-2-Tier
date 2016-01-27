using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Persistencia.Contexto;
using Core;
using Core.Repositorios;
using System.Threading;

namespace Persistencia.UnitOfWork
{
   public class UnitOfWork:IUnitOfWork
    {

        private ContextoDominio _context { get; }
        private ICategoriaRepository _CategoriaRepository;
        private IProductoRepository _ProductoRepository;

        public UnitOfWork()
        {
            _context = new ContextoDominio();
        }

        public ICategoriaRepository CategoriaRepository
        {
            get
            {
                if (_CategoriaRepository == null)
                {
                    _CategoriaRepository = new Repositorios.CategoriaRepository(_context);
                }
                return _CategoriaRepository;
            }
        }

        public IProductoRepository ProductoRepository
        {
            get
            {
                if (_ProductoRepository == null)
                {
                    _ProductoRepository = new Repositorios.ProductoRepository(_context);
                }
                return _ProductoRepository;
            }
        }


        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        #region IDisposable 
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _CategoriaRepository = null;
                    _ProductoRepository = null;
                    _context.Dispose();
                }
                disposedValue = true;
            }
        }


        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
