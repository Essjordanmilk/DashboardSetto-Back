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
    public class ModificacionAdminsController : ControllerBase
    {
        private readonly SETTOContext _context;

        public ModificacionAdminsController(SETTOContext context)
        {
            _context = context;
        }

        // GET: api/ModificacionAdmins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModificacionAdmin>>> GetModificacionAdmins()
        {
          if (_context.ModificacionAdmins == null)
          {
              return NotFound();
          }
            return await _context.ModificacionAdmins.ToListAsync();
        }

        // GET: api/ModificacionAdmins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModificacionAdmin>> GetModificacionAdmin(int id)
        {
          if (_context.ModificacionAdmins == null)
          {
              return NotFound();
          }
            var modificacionAdmin = await _context.ModificacionAdmins.FindAsync(id);

            if (modificacionAdmin == null)
            {
                return NotFound();
            }

            return modificacionAdmin;
        }

        // PUT: api/ModificacionAdmins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModificacionAdmin(int id, ModificacionAdmin modificacionAdmin)
        {
            if (id != modificacionAdmin.Id)
            {
                return BadRequest();
            }

            _context.Entry(modificacionAdmin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModificacionAdminExists(id))
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

        // POST: api/ModificacionAdmins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ModificacionAdmin>> PostModificacionAdmin(ModificacionAdmin modificacionAdmin)
        {
          if (_context.ModificacionAdmins == null)
          {
              return Problem("Entity set 'SETTOContext.ModificacionAdmins'  is null.");
          }
            _context.ModificacionAdmins.Add(modificacionAdmin);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ModificacionAdminExists(modificacionAdmin.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetModificacionAdmin", new { id = modificacionAdmin.Id }, modificacionAdmin);
        }

        // DELETE: api/ModificacionAdmins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModificacionAdmin(int id)
        {
            if (_context.ModificacionAdmins == null)
            {
                return NotFound();
            }
            var modificacionAdmin = await _context.ModificacionAdmins.FindAsync(id);
            if (modificacionAdmin == null)
            {
                return NotFound();
            }

            _context.ModificacionAdmins.Remove(modificacionAdmin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModificacionAdminExists(int id)
        {
            return (_context.ModificacionAdmins?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
