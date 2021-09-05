using Core.Entity;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Abstract
{
    public interface IDatabaseLoggerDAL
    {
        bool Add(string desc, object user,LogType logType);
        List<DatabaseLogger> DataListlog(Expression<Func<DatabaseLogger,bool>> filter,int top);
    }
}
