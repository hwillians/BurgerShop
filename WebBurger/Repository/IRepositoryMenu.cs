using DomainModelBurger;
using System.Linq;

namespace WebBurger.Repository
{
	public interface IRepositoryMenu
	{
		public IQueryable<Menu> GetMenus();
	}
}