using DomainModelBurger;
using System.Linq;
using System.Threading.Tasks;

namespace WebBurger.Repository.Contracts
{
	public interface IDessertRepository
	{
		public IQueryable<Dessert> GetDesserts();

		public Task<Dessert> GetDessertAsync(int id);

		public Task<Dessert> CreateDessertAsync(Dessert dessert);

		public Task<Dessert> EditDessertAsync(int id, Dessert dessert);

		public Task DeleteDessertAsync(int id);
	}
}