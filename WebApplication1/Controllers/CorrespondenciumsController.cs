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
    public class CorrespondenciumsController : ControllerBase
    {
        private readonly SETTOContext _context;

        public CorrespondenciumsController(SETTOContext context)
        {
            _context = context;
        }

        // GET: api/Correspondenciums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Correspondencium>>> GetCorrespondencia()
        {
          if (_context.Correspondencia == null)
          {
              return NotFound();
          }
            return await _context.Correspondencia.ToListAsync();
        }

        // GET: api/Correspondenciums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Correspondencium>> GetCorrespondencium(int id)
        {
          if (_context.Correspondencia == null)
          {
              return NotFound();
          }
            var correspondencium = await _context.Correspondencia.FindAsync(id);

            if (correspondencium == null)
            {
                return NotFound();
            }

            return correspondencium;
        }

        // PUT: api/Correspondenciums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCorrespondencium(int id, Correspondencium correspondencium)
        {
            if (id != correspondencium.IdCorrespondencia)
            {
                return BadRequest();
            }

            _context.Entry(correspondencium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CorrespondenciumExists(id))
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

        // POST: api/Correspondenciums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Correspondencium>> PostCorrespondencium(Correspondencium correspondencium)
        {
          if (_context.Correspondencia == null)
          {
              return Problem("Entity set 'SETTOContext.Correspondencia'  is null.");
          }
            _context.Correspondencia.Add(correspondencium);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CorrespondenciumExists(correspondencium.IdCorrespondencia))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCorrespondencium", new { id = correspondencium.IdCorrespondencia }, correspondencium);
        }

        // DELETE: api/Correspondenciums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCorrespondencium(int id)
        {
            if (_context.Correspondencia == null)
            {
                return NotFound();
            }
            var correspondencium = await _context.Correspondencia.FindAsync(id);
            if (correspondencium == null)
            {
                return NotFound();
            }

            _context.Correspondencia.Remove(correspondencium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CorrespondenciumExists(int id)
        {
            return (_context.Correspondencia?.Any(e => e.IdCorrespondencia == id)).GetValueOrDefault();
        }
    }
}
