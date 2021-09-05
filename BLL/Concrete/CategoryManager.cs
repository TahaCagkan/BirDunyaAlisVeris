using BLL.Abstract;
using Core.BLL.InnerException;
using Core.BLL.ResultBusiness;
using Core.Entity;
using DAL.Abstract;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Concrete
{
    public class CategoryManager:ICategoryService
    {
        private readonly ICategoryDAL db;
        private readonly IDatabaseLoggerDAL loggerDAL;

        public CategoryManager(ICategoryDAL db, IDatabaseLoggerDAL loggerDAL)
        {
            this.db = db;
            this.loggerDAL = loggerDAL;
        }
        public ResultService Insert(Category entity, object user)
        {
            Category category = new Category
            {
                Name ="",
                MasterCategoryId = 5
            };
            try
            {
                if (
                db.Insert(entity).Result)
                {
                    return new ResultService();
                }
                else
                {
                    return new ResultService("Warning", ResultType.Warning);
                }
            }
            catch (Exception ex)
            {
                //string m = null;
                var e = ex.Innest();
                //if(e is SqlException)
                //{
                //    m = "Sql Hatası";
                //}
                //return new ResultService(ex.Innest().Message, ResultType.Error);
                return new ResultService(ResultMessage.ResultErrorMessage(e.Message), ResultType.Error);

            }
        }

        public ResultService Update(Category entity, object user)
        {
            try
            {
                if (db.Update(entity).Result)
                {
                    return new ResultService();
                }
                else
                {
                    return new ResultService("Güncelleme Başarısız", ResultType.Warning);
                }
            }
            catch (Exception ex)
            {

                return new ResultService(ex.Innest().Message, ResultType.Error);
            }
        }
        public ResultService Delete(Category entity, object user)
        {
            try
            {
                if (db.Delete(entity).Result)
                {
                    loggerDAL.Add("Delete", user, LogType.Delete);
                    return new ResultService();
                }
                return new ResultService("Warning", ResultType.Warning);
            }
            catch (Exception ex)
            {
                return new ResultService(ex.Innest().Message, ResultType.Error);
            }
        }

        public ResultService<Category> Get(int id, object user)
        {
            try
            {
                var result = db.Get(id).Result;
                if (result != null)
                {
                    return new ResultService<Category>(result);
                }
                return new ResultService<Category>(null, "Bulunamadı", ResultType.Notfound);
            }
            catch (Exception ex)
            {
                return new ResultService<Category>(null, ex.Innest().Message, ResultType.Error);

            }
        }

        public ResultService<Category> Get(Expression<Func<Category, bool>> filter, object user)
        {
            try
            {
                var result = db.Get(filter).Result;
                if (result != null)
                {
                    return new ResultService<Category>(result);
                }
                return new ResultService<Category>(null, "Warning", ResultType.Warning);
            }
            catch (Exception ex)
            {

                return new ResultService<Category>(null, ex.Innest().Message, ResultType.Error);
            }
        }

        public ResultService<List<Category>> GetList(Expression<Func<Category, bool>> filter = null, object user = null, params string[] includeItems)
        {
            try
            {
                var result = db.GetList(filter, includeItems).Result;
                if (result != null && result.Count() > 0)
                {
                    return new ResultService<List<Category>>(result.ToList());
                }
                return new ResultService<List<Category>>(null, "Warning", ResultType.Warning);
            }
            catch (Exception ex)
            {

                return new ResultService<List<Category>>(null, ex.Innest().Message, ResultType.Error);
            }
        }
    }
}
