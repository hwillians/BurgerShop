using Dal;
using DomainModelBurger;
using System.Linq;

namespace WebBurger.Repository
{
	public class RepositoryBeverage : IRepositoryBeverage
	{
		private readonly BurgerContext context;

		public RepositoryBeverage(BurgerContext contextBurger)
		{
			context = contextBurger;
		}

		public Beverage CreateBeverage(Beverage beverage)
		{
			context.Beverages.Add(beverage);
			context.SaveChanges();
			return beverage;
		}

		public void DeleteBeverage(int id)
		{
			var beverage = context.Beverages.Find(id);
			context.Beverages.Remove(beverage);
		}

		public Beverage EditBeverage(int id, Beverage Editedbeverage)
		{
			var beverage = context.Beverages.Find(id);
			beverage.Name = Editedbeverage.Name;
			beverage.Price = Editedbeverage.Price;
			beverage.Description = Editedbeverage.Description;
			beverage.StockPiled = Editedbeverage.StockPiled;
			beverage.Millimeter = Editedbeverage.Millimeter;
			beverage.IsCarbonated = Editedbeverage.IsCarbonated;
			context.SaveChanges();

			return context.Beverages.Find(id);
		}

		public IQueryable<Beverage> GetBeverages()
		{
			return context.Beverages;
		}
	}
}