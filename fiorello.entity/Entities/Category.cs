using fiorello.entity.Entities.Customer;


namespace fiorello.entity.Entities
{
	public class Category :BaseEntity
	{

		public string? Name { get; set; }	

		public int CategoryCount {  get; set; }	

		
		public Products? Product{ get; set; }
	}
}
