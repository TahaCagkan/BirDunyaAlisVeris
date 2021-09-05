using DAL.Abstract;
using DAL.EntityFramework.Context;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Concrete
{
    public class EfProductCategoryRepository
         : EfRepository<ProductCategory, BirDunyaDbContext>, IProductCategoryDAL
    {
        private readonly BirDunyaDbContext context;

        public EfProductCategoryRepository(BirDunyaDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
