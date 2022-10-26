using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuardiumsController : ControllerBase
    {
        private readonly SETTOContext _context;

        public GuardiumsController(SETTOContext context)
        {
            _context = context;
        }

        // GET: api/Guardiums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guardium>>> GetGuardia()
        {
          if (_context.Guardia == null)
          {
              return NotFound();
          }
            return await _context.Guardia.ToListAsync();
        }

        // GET: api/Guardiums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Guardium>> GetGuardium(int id)
        {
          if (_context.Guardia == null)
          {
              return NotFound();
          }
            var guardium = await _context.Guardia.FindAsync(id);

            if (guardium == null)
            {
                return NotFound();
            }

            return guardium;
        }

        // PUT: api/Guardiums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuardium(int id, Guardium guardium)
        {
            if (id != guardium.Id)
            {
                return BadRequest();
            }

            _context.Entry(guardium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuardiumExists(id))
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

        // POST: api/Guardiums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Guardium>> PostGuardium(Guardium guardium)
        {
          if (_context.Guardia == null)
          {
              return Problem("Entity set 'SETTOContext.Guardia'  is null.");
          }
            _context.Guardia.Add(guardium);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GuardiumExists(guardium.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGuardium", new { id = guardium.Id }, guardium);
        }

        // DELETE: api/Guardiums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuardium(int id)
        {
            if (_context.Guardia == null)
            {
                return NotFound();
            }
            var guardium = await _context.Guardia.FindAsync(id);
            if (guardium == null)
            {
                return NotFound();
            }

            _context.Guardia.Remove(guardium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GuardiumExists(int id)
        {
            return (_context.Guardia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
