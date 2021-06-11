using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModelBurger
{
	[Table("Desserts")]
	public class Dessert : Product
	{
		[Required]
		[Range(25, 2000)]
		public double Millimeter { get; set; }

		[Required]
		[DisplayName("Frozen")]
		public bool IsFrozen { get; set; }
	}
}