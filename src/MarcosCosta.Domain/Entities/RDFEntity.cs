using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcosCosta.Domain.Entities
{
    public class RDFEntity
    {
        public ChannelEntity Channel { get; set; }
        public IEnumerable<ItemEntity> Items { get; set; }
    }
}
