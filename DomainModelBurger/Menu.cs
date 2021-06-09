using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModelBurger
{
	[Table("Menu")]
	public class Menu : Product
	{
		[Required(ErrorMessage = "Burger is required")]
		public virtual Burger Burger { get; set; }

		public virtual Beverage Beverage { get; set; }

		public virtual Side Side { get; set; }

		public virtual Dessert Dessert { get; set; }
	}
}