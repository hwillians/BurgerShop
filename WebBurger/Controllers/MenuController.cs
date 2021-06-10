using DomainModelBurger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebBurger.Repository.Contracts;

namespace WebBurger.Controllers
{
	public class MenuController : Controller
	{
		private readonly IMenuRepository repository;
		private readonly IBurgerRepository burgerRepository;
		private readonly IBeverageRepository beverageRepository;
		private readonly IDessertRepository dessertRepository;
		private readonly ISideRepository sideRepository;

		public MenuController(IMenuRepository repositoryMenu,
			IBurgerRepository burgerRepository,
			IBeverageRepository beverageRepository,
			IDessertRepository dessertRepository,
			ISideRepository sideRepository)
		{
			repository = repositoryMenu;
			this.burgerRepository = burgerRepository;
			this.beverageRepository = beverageRepository;
			this.dessertRepository = dessertRepository;
			this.sideRepository = sideRepository;
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
				return BadRequest();

			var menu = await repository.GetMenuAsync(id.Value);
			if (menu == null)
				return NotFound();

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
		public async Task<IActionResult> Create(
			[Bind("Name,Price,Description,StockPiled,BurgerProductId,BeverageProductId,SideProductId,DessertProductId")] Menu menu)
		{

			if (ModelState.IsValid)
			{
				menu.Beverage = beverageRepository.GetBeverage(menu.BeverageProductId);
				menu.Side = await sideRepository.GetSideAsync(menu.SideProductId);
				menu.Burger = await burgerRepository.GetBurger(menu.BurgerProductId);
				if (menu.DessertProductId != null)
					menu.Dessert = await dessertRepository.GetDessertAsync(menu.DessertProductId.Value);

				var m = await repository.CreateMenuAsync(menu);

				return RedirectToAction(nameof(Details), new { id = m.ProductId });
			}
			return View(menu);
		}

		// GET: Menu/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null) return BadRequest();

			var menu = await repository.GetMenuAsync(id.Value);

			if (menu == null) return NotFound();

			return View(menu);
		}

		// POST: Menu/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id,
			[Bind("ProductId,Name,Price,Description,StockPiled,BurgerProductId,BeverageProductId,SideProductId,DessertProductId")] Menu menu)
		{
			if (id != menu.ProductId)
				return NotFound();

			if (ModelState.IsValid)
			{
				menu.Beverage = beverageRepository.GetBeverage(menu.BeverageProductId);
				menu.Side = await sideRepository.GetSideAsync(menu.SideProductId);
				menu.Burger = await burgerRepository.GetBurger(menu.BurgerProductId);
				if (menu.DessertProductId != null)
					menu.Dessert = await dessertRepository.GetDessertAsync(menu.DessertProductId.Value);

				var m = await repository.EditMenuAsync(id, menu);

				return RedirectToAction(nameof(Details), new { id });
			}
			return View(menu);
		}

		// GET: Menu/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
				return BadRequest();

			var menu = await repository.GetMenuAsync(id.Value);
			if (menu == null)
				return NotFound();

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