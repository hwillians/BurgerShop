using DomainModelBurger;
using System.Linq;

namespace WebBurger.Repository
{
	public interface IRepositoryBeverage
	{
		public IQueryable<Beverage> GetBeverages();

		public Beverage GetBeverage(int id);

		public Beverage CreateBeverage(Beverage beverage);

		public Beverage EditBeverage(int id, Beverage beverage);

		public void DeleteBeverage(int id);
	}
}