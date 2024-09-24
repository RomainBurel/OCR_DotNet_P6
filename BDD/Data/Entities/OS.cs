using System.ComponentModel.DataAnnotations;

namespace BDD.Data.Entities
{
	public class OS
	{
		[Key]
		public int IdOS { get; set; }

		public string OSName { get; set; }
	}
}
