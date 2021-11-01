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
    public class BasketManager : IBasketService
    {
        private readonly IBasketDAL db;
        private readonly IDatabaseLoggerDAL loggerDAL;

        public BasketManager(IBasketDAL db, IDatabaseLoggerDAL loggerDAL)
        {
            this.db = db;
            this.loggerDAL = loggerDAL;
        }
        //her ürünü eklemeden kullanici o ürünü eklemis mi eklememis mi
        public ResultService<Basket> InsertBasket(Basket entity)
        {
            Basket basket = null;
            try
            {
                basket = db.Get(
                    x => x.AppUserId == entity.AppUserId &&
                    x.ProductId == entity.ProductId &&
                    x.Active == true &&
                    x.Delete == false
                ).Result;
                if (basket != null)
                {
                    basket.Count = basket.Count + entity.Count;
                    if (db.Update(basket).Result)
                    {
                        return new ResultService<Basket>(basket);
                    }
                    return new ResultService<Basket>(null, "warning", ResultType.Warning);
                }
                else
                {
                    if (db.Insert(entity).Result)
                    {
                        entity.OrderType = OrderType.Basket;
                        return new ResultService<Basket>(entity);
                    }
                    return new ResultService<Basket>(null, "warning", ResultType.Warning);

                }
            }
            catch (Exception ex)
            {

                return new ResultService<Basket>(null, ex.Innest().Message, ResultType.Error);
            }
        }
        public ResultService Insert(Basket entity, object user)
        {
            throw new NotImplementedException();
        }
        public ResultService Update(Basket entity, object user)
        {
            //Bankadan Success alınca Active = false Delete = false
            //entity.OrderType = OrderType.Order;

            throw new NotImplementedException();
        }
        public ResultService Delete(Basket entity, object user)
        {
            //Bankadan Success alınca Active = false Delete = true
            //entity.OrderType = OrderType.Delete;

            throw new NotImplementedException();
        }

        public ResultService<Basket> Get(int id, object user)
        {
            try
            {
                var result = db.Get(id).Result;
                if (result != null)
                {
                    return new ResultService<Basket>(result);
                }
                return new ResultService<Basket>(null, "Bulunamadı", ResultType.Notfound);
            }
            catch (Exception ex)
            {
                return new ResultService<Basket>(null, ex.Innest().Message, ResultType.Error);

            }
        }

        public ResultService<Basket> Get(Expression<Func<Basket, bool>> filter, object user)
        {
            try
            {
                var result = db.Get(filter).Result;
                if (result != null)
                {
                    return new ResultService<Basket>(result);
                }
                return new ResultService<Basket>(null, "Warning", ResultType.Warning);
            }
            catch (Exception ex)
            {

                return new ResultService<Basket>(null, ex.Innest().Message, ResultType.Error);
            }
        }

        public ResultService<List<Basket>> GetList(Expression<Func<Basket, bool>> filter = null, object user = null, params string[] includeItems)
        {
            try
            {
                var result = db.GetList(filter, includeItems).Result;
                if (result != null && result.Count() > 0)
                {
                    return new ResultService<List<Basket>>(result.ToList());
                }
                return new ResultService<List<Basket>>(null, "Warning", ResultType.Warning);
            }
            catch (Exception ex)
            {

                return new ResultService<List<Basket>>(null, ex.Innest().Message, ResultType.Error);
            }
        }
    }
}
