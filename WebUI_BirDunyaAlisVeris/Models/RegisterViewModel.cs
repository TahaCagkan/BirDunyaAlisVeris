using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI_BirDunyaAlisVeris.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "İsim Alanı Zorunludur")]
        [Display(Name = "Adınız")]
        public string Name { get; set; }
        [Display(Name = "Soyadınız")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Kullanıcı Adı Zorunludur")]
        [Display(Name = "Kullanıcı Adınız")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email Zorunludur")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre Zorunludur")]
        [Display(Name = "Şifreniz")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifre Tekrar Zorunludur")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Şifreniz Tekrar")]
        public string PasswordConfirm { get; set; }
    }
}
