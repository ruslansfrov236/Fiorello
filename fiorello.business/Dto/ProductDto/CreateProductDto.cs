using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using fiorello.entity.Entities;

namespace fiorello.business.Dto.ProductDto
{
    public class CreateProductDto
    {
		[Required(ErrorMessage = "Zorunlu alan.")]
		public string? Title { get; set; }

		public string? FilePath { get; set; }

		[Required(ErrorMessage = "Zorunlu alan.")]
		public decimal Price { get; set; }

		[Required(ErrorMessage = "Zorunlu alan.")]
		public int StockProduct { get; set; }

		[Required(ErrorMessage = "Zorunlu alan.")]
		public Guid CategoryId { get; set; }


		[Required(ErrorMessage = "Zorunlu alan.")]
		public ICollection<Category>? Categories { get; set; }

		public ICollection<Files>? Files { get; set; }
		[Required(ErrorMessage = "Zorunlu alan.")]
		public string Description { get; set; }

		public bool isProfilImage { get; set; }
	}
}
