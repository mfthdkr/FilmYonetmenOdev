using AppCore.DataAccess.EntityFramework.Bases;
using Microsoft.EntityFrameworkCore;

namespace AppCore.DataAccess.EntityFramework
{
    public class Repository<TEntity,TDbContext>: RepositoryBase<TEntity, TDbContext> where TEntity : class,new() where TDbContext :DbContext, new()
    {
        public Repository() : base()    
        {

        }
        public Repository(TDbContext dbContext) : base(dbContext)
        {

        }
    }
}
