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
    public class BeveragesController : ControllerBase
    {
        private readonly BurgerContext _context;

        public BeveragesController(BurgerContext context)
        {
            _context = context;
        }

        // GET: api/Beverages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beverage>>> GetBeverages()
        {
            return await _context.Beverages.ToListAsync();
        }

        // GET: api/Beverages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Beverage>> GetBeverage(int id)
        {
            var beverage = await _context.Beverages.FindAsync(id);

            var beverage = await _context.Beverages
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (beverage == null)
            {
                return NotFound();
            }

            return beverage;
        }

        // PUT: api/Beverages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeverage(int id, Beverage beverage)
        {
            if (id != beverage.ProductId)
            {
                return BadRequest();
        }

            _context.Entry(beverage).State = EntityState.Modified;

            var beverage = await _context.Beverages.FindAsync(id);
            if (beverage == null)
            {
                return NotFound();
            }
            return View(beverage);
        }

        // POST: Beverages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Millimeter,IsCarbonated,ProductId,Name,Price,Description,StockPiled")] Beverage beverage)
        {
            if (id != beverage.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beverage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                if (!BeverageExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            return NoContent();
            }
            return View(beverage);
        }

        // POST: api/Beverages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Beverage>> PostBeverage(Beverage beverage)
            {
            _context.Beverages.Add(beverage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBeverage", new { id = beverage.ProductId }, beverage);
            }

        // DELETE: api/Beverages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeverage(int id)
        {
            var beverage = await _context.Beverages.FindAsync(id);
            if (beverage == null)
            {
                return NotFound();
            }

            return View(beverage);
        }

        // POST: Beverages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beverage = await _context.Beverages.FindAsync(id);
            _context.Beverages.Remove(beverage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BeverageExists(int id)
        {
            return _context.Beverages.Any(e => e.ProductId == id);
        }
    }
}
