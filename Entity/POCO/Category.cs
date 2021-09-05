using Core.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.POCO
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public int MasterCategoryId { get; set; }
        public string CategoryImage { get; set; }
        //Navigation Property
        public virtual List<ProductCategory> ProductCategory { get; set; }
        //Navigation Property
        public virtual MasterCategory MasterCategory { get; set; }

    }
}
