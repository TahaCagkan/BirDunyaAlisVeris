using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BLL.ResultBusiness
{
    //Dönülen resultType ve message islemlieri icin
    public enum ResultType 
    { 
        Success,
        Error,
        Warning,
        Notfound
    }
    public class ResultService
    {
        public readonly string message;
        public readonly ResultType resultType;
        public ResultService(string message="Success", ResultType resultType= ResultType.Success)
        {
            this.message = message;
            this.resultType = resultType;
        }
    }
    public class ResultService<T>: ResultService
    {
        public readonly T data;
        //bagımlılıklarımızı kontrol etmek icin base ctordan kalıtıldı,mesaj ve resutl degerine göre,true false yerine Success gitsin gibi
        public ResultService(T data, string message = "Success", ResultType resultType = ResultType.Success):base(message,resultType)
        {
            this.data = data;
        }
    }
}
