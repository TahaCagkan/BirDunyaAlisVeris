using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BLL.ResultBusiness
{
    public class ResultMessage
    {
        public static string ResultUpdateMessage(string result)=> $"{result} Güncelleme başarısız";
        public static string ResultInsertMessage(string result) => $"{result} Ekleme başarısız";
        public static string ResultErrorMessage(string result) => $"{result} Hata ";


    }
}
