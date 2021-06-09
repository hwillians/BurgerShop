using DomainModelBurger;
using System.Collections.Generic;
using System.Linq;
using WebBurger.Repository.Contracts;

namespace WebBurger.Services
{
	public class MenuService
	{
		private readonly IBurgerRepository burgerRepository;
		private readonly IBeverageRepository beverageRepository;
		private readonly IDessertRepository dessertRepository;
		private readonly ISideRepository sideRepository;

		public MenuService(IBurgerRepository burgerRepository,
		IBeverageRepository beverageRepository,
		IDessertRepository dessertRepository,
		ISideRepository sideRepository)
		{
			this.burgerRepository = burgerRepository;
			this.beverageRepository = beverageRepository;
			this.dessertRepository = dessertRepository;
			this.sideRepository = sideRepository;
		}

		public Dictionary<int, string> GetBurgersAsync() =>
			burgerRepository.GetBurgers().ToDictionary(b => b.ProductId, b => b.Name);

		public Dictionary<int, string> GetBeveragesAsync() =>
			beverageRepository.GetBeverages().ToDictionary(b => b.ProductId, b => b.Name);

		public Dictionary<int, string> GetSidesAsync() =>
			sideRepository.GetSides().ToDictionary(b => b.ProductId, b => b.Name);

		public Dictionary<int, string> GetDessertsAsync() =>
			dessertRepository.GetDesserts().ToDictionary(b => b.ProductId, b => b.Name);
	}
}