using Core.DAL;
using Core.Entity.Base.Absract;
using DAL.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class EfRepository<TEntity, TContext> : IGenericRepository<TEntity>
                 where TEntity : class, IBaseEntity,new()
                 where TContext : DbContext
    {
        private readonly TContext context;
        public EfRepository(TContext context)
        {
            this.context = context;
        }

        private async Task<bool> Commit()
        {
            if (await context.SaveChangesAsync() > 0) return true;
            return false;
        }

        public async Task<bool> Delete(TEntity entity)
        {
            //entity.GetType().GetMethod("get_Active").Invoke(entity, new object[] { true });
            entity.GetType().GetProperty("Active").SetValue(entity, false);
            entity.GetType().GetProperty("Delete").SetValue(entity, true);
            context.Entry(entity).State = EntityState.Modified;
            return true;

        }

        public async Task<TEntity> Get(int id)
        {
            //var t =typeof(TEntity);
             return await context.Set<TEntity>().FindAsync(id);
            //var a =(TEntity) await context.FindAsync(t, id);
            //return a;
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
           return await context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public Task<IQueryable<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null, params string[] includeItems)
        {
            IQueryable<TEntity> result;
            if(filter != null)
            {
                //sorguyu olusturduk
                result = context.Set<TEntity>().Where(filter);
            }
            else
            {
                //WHERE kosulum yok ise birsey yazma
               result =  context.Set<TEntity>().AsQueryable().AsNoTracking();
            }
            if(includeItems != null && includeItems.Length > 0)
            {
                foreach (var item in includeItems)
                {
                    result.Include(item);
                }
            }
            return Task.FromResult(result);
        }

        public async Task<bool> Insert(TEntity entity)
        {
          await context.AddAsync(entity);
            return await Commit();

        }

        public async Task<bool> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return await Commit();
        }

  
    }
}
