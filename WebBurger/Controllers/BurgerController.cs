using DomainModelBurger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebBurger.Repository;

namespace WebBurger.Controllers
{
	public class BurgerController : Controller
	{
		private readonly IRepositoryBurger repository;

		public BurgerController(IRepositoryBurger repositoryBurger)
		{
			repository = repositoryBurger;
		}

		// GET: BurgerController
		public async Task<IActionResult> Index()
		{
			var burgers = await repository.GetBurgers().ToListAsync();
			return View(burgers);
		}

		// GET: BurgerController/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
				return BadRequest();

			var burger = await repository.GetBurger(id.Value);
			if (burger == null)
				return NotFound();

			
			return View(burger);
		}

		// GET: BurgerController/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: BurgerController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Burger burger)
		{
			if (ModelState.IsValid)
			{
				var b = await repository.CreateBurgerAsync(burger);
				return RedirectToAction(nameof(Details), b.ProductId);
			}
			return View(burger);
		}

		// GET: BurgerController/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
				return BadRequest();

			var burger = await repository.GetBurger(id.Value);
			if (burger == null)
				return NotFound();


			return View(burger);
		}

		// POST: BurgerController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, Burger burger)
		{
			if (ModelState.IsValid)
			{
				var b = await repository.EditBurgerAsync(id, burger);
				return RedirectToAction(nameof(Details), b.ProductId);
			}
			return View(burger);
		}

		// GET: BurgerController/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
				return BadRequest();

			var burger = await repository.GetBurger(id.Value);
			if (burger == null)
				return NotFound();


			return View(burger);
		}

		// POST: BurgerController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ActionName("Delete")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			await repository.DeleteburgerAsync(id);
			return View();
		}
	}
}