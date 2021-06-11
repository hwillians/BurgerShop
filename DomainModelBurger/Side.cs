using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModelBurger
{
	[Table("Sides")]
	public class Side : Product
	{
		[Required]
		public int Weight { get; set; }

		[Required]
		[DisplayName("Salt weight")]
		public int SaltWeight { get; set; }
	}
}