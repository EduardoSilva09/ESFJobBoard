using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESFJobBoard.API.Model
{
    public class JobApplication : BaseEntity
    {
        public int JobId { get; set; }
        public int JobSeekerId { get; set; }
        public DateTime DateApplied { get; set; }
    }
}