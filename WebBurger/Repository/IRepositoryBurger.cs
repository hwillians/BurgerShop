using DomainModelBurger;
using System.Linq;
using System.Threading.Tasks;

namespace WebBurger.Repository
{
	public interface IRepositoryBurger
	{
		public IQueryable<Burger> GetBurgers();

		public Task<Burger> GetBurger(int id);

		public Burger CreateBurger(Burger burger);

		public Burger EditBurger(int id, Burger burger);

		public void Deleteburger(int id);

		public Task<Burger> CreateBurgerAsync(Burger burger);

		public Task<Burger> EditBurgerAsync(int id, Burger burger);

		public Task DeleteburgerAsync(int id);
	}
}