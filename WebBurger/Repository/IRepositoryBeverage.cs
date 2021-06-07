using DomainModelBurger;
using System.Linq;

namespace WebBurger.Repository
{
	public interface IRepositoryBeverage
	{
		public IQueryable<Beverage> GetBeverages();
	}
}