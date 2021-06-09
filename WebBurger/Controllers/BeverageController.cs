using DomainModelBurger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebBurger.Repository;
using WebBurger.Repository.Contracts;

namespace WebBurger.Controllers
{
	public class BeverageController : Controller
	{
		private readonly IBeverageRepository repository;

		public BeverageController(IBeverageRepository repositoryBeverage)
		{
			repository = repositoryBeverage;
		}

		// GET: Beverage
		public IActionResult Index()
		{
			var beverage = repository.GetBeverages().ToList();
			return View(beverage);
		}

		// GET: Beverage/Details/5
		public IActionResult Details(int? id)
		{
			if (id == null)
				return BadRequest();

			var beverage = repository.GetBeverage(id.Value);
			if (beverage == null)
				return NotFound();

			return View(beverage);
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
				return RedirectToAction(nameof(Details), new { id = b.ProductId });
			}

			return View(beverage);
		}

		// GET: Beverage/Edit/5
		public IActionResult Edit(int? id)
		{
			if (id == null)
				return BadRequest();

			var beverage = repository.GetBeverage(id.Value);
			if (beverage == null)
				return NotFound();

			return View(beverage);
		}

		// POST: Beverage/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id, Beverage beverage)
		{
			if (ModelState.IsValid)
			{
				var b = repository.EditBeverage(id, beverage);
				return RedirectToAction(nameof(Details), new { id = b.ProductId });
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
			return RedirectToAction(nameof(Index));
		}
	}
}