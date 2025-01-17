﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AppCore.DataAccess.EntityFramework.Bases
{
    public abstract class RepositoryBase<TEntity, TDbContext> : IRepositoryBase<TEntity, TDbContext> where TEntity : class, new() where TDbContext : DbContext, new()
    {
        public TDbContext DbContext { get; set; }
        protected RepositoryBase()
        {
            DbContext = new TDbContext();
        }
        protected RepositoryBase(TDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public void Add(TEntity entity, bool save = true)
        {
            DbContext.Set<TEntity>().Add(entity);
            if (save)
                Save();
        }

        public void Delete(TEntity entity, bool save = true)
        {
            DbContext.Set<TEntity>().Remove(entity);
            if (save)
                Save();
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate = null, bool save = true)
        {
            var entities = Query(predicate).ToList();

            foreach (var entity in entities)
            {
                Delete(entity, false);
            }

            if (save)
                Save();
        }

        public void Dispose()
        {
            DbContext?.Dispose();
            GC.SuppressFinalize(this);  
        }

        public IQueryable<TEntity> Query(params string[] entitiesToInclude)
        {
            var query = DbContext.Set<TEntity>().AsQueryable();
            foreach (var entityToInclude in entitiesToInclude)
            {
                query = query.Include(entityToInclude);
            }
            return query;
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate, params string[] entitiesToInclude)
        {
            var query = Query(entitiesToInclude);
            query = query.Where(predicate);
            return query;
        }

        public int Save()
        {
            try
            {
                return DbContext.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void Update(TEntity entity, bool save = true)
        {
            DbContext.Set<TEntity>().Update(entity);
            if (save)
                Save();
        }
    }
}
