using Core.BLL.ResultBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IGenericService<TEntity>
    {
        ResultService Insert(TEntity entity, object user);
        ResultService Delete(TEntity entity, object user);
        ResultService Update(TEntity entity, object user);
        ResultService<TEntity> Get(int id, object user);
        ResultService<TEntity> Get(Expression<Func<TEntity, bool>> filter, object user);
        ResultService<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null, object user = null, params string[] includeItems);
    }
}
