using fiorello.entity.Entities.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiorello.entity.Entities
{
    public  class Header:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<Files> Files { get; set; }
    }
}
