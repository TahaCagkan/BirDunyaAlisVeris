using Core.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.POCO
{
    public class MasterCategory:BaseEntity
    {
        public string Name { get; set; }
        //Navigation Property
        public virtual List<Category> Category { get; set; }
    }
}
