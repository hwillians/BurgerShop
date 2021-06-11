using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dal;
using DomainModelBurger;

namespace WebAPIBurger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly BurgerContext _context;

        public MenusController(BurgerContext context)
        {
            _context = context;
        }

        // GET: api/Menus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menu>>> GetMenus()
        {
            return await _context.Menus
                .Include(m=>m.Burger)
                .Include(m=>m.Beverage)
                .Include(m=>m.Dessert)
                .Include(m=>m.Side)
                .ToListAsync();
        }

        // GET: api/Menus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Menu>> GetMenu(int id)
        {
            var menu = await _context.Menus.FindAsync(id);

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

            return menu;
        }

        // PUT: api/Menus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenu(int id, Menu menu)
        {
            if (id != menu.ProductId)
        {
                return BadRequest();
            }
            ViewData["BeverageProductId"] = new SelectList(_context.Beverages, "ProductId", "Description", menu.BeverageProductId);
            ViewData["BurgerProductId"] = new SelectList(_context.Burgers, "ProductId", "Description", menu.BurgerProductId);
            ViewData["DessertProductId"] = new SelectList(_context.Desserts, "ProductId", "Description", menu.DessertProductId);
            ViewData["SideProductId"] = new SelectList(_context.Sides, "ProductId", "Description", menu.SideProductId);
            return View(menu);
        }

            _context.Entry(menu).State = EntityState.Modified;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                if (!MenuExists(id))
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

            return NoContent();
        }

        // POST: api/Menus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Menu>> PostMenu(Menu menu)
            {
            _context.Menus.Add(menu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenu", new { id = menu.ProductId }, menu);
            }

        // DELETE: api/Menus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
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

            return NoContent();
        }

        private bool MenuExists(int id)
        {
            return _context.Menus.Any(e => e.ProductId == id);
        }
    }
}
