using fiorello.entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiorello.business.Dto.HeaderDto
{
    public class UpdateHeaderDto
    {
        public string Id { get; set; }  
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<Files> Files { get; set; }
    }
}
