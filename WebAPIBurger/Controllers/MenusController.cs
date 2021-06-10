using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dal;
using DomainModelBurger;

namespace WebAPIBurger.Controllers
{
    public class MenusController : Controller
    {
        private readonly BurgerContext _context;

        public MenusController(BurgerContext context)
        {
            _context = context;
        }

        // GET: Menus
        public async Task<IActionResult> Index()
        {
            var burgerContext = _context.Menus.Include(m => m.Beverage).Include(m => m.Burger).Include(m => m.Dessert).Include(m => m.Side);
            return View(await burgerContext.ToListAsync());
        }

        // GET: Menus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .Include(m => m.Beverage)
                .Include(m => m.Burger)
                .Include(m => m.Dessert)
                .Include(m => m.Side)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // GET: Menus/Create
        public IActionResult Create()
        {
            ViewData["BeverageProductId"] = new SelectList(_context.Beverages, "ProductId", "Description");
            ViewData["BurgerProductId"] = new SelectList(_context.Burgers, "ProductId", "Description");
            ViewData["DessertProductId"] = new SelectList(_context.Desserts, "ProductId", "Description");
            ViewData["SideProductId"] = new SelectList(_context.Sides, "ProductId", "Description");
            return View();
        }

        // POST: Menus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BurgerProductId,BeverageProductId,SideProductId,DessertProductId,ProductId,Name,Price,Description,StockPiled")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BeverageProductId"] = new SelectList(_context.Beverages, "ProductId", "Description", menu.BeverageProductId);
            ViewData["BurgerProductId"] = new SelectList(_context.Burgers, "ProductId", "Description", menu.BurgerProductId);
            ViewData["DessertProductId"] = new SelectList(_context.Desserts, "ProductId", "Description", menu.DessertProductId);
            ViewData["SideProductId"] = new SelectList(_context.Sides, "ProductId", "Description", menu.SideProductId);
            return View(menu);
        }

        // GET: Menus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }
            ViewData["BeverageProductId"] = new SelectList(_context.Beverages, "ProductId", "Description", menu.BeverageProductId);
            ViewData["BurgerProductId"] = new SelectList(_context.Burgers, "ProductId", "Description", menu.BurgerProductId);
            ViewData["DessertProductId"] = new SelectList(_context.Desserts, "ProductId", "Description", menu.DessertProductId);
            ViewData["SideProductId"] = new SelectList(_context.Sides, "ProductId", "Description", menu.SideProductId);
            return View(menu);
        }

        // POST: Menus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BurgerProductId,BeverageProductId,SideProductId,DessertProductId,ProductId,Name,Price,Description,StockPiled")] Menu menu)
        {
            if (id != menu.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(menu.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BeverageProductId"] = new SelectList(_context.Beverages, "ProductId", "Description", menu.BeverageProductId);
            ViewData["BurgerProductId"] = new SelectList(_context.Burgers, "ProductId", "Description", menu.BurgerProductId);
            ViewData["DessertProductId"] = new SelectList(_context.Desserts, "ProductId", "Description", menu.DessertProductId);
            ViewData["SideProductId"] = new SelectList(_context.Sides, "ProductId", "Description", menu.SideProductId);
            return View(menu);
        }

        // GET: Menus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .Include(m => m.Beverage)
                .Include(m => m.Burger)
                .Include(m => m.Dessert)
                .Include(m => m.Side)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // POST: Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuExists(int id)
        {
            return _context.Menus.Any(e => e.ProductId == id);
        }
    }
}
