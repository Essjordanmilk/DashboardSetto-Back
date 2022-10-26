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
    public class PerfilesController : ControllerBase
    {
        private readonly SETTOContext _context;

        public PerfilesController(SETTOContext context)
        {
            _context = context;
        }

        // GET: api/Perfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Perfile>>> GetPerfiles()
        {
          if (_context.Perfiles == null)
          {
              return NotFound();
          }
            return await _context.Perfiles.ToListAsync();
        }

        // GET: api/Perfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Perfile>> GetPerfile(int id)
        {
          if (_context.Perfiles == null)
          {
              return NotFound();
          }
            var perfile = await _context.Perfiles.FindAsync(id);

            if (perfile == null)
            {
                return NotFound();
            }

            return perfile;
        }

        // PUT: api/Perfiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerfile(int id, Perfile perfile)
        {
            if (id != perfile.DocumentoPer)
            {
                return BadRequest();
            }

            _context.Entry(perfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfileExists(id))
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

        // POST: api/Perfiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Perfile>> PostPerfile(Perfile perfile)
        {
          if (_context.Perfiles == null)
          {
              return Problem("Entity set 'SETTOContext.Perfiles'  is null.");
          }
            _context.Perfiles.Add(perfile);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PerfileExists(perfile.DocumentoPer))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPerfile", new { id = perfile.DocumentoPer }, perfile);
        }

        // DELETE: api/Perfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerfile(int id)
        {
            if (_context.Perfiles == null)
            {
                return NotFound();
            }
            var perfile = await _context.Perfiles.FindAsync(id);
            if (perfile == null)
            {
                return NotFound();
            }

            _context.Perfiles.Remove(perfile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PerfileExists(int id)
        {
            return (_context.Perfiles?.Any(e => e.DocumentoPer == id)).GetValueOrDefault();
        }
    }
}
