using DomainModelBurger;
using System.Linq;

namespace WebBurger.Repository
{
	public interface IRepositorySide
	{
		public IQueryable<Side> GetSides();
	}
}