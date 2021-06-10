using Dal;
using DomainModelBurger;
using System.Linq;
using System.Threading.Tasks;
using WebBurger.Repository.Contracts;

namespace WebBurger.Repository
{
	public class DessertRepository : IDessertRepository
	{
		private readonly BurgerContext context;

		public DessertRepository(BurgerContext context)
		{
			this.context = context;
		}

		public async Task<Dessert> CreateDessertAsync(Dessert dessert)
		{
			context.Desserts.Add(dessert);
			await context.SaveChangesAsync();
			return dessert;
		}

		public async Task DeleteDessertAsync(int id)
		{
			var dessert = await context.Desserts.FindAsync(id);
			context.Desserts.Remove(dessert);
			context.SaveChanges();
		}

		public async Task<Dessert> EditDessertAsync(int id, Dessert editedDessert)
		{
			var dessert = context.Desserts.Find(id);
			dessert.Name = editedDessert.Name;
			dessert.Price = editedDessert.Price;
			dessert.Description = editedDessert.Description;
			dessert.StockPiled = editedDessert.StockPiled;
			dessert.Millimeter = editedDessert.Millimeter;
			dessert.IsFrozen = editedDessert.IsFrozen;
			await context.SaveChangesAsync();

			return context.Desserts.Find(id);
		}

		public async Task<Dessert> GetDessertAsync(int id)
		{
			return await context.Desserts.FindAsync(id);
		}

		public IQueryable<Dessert> GetDesserts()
		{
			return context.Desserts;
		}
	}
}