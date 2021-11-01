using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI_BirDunyaAlisVeris.Models
{
    public class BasketViewModel
    {
        public int Count { get; set; }
        public List<Product> Product { get; set; }
    }
}
