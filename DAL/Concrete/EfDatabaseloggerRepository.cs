using Core.Entity;
using DAL.Abstract;
using DAL.EntityFramework.Context;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Concrete
{
    public class EfDatabaseloggerRepository : IDatabaseLoggerDAL
    {
        private readonly BirDunyaDbContext db;

        public EfDatabaseloggerRepository(BirDunyaDbContext db)
        {
            this.db = db;
        }

        public bool Add(string desc, object user, LogType logType)
        {
            AppUser appUser;
            if(user is AppUser)
            {
                appUser = (AppUser)user;
                db.Add(new DatabaseLogger { 
                    AppUserId = appUser.Id,
                    Description = desc ,
                    LogType=logType
                });
                if (db.SaveChanges() > 0) return true;
                return false;
            }
            return false;
        }
        public List<DatabaseLogger> DataListlog(Expression<Func<DatabaseLogger, bool>> filter, int top =10)
        {
            return db.DatabaseLogger.Where(filter).Take(top).ToList();
        }
    }
}
