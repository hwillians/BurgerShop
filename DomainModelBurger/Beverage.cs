using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModelBurger
{
	[Table("Beverage")]
	public class Beverage : Product
	{
		[Required]
		public double Millimeter { get; set; }

		[Required]
		[DisplayName("Carbonated")]
		public bool IsCarbonated { get; set; }
	}
}