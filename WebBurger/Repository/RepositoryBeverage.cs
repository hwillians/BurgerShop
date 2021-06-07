using Dal;
using DomainModelBurger;
using System.Linq;

namespace WebBurger.Repository
{
	public class RepositoryBeverage : IRepositoryBeverage
	{
		private BurgerContext context;

		public RepositoryBeverage(BurgerContext context)
		{
			this.context = context;
		}

		public IQueryable<Beverage> GetBeverages()
		{
			return context.Beverages;
		}
	}
}