using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcosCosta.Domain.Entities
{
    public abstract class BaseEntity
    {
        public DateTime Updated { get; set; }
        public DateTime Created { get; set; }
    }
}
