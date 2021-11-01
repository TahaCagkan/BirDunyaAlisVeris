using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI_BirDunyaAlisVeris.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Zorunludur!!!")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Şifre Zorunludur!!!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
