using DomainModelBurger;
using System.Linq;

namespace WebBurger.Repository
{
	public interface IRepositoryDessert
	{
		public IQueryable<Dessert> GetDesserts();
	}
}