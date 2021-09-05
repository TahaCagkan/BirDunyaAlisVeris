using Core.Entity;
using Core.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.POCO
{
    public class DatabaseLogger:BaseEntity
    {
        public string Description { get; set; }
        public LogType LogType { get; set; }
        public int AppUserId { get; set; }
        public virtual AppUser  AppUser { get; set; }
    }
}
