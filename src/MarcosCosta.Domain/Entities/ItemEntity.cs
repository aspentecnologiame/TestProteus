using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcosCosta.Domain.Entities
{
    public class ItemEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid RDFId { get; set; }
        public string About { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
    }
}
