using Dal;
using DomainModelBurger;
using System.Linq;
using System.Threading.Tasks;
using WebBurger.Repository.Contracts;

namespace WebBurger.Repository
{
	public class BurgerRepository : IBurgerRepository
	{
		private BurgerContext context;

		public BurgerRepository(BurgerContext burgerContext)
		{
			context = burgerContext;
		}

		public Burger CreateBurger(Burger burger)
		{
			context.Burgers.Add(burger);
			context.SaveChanges();
			return burger;
		}

		public async Task<Burger> CreateBurgerAsync(Burger burger)
		{
			context.Burgers.Add(burger);
			await context.SaveChangesAsync();
			return burger;
		}

		public void Deleteburger(int id)
		{
			var burger = context.Burgers.Find(id);
			context.Burgers.Remove(burger);
		}

		public async Task DeleteburgerAsync(int id)
		{
			var burger = await context.Burgers.FindAsync(id);
			context.Burgers.Remove(burger);
			context.SaveChanges();
		}

		public Burger EditBurger(int id, Burger editedBurger)
		{
			var burger = context.Burgers.Find(id);
			burger.Name = editedBurger.Name;
			burger.Price = editedBurger.Price;
			burger.Description = editedBurger.Description;
			burger.StockPiled = editedBurger.StockPiled;
			burger.Weight = editedBurger.Weight;
			burger.BeefWeight = editedBurger.BeefWeight;
			context.SaveChanges();

			return context.Burgers.Find(id);
		}

		public async Task<Burger> EditBurgerAsync(int id, Burger editedBurger)
		{
			var burger = context.Burgers.Find(id);
			burger.Name = editedBurger.Name;
			burger.Price = editedBurger.Price;
			burger.Description = editedBurger.Description;
			burger.StockPiled = editedBurger.StockPiled;
			burger.Weight = editedBurger.Weight;
			burger.BeefWeight = editedBurger.BeefWeight;
			await context.SaveChangesAsync();

			return context.Burgers.Find(id);
		}

		public async Task<Burger> GetBurger(int id)
		{
			return await this.context.Burgers.FindAsync(id);
		}

		public IQueryable<Burger> GetBurgers()
		{
			return this.context.Burgers;
		}
	}
}