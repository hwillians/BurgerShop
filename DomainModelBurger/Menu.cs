using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModelBurger
{
	[Table("Menu")]
	public class Menu : Product
	{
		[Required]
		public Beverage Beverage { get; set; }

		[Required]
		public Side Side { get; set; }

		public Dessert Dessert { get; set; }

		[Required]
		public Burger Burger { get; set; }
	}
}