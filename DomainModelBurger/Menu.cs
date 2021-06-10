using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModelBurger
{
	[Table("Menu")]
	public class Menu : Product
	{
		public virtual Burger Burger { get; set; }

		public virtual Beverage Beverage { get; set; }

		public virtual Side Side { get; set; }

		public virtual Dessert Dessert { get; set; }

		[Required(ErrorMessage = "Burger is required")]
		public virtual int BurgerProductId { get; set; }

		[Required(ErrorMessage = "Beverage is required")]
		public virtual int BeverageProductId { get; set; }

		[Required(ErrorMessage = "Side is required")]
		public virtual int SideProductId { get; set; }

		public virtual int? DessertProductId { get; set; }
	}
}