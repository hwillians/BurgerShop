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
    public class DessertsController : Controller
    {
        private readonly BurgerContext _context;

        public DessertsController(BurgerContext context)
        {
            _context = context;
        }

        // GET: Desserts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Desserts.ToListAsync());
        }

        // GET: Desserts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dessert = await _context.Desserts
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (dessert == null)
            {
                return NotFound();
            }

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
                _context.Add(dessert);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dessert);
        }

        // GET: Desserts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dessert = await _context.Desserts.FindAsync(id);
            if (dessert == null)
            {
                return NotFound();
            }
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
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dessert);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DessertExists(dessert.ProductId))
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
            return View(dessert);
        }

        // GET: Desserts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dessert = await _context.Desserts
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (dessert == null)
            {
                return NotFound();
            }

            return View(dessert);
        }

        // POST: Desserts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dessert = await _context.Desserts.FindAsync(id);
            _context.Desserts.Remove(dessert);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DessertExists(int id)
        {
            return _context.Desserts.Any(e => e.ProductId == id);
        }
    }
}
