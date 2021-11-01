using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BLL.InnerException
{
    public static class InnerEx
    {
        //Hatayı yakalamk icin
        public static Exception Innest(this Exception ex)
        {
            if (ex.InnerException != null)
            { 
                //recursive method ile en alt katmandan gelen hatayi bulundu
                return ex.InnerException.Innest();
            }
            return ex;
        }
    }
}
