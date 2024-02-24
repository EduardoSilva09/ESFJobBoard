using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESFJobBoard.API.Model
{
    public class BaseEntity
    {
        protected BaseEntity() { }
        public int Id { get; private set; }
    }
}