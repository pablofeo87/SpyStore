using System;
using System.Collections.Generic;
using System.Text;

namespace SpyStore.Models.Entities.Base
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public byte[] TimeStamp { get; set; }
    }
}
