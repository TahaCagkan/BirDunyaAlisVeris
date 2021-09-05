using DAL.Abstract;
using DAL.EntityFramework.Context;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Concrete
{
    public class EfCategoryRepository : EfRepository<Category, BirDunyaDbContext>, ICategoryDAL
    {
        private readonly BirDunyaDbContext context;

        public EfCategoryRepository(BirDunyaDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
