using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Exowatch.Data;
using Exowatch.Models;
using Microsoft.AspNetCore.Authorization;

namespace Exowatch.Controllers
{
	[Route("api/[controller]"), Authorize]
	[ApiController]
	public class AreasController : ControllerBase
	{
		private readonly DataContext _context;

		public AreasController(DataContext context)
		{
			_context = context;
		}

		// GET: api/Areas
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Area>>> GetAreas()
		{
			return await _context.Areas
				.Include(a => a.Temperatures)
				.Include(a => a.Air)
				.ToListAsync();
		}

		// GET: api/Areas/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Area>> GetArea(long id)
		{
			var area = await _context.Areas
						.Include(a => a.Temperatures)
						.Include(a => a.Air)
						.FirstOrDefaultAsync(a => a.ID == id);

			if (area == null)
			{
				return NotFound();
			}

			return area;
		}

		// PUT: api/Areas/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutArea(long id, Area area)
		{
			if (id != area.ID)
			{
				return BadRequest();
			}

			_context.Entry(area).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!AreaExists(id))
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

		// POST: api/Areas
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Area>> PostArea(Area area)
		{
			_context.Areas.Add(area);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetArea", new { id = area.ID }, area);
		}

		// DELETE: api/Areas/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteArea(long id)
		{
			var area = await _context.Areas.FindAsync(id);
			if (area == null)
			{
				return NotFound();
			}

			_context.Areas.Remove(area);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool AreaExists(long id)
		{
			return _context.Areas.Any(e => e.ID == id);
		}
	}
}
