using Dal;
using DomainModelBurger;
using System.Linq;

namespace WebBurger.Repository
{
	public class RepositorySide : IRepositorySide
	{
		private BurgerContext context;

		public RepositorySide(BurgerContext context)
		{
			this.context = context;
		}

		public IQueryable<Side> GetSides()
		{
			return context.Sides;
		}
	}
}