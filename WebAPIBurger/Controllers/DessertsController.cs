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
    public class DessertsController : ControllerBase
    {
        private readonly BurgerContext _context;

        public DessertsController(BurgerContext context)
        {
            _context = context;
        }

        // GET: api/Desserts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dessert>>> GetDesserts()
        {
            return await _context.Desserts.ToListAsync();
        }

        // GET: api/Desserts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dessert>> GetDessert(int id)
        {
            var dessert = await _context.Desserts.FindAsync(id);

            var dessert = await _context.Desserts
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (dessert == null)
            {
                return NotFound();
            }

            return dessert;
        }

        // PUT: api/Desserts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDessert(int id, Dessert dessert)
        {
            if (id != dessert.ProductId)
            {
                return BadRequest();
        }

            _context.Entry(dessert).State = EntityState.Modified;

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
                if (!DessertExists(id))
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
            return View(dessert);
        }

        // POST: api/Desserts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dessert>> PostDessert(Dessert dessert)
            {
            _context.Desserts.Add(dessert);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDessert", new { id = dessert.ProductId }, dessert);
            }

        // DELETE: api/Desserts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDessert(int id)
        {
            var dessert = await _context.Desserts.FindAsync(id);
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

            return NoContent();
        }

        private bool DessertExists(int id)
        {
            return _context.Desserts.Any(e => e.ProductId == id);
        }
    }
}
