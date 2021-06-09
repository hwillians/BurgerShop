using DomainModelBurger;
using System.Linq;

namespace WebBurger.Repository.Contracts
{
	public interface IBeverageRepository
	{
		public IQueryable<Beverage> GetBeverages();

		public Beverage GetBeverage(int id);

		public Beverage CreateBeverage(Beverage beverage);

		public Beverage EditBeverage(int id, Beverage beverage);

		public void DeleteBeverage(int id);
	}
}