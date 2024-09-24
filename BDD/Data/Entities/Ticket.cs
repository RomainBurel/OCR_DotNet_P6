using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BDD.Data.Entities
{
	public class Ticket
	{
		[Key]
		public int IdTicket { get; set; }

		[ForeignKey(nameof(IdProductVersionOS))]
		public int IdProductVersionOS { get; set; }

		[ForeignKey(nameof(IdStatus))]
		public int IdStatus { get; set; }

		public DateTime DateCreation { get; set; }

		public DateTime? DateSolving { get; set; }

		public string Description { get; set; } = string.Empty;

		public string? Solution { get; set; }
	}
}
