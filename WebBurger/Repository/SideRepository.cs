using Dal;
using DomainModelBurger;
using System.Linq;
using System.Threading.Tasks;
using WebBurger.Repository.Contracts;

namespace WebBurger.Repository
{
	public class SideRepository : ISideRepository
	{
		private BurgerContext context;

		public SideRepository(BurgerContext context)
		{
			this.context = context;
		}

		public async Task<Side> CreateSideAsync(Side side)
		{
			context.Sides.Add(side);
			await context.SaveChangesAsync();
			return side;
		}

		public async  Task DeleteSideAsync(int id)
		{
			var side = await context.Sides.FindAsync(id);
			context.Sides.Remove(side);
			context.SaveChanges();
		}

		public async Task<Side> EditSideAsync(int id, Side editedSide)
		{
			var side = context.Sides.Find(id);
			side.Name = editedSide.Name;
			side.Price = editedSide.Price;
			side.Description = editedSide.Description;
			side.StockPiled = editedSide.StockPiled;
			side.Weight = editedSide.Weight;
			side.SaltWeight = editedSide.SaltWeight;
			await context.SaveChangesAsync();

			return context.Sides.Find(id);
		}

		public async Task<Side> GetSideAsync(int id)
		{
			return await context.Sides.FindAsync(id);
		}

		public IQueryable<Side> GetSides()
		{
			return context.Sides;
		}
	}
}