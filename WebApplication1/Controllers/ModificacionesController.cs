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
    public class ModificacionesController : ControllerBase
    {
        private readonly SETTOContext _context;

        public ModificacionesController(SETTOContext context)
        {
            _context = context;
        }

        // GET: api/Modificaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modificacione>>> GetModificaciones()
        {
          if (_context.Modificaciones == null)
          {
              return NotFound();
          }
            return await _context.Modificaciones.ToListAsync();
        }

        // GET: api/Modificaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Modificacione>> GetModificacione(int id)
        {
          if (_context.Modificaciones == null)
          {
              return NotFound();
          }
            var modificacione = await _context.Modificaciones.FindAsync(id);

            if (modificacione == null)
            {
                return NotFound();
            }

            return modificacione;
        }

        // PUT: api/Modificaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModificacione(int id, Modificacione modificacione)
        {
            if (id != modificacione.Id)
            {
                return BadRequest();
            }

            _context.Entry(modificacione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModificacioneExists(id))
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

        // POST: api/Modificaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Modificacione>> PostModificacione(Modificacione modificacione)
        {
          if (_context.Modificaciones == null)
          {
              return Problem("Entity set 'SETTOContext.Modificaciones'  is null.");
          }
            _context.Modificaciones.Add(modificacione);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ModificacioneExists(modificacione.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetModificacione", new { id = modificacione.Id }, modificacione);
        }

        // DELETE: api/Modificaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModificacione(int id)
        {
            if (_context.Modificaciones == null)
            {
                return NotFound();
            }
            var modificacione = await _context.Modificaciones.FindAsync(id);
            if (modificacione == null)
            {
                return NotFound();
            }

            _context.Modificaciones.Remove(modificacione);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModificacioneExists(int id)
        {
            return (_context.Modificaciones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
