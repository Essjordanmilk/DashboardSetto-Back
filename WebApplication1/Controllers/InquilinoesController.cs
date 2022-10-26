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
    public class InquilinoesController : ControllerBase
    {
        private readonly SETTOContext _context;

        public InquilinoesController(SETTOContext context)
        {
            _context = context;
        }

        // GET: api/Inquilinoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inquilino>>> GetInquilinos()
        {
          if (_context.Inquilinos == null)
          {
              return NotFound();
          }
            return await _context.Inquilinos.ToListAsync();
        }

        // GET: api/Inquilinoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inquilino>> GetInquilino(int id)
        {
          if (_context.Inquilinos == null)
          {
              return NotFound();
          }
            var inquilino = await _context.Inquilinos.FindAsync(id);

            if (inquilino == null)
            {
                return NotFound();
            }

            return inquilino;
        }

        // PUT: api/Inquilinoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInquilino(int id, Inquilino inquilino)
        {
            if (id != inquilino.DocumentoInqui)
            {
                return BadRequest();
            }

            _context.Entry(inquilino).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InquilinoExists(id))
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

        // POST: api/Inquilinoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inquilino>> PostInquilino(Inquilino inquilino)
        {
          if (_context.Inquilinos == null)
          {
              return Problem("Entity set 'SETTOContext.Inquilinos'  is null.");
          }
            _context.Inquilinos.Add(inquilino);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InquilinoExists(inquilino.DocumentoInqui))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInquilino", new { id = inquilino.DocumentoInqui }, inquilino);
        }

        // DELETE: api/Inquilinoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInquilino(int id)
        {
            if (_context.Inquilinos == null)
            {
                return NotFound();
            }
            var inquilino = await _context.Inquilinos.FindAsync(id);
            if (inquilino == null)
            {
                return NotFound();
            }

            _context.Inquilinos.Remove(inquilino);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InquilinoExists(int id)
        {
            return (_context.Inquilinos?.Any(e => e.DocumentoInqui == id)).GetValueOrDefault();
        }
    }
}
