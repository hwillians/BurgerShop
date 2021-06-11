using DomainModelBurger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebBurger.Repository.Contracts;

namespace WebBurger.Controllers
{
	public class SidesController : Controller
	{
		private readonly ISideRepository repository;

		public SidesController(ISideRepository repositoryBurger)
		{
			repository = repositoryBurger;
		}

		// GET: Sides
		public async Task<IActionResult> Index()
		{
			return View(await repository.GetSides().ToListAsync());
		}

		// GET: Sides/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
				return BadRequest();

			var side = await repository.GetSideAsync(id.Value);

			if (side == null)
				return NotFound();

			return View(side);
		}

		// GET: Sides/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Sides/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Weight,SaltWeight,ProductId,Name,Price,Description,StockPiled")] Side side)
		{
			if (ModelState.IsValid)
			{
				var d = await repository.CreateSideAsync(side);
				return RedirectToAction(nameof(Details), new { id = d.ProductId });
			}

			return View(side);
		}

		// GET: Sides/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
				return BadRequest();

			var side = await repository.GetSideAsync(id.Value);
			if (side == null)
				return NotFound();

			return View(side);
		}

		// POST: Sides/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Weight,SaltWeight,ProductId,Name,Price,Description,StockPiled")] Side side)
		{
			if (id != side.ProductId)
				return BadRequest();

			if (ModelState.IsValid)
			{
				try
				{
					var b = await repository.EditSideAsync(id, side);
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!await SideExistsAsync(side.ProductId))
						return NotFound();
					else
						throw;
				}
				return RedirectToAction(nameof(Details), new { id });
			}
			return View(side);
		}

		// GET: Sides/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
				return BadRequest();

			var side = await repository.GetSideAsync(id.Value);

			if (side == null)
				return NotFound();

			return View(side);
		}

		// POST: Sides/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await repository.DeleteSideAsync(id);
			return RedirectToAction(nameof(Index));
		}

		private async Task<bool> SideExistsAsync(int id)
		{
			if (await repository.GetSideAsync(id) != null)
				return true;

			return false;
		}
	}
}