using DomainModelBurger;
using System.Linq;
using System.Threading.Tasks;

namespace WebSide.Repository
{
	public interface IRepositorySide
	{
		public IQueryable<Side> GetSides();

		public Task<Side> GetSideAsync(int id);

		public Task<Side> CreateSideAsync(Side side);

		public Task<Side> EditSideAsync(int id, Side side);

		public Task DeleteSideAsync(int id);
	}
}