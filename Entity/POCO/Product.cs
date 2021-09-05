using Core.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.POCO
{
    public class Product:BaseEntity
    {       
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Stok { get; set; }
        public string Descripton { get; set; }
        //Navigation Property
        public virtual List<ProductCategory> ProductCategory { get; set; }
        public virtual List<ProductImage> ProductImage { get; set; }
        public virtual List<Basket> Basket { get; set; }


    }
}
