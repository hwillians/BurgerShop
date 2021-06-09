using Dal;
using DomainModelBurger;
using System.Linq;
using WebBurger.Repository.Contracts;

namespace WebBurger.Repository
{
	public class BeverageRepository : IBeverageRepository
	{
		private readonly BurgerContext context;

		public BeverageRepository(BurgerContext contextBurger)
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
			context.SaveChanges();
		}

		public Beverage EditBeverage(int id, Beverage editedBeverage)
		{
			var beverage = context.Beverages.Find(id);
			beverage.Name = editedBeverage.Name;
			beverage.Price = editedBeverage.Price;
			beverage.Description = editedBeverage.Description;
			beverage.StockPiled = editedBeverage.StockPiled;
			beverage.Millimeter = editedBeverage.Millimeter;
			beverage.IsCarbonated = editedBeverage.IsCarbonated;
			context.SaveChanges();

			return context.Beverages.Find(id);
		}

		public Beverage GetBeverage(int id)
		{
			return context.Beverages.Find(id);
		}

		public IQueryable<Beverage> GetBeverages()
		{
			return context.Beverages;
		}
	}
}