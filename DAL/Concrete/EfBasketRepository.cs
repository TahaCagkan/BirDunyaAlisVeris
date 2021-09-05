using DAL.Abstract;
using DAL.EntityFramework.Context;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Concrete
{
    public class EfBasketRepository : EfRepository<Basket, BirDunyaDbContext>, IBasketDAL
    {
        private readonly BirDunyaDbContext context;

        public EfBasketRepository(BirDunyaDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}

