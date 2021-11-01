using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI_BirDunyaAlisVeris.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MasterCategoryId { get; set; }
        public string CategoryImage { get; set; }
    }
}
