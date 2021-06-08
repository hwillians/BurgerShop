using Dal;
using DomainModelBurger;
using System.Linq;
using System.Threading.Tasks;

namespace WebBurger.Repository
{
	public class RepositoryMenu : IRepositoryMenu
	{
		private readonly BurgerContext context;

		public RepositoryMenu(BurgerContext burgerContext)
		{
			context = burgerContext;
		}

		public async Task<Menu> CreateMenuAsync(Menu menu)
		{
			context.Menus.Add(menu);
			await context.SaveChangesAsync();
			return menu;
		}

		public async Task DeleteMenuAsync(int id)
		{
			var menu = await context.Menus.FindAsync(id);
			context.Menus.Remove(menu);
			context.SaveChanges();
		}

		public async Task<Menu> EditMenuAsync(int id, Menu editedMenu)
		{
			var menu = context.Menus.Find(id);
			menu.Name = editedMenu.Name;
			menu.Price = editedMenu.Price;
			menu.Description = editedMenu.Description;
			menu.StockPiled = editedMenu.StockPiled;
			menu.Burger = editedMenu.Burger;
			menu.Dessert = editedMenu.Dessert;
			menu.Side = editedMenu.Side;
			menu.Beverage = editedMenu.Beverage;
			await context.SaveChangesAsync();

			return context.Menus.Find(id);
		}

		public async Task<Menu> GetMenuAsync(int id)
		{
			return await this.context.Menus.FindAsync(id);
		}

		public IQueryable<Menu> GetMenus()
		{
			return this.context.Menus;
		}
	}
}