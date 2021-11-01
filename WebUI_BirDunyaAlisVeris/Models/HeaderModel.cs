using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI_BirDunyaAlisVeris.DTOs;

namespace WebUI_BirDunyaAlisVeris.Models
{
    public class HeaderModel
    {
        public List<CategoryDTO> Categories { get; set; }
        public List<Product> Products { get; set; }
        public List<Basket> Baskets { get; set; }
        public int count { get; set; }
    }
}
