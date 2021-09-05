using BLL.Abstract;
using Core.BLL.InnerException;
using Core.BLL.ResultBusiness;
using Core.Entity;
using DAL.Abstract;
using DAL.Concrete;
using Entity.POCO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Concrete
{
    public class ProductManager : IProductService
    {
        //IProductDAL kullanildi icerisinde IGenericRepository bulunmakta bu sayede GenericRepository ulasabilecegim
        private readonly IProductDAL db;
        private readonly IDatabaseLoggerDAL loggerDAL;

        public ProductManager(IProductDAL db,IDatabaseLoggerDAL loggerDAL)
        {
            this.db = db;
            this.loggerDAL = loggerDAL;
        }
        public ResultService<Product> AddProduct(Product product, string[] imageUrl, object user, params int[] categories)
        {
            Product result = null;
            try
            {
                result = db.AddProduct(product, imageUrl, categories).Result;
                if (result != null)
                {
                    loggerDAL.Add("Ekleme", user, LogType.Insert);
                    return new ResultService<Product>(result);
                }
                else
                {
                    loggerDAL.Add("Warning", user, LogType.Warning);
                    return new ResultService<Product>(null, "Warning", ResultType.Warning);
                }
            }
            catch (Exception ex)
            {
                var e = ex.Innest();
                loggerDAL.Add("Warning", user, LogType.Warning);
                return new ResultService<Product>(null, ex.Message, ResultType.Error);
            }
        }
        public ResultService Insert(Product entity, object user)
        {
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

        public ResultService Update(Product entity, object user)
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

                return new ResultService(ex.Innest().Message,ResultType.Error);
            }
        }
        public ResultService Delete(Product entity, object user)
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

        public ResultService<Product> Get(int id, object user)
        {
            try
            {
               var result = db.Get(id).Result;
                if(result != null)
                {
                    return new ResultService<Product>(result);
                }
                return new ResultService<Product>(null, "Bulunamadı", ResultType.Notfound);
            }
            catch (Exception ex)
            {
                return new ResultService<Product>(null, ex.Innest().Message, ResultType.Error);
                
            }
        }

        public ResultService<Product> Get(Expression<Func<Product, bool>> filter, object user)
        {
            try
            {
                var result = db.Get(filter).Result;
                if(result != null)
                {
                    return new ResultService<Product>(result);
                }
                return new ResultService<Product>(null,"Warning",ResultType.Warning);
            }
            catch (Exception ex)
            {

                return new ResultService<Product>(null,ex.Innest().Message,ResultType.Error);
            }
        }

        public ResultService<List<Product>> GetList(Expression<Func<Product, bool>> filter = null, object user=null ,params string[] includeItems)
        {
            try
            {
               var result = db.GetList(filter, includeItems).Result;
                if(result != null && result.Count()> 0)
                {
                    return new ResultService<List<Product>>(result.ToList());
                }
                return new ResultService<List<Product>>(null, "Warning", ResultType.Warning);
            }
            catch (Exception ex)
            {

                return new ResultService<List<Product>>(null, ex.Innest().Message, ResultType.Error);
            }
        }

    }
}
