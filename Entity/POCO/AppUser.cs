using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.POCO
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public virtual List<Basket> Basket { get; set; }
        public virtual List<DatabaseLogger> DatabaseLogger { get; set; }
    }
}
