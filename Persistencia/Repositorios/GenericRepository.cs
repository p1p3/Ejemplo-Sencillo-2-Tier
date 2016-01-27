using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.SqlClient;
using System.Data.Entity;

using Core;
using Core.Repositorios;
using Persistencia.Contexto;

namespace Persistencia.Repositorios
{
    internal class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IAgregateRoot
    {
        protected ContextoDominio _contexto;
        private DbSet<TEntity> _set;

        internal GenericRepository(ContextoDominio contexto)
        {
            _contexto = contexto;
        }

        protected DbSet<TEntity> SetDb
        {
            get
            {
                _set = _set ?? _contexto.Set<TEntity>();
                return _set;
            }
        }

        public void Add(TEntity entity)
        {
            SetDb.Add(entity);
        }

        public TEntity FindById(object id)
        {
            return SetDb.Find(id);
        }

        public List<TEntity> PageAndFilter(int skip = -1, int take = -1, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Expression<Func<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = SetDb;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                query = query.Include(include);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip > -1)
            {
                query = query.Skip(skip);
            }

            if (take > -1)
            {
                query = query.Take(take);
            }

            return query.ToList();
        }

        public void Remove(TEntity entity)
        {
            if (_contexto.Entry(entity).State == EntityState.Detached)
            {
                SetDb.Attach(entity);
            }
            SetDb.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            var entry = _contexto.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                SetDb.Attach(entity);
                entry = _contexto.Entry(entity);
            }
            entry.State = EntityState.Modified;
        }
    }
}
