using Core.Entity;
using Core.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.POCO
{
    public class Basket:BaseEntity
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int AppUserId { get; set; }
        public OrderType OrderType { get; set; }
        //Navigation Property
        public virtual Product Product { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
