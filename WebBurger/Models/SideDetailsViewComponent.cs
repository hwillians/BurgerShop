using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebBurger.Repository.Contracts;

namespace WebBurger.Models
{
	public class SideDetailsViewComponent : ViewComponent
	{
		private readonly ISideRepository repository;

		public SideDetailsViewComponent(ISideRepository sideRepository)
		{
			repository = sideRepository;
		}

		public IViewComponentResult Invoke() =>
			 View(repository.GetSides().ToList());
	}
}