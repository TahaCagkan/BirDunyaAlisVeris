using Core.BLL.ResultBusiness;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstract
{
    public interface IBasketService : IGenericService<Basket>
    {
        ResultService<Basket> InsertBasket(Basket entity);
    }
}
