using Dal;
using DomainModelBurger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIBurger.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class SidesController : ControllerBase
    {
        private readonly BurgerContext _context;

        public SidesController(BurgerContext context)
        {
            _context = context;
        }

        // GET: api/Sides
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Side>>> GetSides()
        {
            return await _context.Sides.ToListAsync();
        }

        // GET: api/Sides/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Side>> GetSide(int id)
        {
            var side = await _context.Sides.FindAsync(id);

            if (side == null)
            {
                return NotFound();
            }

            return side;
        }

        // PUT: api/Sides/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSide(int id, Side side)
        {
            if (id != side.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(side).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SideExists(id))
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

        // POST: api/Sides
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Side>> PostSide(Side side)
        {
            _context.Sides.Add(side);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSide", new { id = side.ProductId }, side);
        }

        // DELETE: api/Sides/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSide(int id)
        {
            var side = await _context.Sides.FindAsync(id);
            if (side == null)
            {
                return NotFound();
            }

            _context.Sides.Remove(side);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SideExists(int id)
        {
            return _context.Sides.Any(e => e.ProductId == id);
        }
    }
}
