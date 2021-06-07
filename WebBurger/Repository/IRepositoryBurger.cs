using DomainModelBurger;
using System.Linq;

namespace WebBurger.Repository
{
	public interface IRepositoryBurger
	{
		public IQueryable<Burger> GetBurgers();
	}
}