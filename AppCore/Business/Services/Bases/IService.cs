﻿using AppCore.Business.Models.Results;
using AppCore.DataAccess.EntityFramework.Bases;
using Microsoft.EntityFrameworkCore;

namespace AppCore.Business.Services.Bases
{
    public interface IService<TModel,TEntity,TDbContext> :IDisposable where TModel : class,new() where TEntity : class,new() where TDbContext:DbContext,new()
    {
        RepositoryBase<TEntity,TDbContext> Repository { get; set; }
        IQueryable<TModel> Query();
        Result Add(TModel model);
        Result Update(TModel model);
        Result Delete(int id);
    }
}
