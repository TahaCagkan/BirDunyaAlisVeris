using Core.DAL;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Abstract
{
    public interface IProductCategoryDAL
        : IGenericRepository<ProductCategory>
    {
    }
}
