using Dal;
using DomainModelBurger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBurger.Repository
{
	public class RepositoryBeverage : IRepositoryBeverage
	{
		private BurgerContext context;

		public RepositoryBeverage(BurgerContext context)
		{
			this.context = context;
		}

		public IQueryable<Beverage> GetSides()
		{
			return context.Beverages;
		}
	}
}