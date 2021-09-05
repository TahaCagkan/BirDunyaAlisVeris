using DAL.Abstract;
using DAL.EntityFramework.Context;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Concrete
{
    public class EfProductImageRepository : EfRepository<ProductImage, BirDunyaDbContext>, IProductImageDAL
    {
        private readonly BirDunyaDbContext context;

        public EfProductImageRepository(BirDunyaDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
