using DAL.Abstract;
using DAL.EntityFramework.Context;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Concrete
{
    public class EfMasterCategoryRepository
        : EfRepository<MasterCategory, BirDunyaDbContext>, IMasterCategoryDAL
    {
        private readonly BirDunyaDbContext context;

        public EfMasterCategoryRepository(BirDunyaDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
