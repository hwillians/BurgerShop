using Dal;
using DomainModelBurger;
using System.Linq;
using System.Threading.Tasks;

namespace WebBurger.Repository
{
	public class RepositoryMenu : IRepositoryMenu
	{
		private BurgerContext context;

		public RepositoryMenu(BurgerContext context)
		{
			this.context = context;
		}

		public Task<Menu> CreateMenuAsync(Menu menu)
		{
			throw new System.NotImplementedException();
		}

		public Task DeleteMenuAsync(int id)
		{
			throw new System.NotImplementedException();
		}

		public Task<Menu> EditMenuAsync(int id, Menu menu)
		{
			throw new System.NotImplementedException();
		}

		public Task<Menu> GetMenuAsync(int id)
		{
			throw new System.NotImplementedException();
		}

		public IQueryable<Menu> GetMenus()
		{
			return this.context.Menus;
		}
	}
}