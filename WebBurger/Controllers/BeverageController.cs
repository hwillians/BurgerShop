using DomainModelBurger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBurger.Repository;

namespace WebBurger.Controllers
{
	public class BeverageController : Controller
	{
		private readonly IRepositoryBeverage repository;

		public BeverageController(IRepositoryBeverage repositoryBeverage)
		{
			repository = repositoryBeverage;
		}

		// GET: Beverage
		public IActionResult Index()
		{
			return View(repository.GetBeverages());
		}

		// GET: Beverage/Details/5
		public IActionResult Details(int id)
		{
			return View(repository.GetBeverage(id));
		}

		// GET: Beverage/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Beverage/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Beverage beverage)
		{
			if (ModelState.IsValid)
			{
				var b = repository.CreateBeverage(beverage);
				return RedirectToAction(nameof(Details), b.ProductId);
			}

			return View(beverage);
		}

		// GET: Beverage/Edit/5
		public IActionResult Edit(int id)
		{
			return View();
		}

		// POST: Beverage/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id, Beverage beverage)
		{
			if (ModelState.IsValid)
			{
				var b = repository.EditBeverage(id, beverage);
				return RedirectToAction(nameof(Details), b.ProductId);
			}

			return View(beverage);
		}

		// GET: Beverage/Delete/5
		public IActionResult Delete(int id)
		{
			return View();
		}

		// POST: Beverage/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(int id, IFormCollection collection)
		{
			repository.DeleteBeverage(id);
			return View();
		}
	}
}