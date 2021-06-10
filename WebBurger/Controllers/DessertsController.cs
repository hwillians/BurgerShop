using Dal;
using DomainModelBurger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebBurger.Repository.Contracts;

namespace WebBurger.Controllers
{
	public class DessertsController : Controller
	{
		private readonly IDessertRepository repository;

		public DessertsController(IDessertRepository repositoryBurger)
		{
			repository = repositoryBurger;
		}

		// GET: Desserts
		public async Task<IActionResult> Index()
		{
			return View(await repository.GetDesserts().ToListAsync());
		}

		// GET: Desserts/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
				return BadRequest();


			var dessert = await repository.GetDessertAsync(id.Value);

			if (dessert == null)
				return NotFound();

			return View(dessert);
		}

		// GET: Desserts/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Desserts/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Millimeter,IsFrozen,ProductId,Name,Price,Description,StockPiled")] Dessert dessert)
		{
			if (ModelState.IsValid)
			{
				var d = await repository.CreateDessertAsync(dessert);
				return RedirectToAction(nameof(Details), new { id = d.ProductId });

			}
			return View(dessert);
		}

		// GET: Desserts/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
				return BadRequest();

			var dessert = await repository.GetDessertAsync(id.Value);
			if (dessert == null)
				return NotFound();

			return View(dessert);
		}

		// POST: Desserts/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Millimeter,IsFrozen,ProductId,Name,Price,Description,StockPiled")] Dessert dessert)
		{
			if (id != dessert.ProductId)
			{
				return BadRequest();
			}

			if (ModelState.IsValid)
			{
				try
				{
					var b = await repository.EditDessertAsync(id, dessert);
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!await DessertExistsAsync(dessert.ProductId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Details), new { id });

			}
			return View(dessert);
		}

		// GET: Desserts/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
				return BadRequest();

			var dessert = await repository.GetDessertAsync(id.Value);

			if (dessert == null)
				return NotFound();

			return View(dessert);
		}

		// POST: Desserts/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await repository.DeleteDessertAsync(id);
			return RedirectToAction(nameof(Index));
		}

		private async Task<bool> DessertExistsAsync(int id)
		{
			if (await repository.GetDessertAsync(id) != null)
				return true;

			return false;
		}
	}
}
