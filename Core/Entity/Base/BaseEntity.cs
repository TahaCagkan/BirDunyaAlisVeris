using Core.Entity.Base.Absract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity.Base
{
    public class BaseEntity:IBaseEntity
    {
        public BaseEntity()
        {
            Created = DateTime.Now;
            Update = DateTime.Now;
            Active = true;
            Delete = false;
        }
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Update { get; set; }
        public bool Active { get; set; }
        public bool Delete { get; set; }
    }
}
