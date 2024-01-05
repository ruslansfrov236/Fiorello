using fiorello.entity.Entities.Customer;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiorello.entity.Entities
{
    public class Files : BaseEntity
    {
        public string? FilePath { get; set; }
        public Guid ProductsId { get; set; } 
        public Products? Products { get; set; }  
        public Guid HeaderId { get; set; }
        public Header? Header { get; set; }
        [NotMapped]
        public IFormFile? File { get; set; }
    }
}
