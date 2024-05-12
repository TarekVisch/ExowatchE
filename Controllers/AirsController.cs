using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Exowatch.Data;
using Exowatch.Models;

namespace Exowatch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirsController : ControllerBase
    {
        private readonly DataContext _context;

        public AirsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Airs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Air>>> GetAir()
        {
            return await _context.Air.ToListAsync();
        }

        // GET: api/Airs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Air>> GetAir(long id)
        {
            var air = await _context.Air.FindAsync(id);

            if (air == null)
            {
                return NotFound();
            }

            return air;
        }

        // PUT: api/Airs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAir(long id, Air air)
        {
            if (id != air.Id)
            {
                return BadRequest();
            }

            _context.Entry(air).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirExists(id))
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

        // POST: api/Airs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Air>> PostAir(Air air)
        {
            _context.Air.Add(air);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAir", new { id = air.Id }, air);
        }

        // DELETE: api/Airs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAir(long id)
        {
            var air = await _context.Air.FindAsync(id);
            if (air == null)
            {
                return NotFound();
            }

            _context.Air.Remove(air);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AirExists(long id)
        {
            return _context.Air.Any(e => e.Id == id);
        }
    }
}
