using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BDD.Data.Entities
{
	public class ProductVersionOS
	{
		[Key]
		public int IdProductVersionOS { get; set; }

		[ForeignKey(nameof(IdProduct))]
		public int IdProduct { get; set; }

		[ForeignKey(nameof(IdVersion))]
		public int IdVersion { get; set; }

		[ForeignKey(nameof(IdOS))]
		public int IdOS { get; set; }
	}
}
