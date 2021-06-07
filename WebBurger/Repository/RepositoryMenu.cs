using Dal;
using DomainModelBurger;
using System.Linq;

namespace WebBurger.Repository
{
	public class RepositoryMenu : IRepositoryMenu
	{
		private BurgerContext context;

		public RepositoryMenu(BurgerContext context)
		{
			this.context = context;
		}

		public IQueryable<Menu> GetMenus()
		{
			return this.context.Menus;
		}
	}
}