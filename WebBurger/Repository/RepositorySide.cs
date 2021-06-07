using Dal;
using DomainModelBurger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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