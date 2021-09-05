using Core.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.POCO
{
    public class ProductImage:BaseEntity
    {
        public string ImageUrl { get; set; }
        public int ProductId { get; set; }
        //Navigation Property
        public virtual Product Product { get; set; }
    }
}
