using System.ComponentModel.DataAnnotations;

namespace BDD.Data.Entities
{
	public class Version
	{
		[Key]
		public int IdVersion { get; set; }

		public string VersionName { get; set; }
	}
}
