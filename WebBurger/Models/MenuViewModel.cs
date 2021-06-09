using DomainModelBurger;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebBurger.Models
{
	public class MenuViewModel
	{
		public Menu Menu { get; set; }
		public SelectList BurgerList { get; set; }
		public SelectList BeverageList { get; set; }
		public SelectList SideList { get; set; }
		public SelectList DessertList { get; set; }
	}
}