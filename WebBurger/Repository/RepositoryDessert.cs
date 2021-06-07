using Dal;
using DomainModelBurger;
using System.Linq;

namespace WebBurger.Repository
{
	public class RepositoryDessert : IRepositoryDessert
	{
		private BurgerContext context;

		public RepositoryDessert(BurgerContext context)
		{
			this.context = context;
		}

		public IQueryable<Dessert> GetDesserts()
		{
			return this.context.Desserts;
		}
	}
}