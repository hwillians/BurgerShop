using Dal;
using DomainModelBurger;
using System.Linq;
using System.Threading.Tasks;
using WebSide.Repository;

namespace WebBurger.Repository
{
	public class RepositorySide : IRepositorySide
	{
		private BurgerContext context;

		public RepositorySide(BurgerContext context)
		{
			this.context = context;
		}

		public Task<Side> CreateSideAsync(Side side)
		{
			throw new System.NotImplementedException();
		}

		public Task DeleteSideAsync(int id)
		{
			throw new System.NotImplementedException();
		}

		public Task<Side> EditSideAsync(int id, Side side)
		{
			throw new System.NotImplementedException();
		}

		public Task<Side> GetSideAsync(int id)
		{
			throw new System.NotImplementedException();
		}

		public IQueryable<Side> GetSides()
		{
			return context.Sides;
		}
	}
}