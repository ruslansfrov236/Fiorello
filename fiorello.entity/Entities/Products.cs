using fiorello.entity.Entities.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace fiorello.entity.Entities
{
	public class Products : BaseEntity
	{
		[Required(ErrorMessage = "Zorunlu alan.")]
		public string? Title { get; set; }

		public string? FilePath { get; set; }

		[Required(ErrorMessage = "Zorunlu alan.")]
		public decimal Price { get; set; }

		[Required(ErrorMessage = "Zorunlu alan.")]
		public int StockProduct { get; set; }
		public bool isProfilImage { get; set; }
		[Required(ErrorMessage = "Zorunlu alan.")]
		public Guid CategoryId { get; set; }

		[Required(ErrorMessage = "Zorunlu alan.")]
		public ICollection<Category>? Categories { get; set; }

		public ICollection<Files>? Files { get; set; }
		[Required(ErrorMessage = "Zorunlu alan.")]
		public string Description { get; set; }	
	}
}
