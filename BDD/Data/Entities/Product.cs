using System.ComponentModel.DataAnnotations;

namespace BDD.Data.Entities
{
	public class Product
	{
		[Key]
		public int IdProduct { get; set; }

		public string NameProduct { get; set; }
	}
}
