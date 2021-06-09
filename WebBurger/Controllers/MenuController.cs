using DomainModelBurger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebBurger.Repository;
using WebBurger.Repository.Contracts;

namespace WebBurger.Controllers
{
	public class MenuController : Controller
	{
		private readonly IMenuRepository repository;

		public MenuController(IMenuRepository repositoryMenu)
		{
			repository = repositoryMenu;
		}

		// GET: Menu
		public async Task<IActionResult> Index()
		{
			return View(await repository.GetMenus().ToListAsync());
		}

		// GET: Menu/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return BadRequest();
			}

			var menu = await repository.GetMenuAsync(id.Value);
			if (menu == null)
			{
				return NotFound();
			}

			return View(menu);
		}

		// GET: Menu/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Menu/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("ProductId,Name,Price,Description,StockPiled")] Menu menu)
		{
			if (ModelState.IsValid)
			{
				var m = await repository.CreateMenuAsync(menu);

				return RedirectToAction(nameof(Details), m.ProductId);
			}
			return View(menu);
		}

		// GET: Menu/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return BadRequest();
			}

			var menu = await repository.GetMenuAsync(id.Value);
			if (menu == null)
			{
				return NotFound();
			}
			return View(menu);
		}

		// POST: Menu/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, Menu menu)
		{
			if (id != menu.ProductId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				var m = await repository.EditMenuAsync(id, menu);
				return RedirectToAction(nameof(Details), m.ProductId);
			}
			return View(menu);
		}

		// GET: Menu/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return BadRequest();
			}

			var menu = await repository.GetMenuAsync(id.Value);
			if (menu == null)
			{
				return NotFound();
			}

			return View(menu);
		}

		// POST: Menu/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await repository.DeleteMenuAsync(id);
			return View();
		}
	}
}