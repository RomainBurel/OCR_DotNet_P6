using System.ComponentModel.DataAnnotations;

namespace BDD.Data.Entities
{
	public class Status
	{
		[Key]
		public int IdStatus { get; set; }

		public string StatusName { get; set; }
	}
}
