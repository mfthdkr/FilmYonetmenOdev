﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AppCore.DataAccess.EntityFramework.Bases
{
    public interface IRepositoryBase<TEntity,TDbContext> :IDisposable where TEntity : class,new() where TDbContext:DbContext,new()
    {   
        TDbContext DbContext { get; set; }
        IQueryable<TEntity> Query(params string[] entitiesToInclude);
        IQueryable<TEntity> Query(Expression<Func<TEntity,bool>> predicate, params string[] entitiesToInclude);
        void Add(TEntity entity,bool save= true);
        void Update(TEntity entity, bool save = true);
        void Delete(TEntity entity, bool save = true);
        void Delete(Expression<Func<TEntity,bool>> predicate, bool save = true);
        int Save();
    }
}
