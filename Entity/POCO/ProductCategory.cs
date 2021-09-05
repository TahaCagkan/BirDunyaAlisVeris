using Core.Entity.Base.Absract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.POCO
{
    public class ProductCategory: IBaseEntity
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        //Navigation Property
        public virtual Product Product { get; set; }
        public virtual Category Category { get; set; }

    }
}
