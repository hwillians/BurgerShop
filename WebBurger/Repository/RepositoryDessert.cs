using Dal;
using DomainModelBurger;
using System.Linq;
using System.Threading.Tasks;

namespace WebBurger.Repository
{
	public class RepositoryDessert : IRepositoryDessert
	{
		private BurgerContext context;

		public RepositoryDessert(BurgerContext context)
		{
			this.context = context;
		}

		public Task<Dessert> CreateDessertAsync(Dessert dessert)
		{
			throw new System.NotImplementedException();
		}

		public Task DeleteDessertAsync(int id)
		{
			throw new System.NotImplementedException();
		}

		public Task<Dessert> EditDessertAsync(int id, Dessert dessert)
		{
			throw new System.NotImplementedException();
		}

		public Task<Dessert> GetDessertAsync(int id)
		{
			throw new System.NotImplementedException();
		}

		public IQueryable<Dessert> GetDesserts()
		{
			return this.context.Desserts;
		}
	}
}