using Core.Entity.Base.Absract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DAL
{
    public interface IGenericRepository<TEntity>
        where TEntity : class, IBaseEntity, new()
    {
        Task<bool> Insert(TEntity entity);
        Task<bool> Delete(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<TEntity>Get(int id);
        Task<TEntity> Get(Expression<Func<TEntity,bool>> filter);

        Task<IQueryable<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null,params string[] includeItems);

       //Task<bool> Commit();

    }
}
