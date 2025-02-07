﻿using Dal;
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
	public class BurgersController : ControllerBase
	{
		private readonly BurgerContext _context;

		public BurgersController(BurgerContext context)
		{
			_context = context;
		}

		// GET: api/Burgers
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Burger>>> GetBurgers()
		{
			return await _context.Burgers.ToListAsync();
		}

		// GET: api/Burgers/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Burger>> GetBurger(int id)
		{
			var burger = await _context.Burgers.FindAsync(id);

			if (burger == null)
			{
				return NotFound();
			}

			return burger;
		}

		// PUT: api/Burgers/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutBurger(int id, Burger burger)
		{
			if (id != burger.ProductId)
			{
				return BadRequest();
			}

			_context.Entry(burger).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!BurgerExists(id))
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

		// POST: api/Burgers
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Burger>> PostBurger(Burger burger)
		{
			_context.Burgers.Add(burger);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetBurger", new { id = burger.ProductId }, burger);
		}

		// DELETE: api/Burgers/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteBurger(int id)
		{
			var burger = await _context.Burgers.FindAsync(id);
			if (burger == null)
			{
				return NotFound();
			}

			_context.Burgers.Remove(burger);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool BurgerExists(int id)
		{
			return _context.Burgers.Any(e => e.ProductId == id);
		}
	}
}