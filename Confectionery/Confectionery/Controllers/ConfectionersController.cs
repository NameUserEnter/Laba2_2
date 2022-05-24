using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Confectionery.Models;

namespace Confectionery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfectionersController : ControllerBase
    {
        private readonly ConfectioneryAPIContext _context;

        public ConfectionersController(ConfectioneryAPIContext context)
        {
            _context = context;
        }

        // GET: api/Confectioners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Confectioner>>> GetConfectioners()
        {
          if (_context.Confectioners == null)
          {
              return NotFound();
          }
            return await _context.Confectioners.ToListAsync();
        }

        // GET: api/Confectioners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Confectioner>> GetConfectioner(int id)
        {
          if (_context.Confectioners == null)
          {
              return NotFound();
          }
            var confectioner = await _context.Confectioners.FindAsync(id);

            if (confectioner == null)
            {
                return NotFound();
            }

            return confectioner;
        }

        // PUT: api/Confectioners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfectioner(int id, Confectioner confectioner)
        {
            if (id != confectioner.Id)
            {
                return BadRequest();
            }
            //if (!IsUnique(confectioner.Name))
            //    return Problem("Entity already exists.");

            _context.Entry(confectioner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfectionerExists(id))
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

        // POST: api/Confectioners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Confectioner>> PostConfectioner(Confectioner confectioner)
        {
          if (_context.Confectioners == null)
          {
              return Problem("Entity set 'ConfectioneryAPIContext.Confectioners'  is null.");
          }
            if (!IsUnique(confectioner.Name))
                return Problem("Entity already exists.");

            _context.Confectioners.Add(confectioner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConfectioner", new { id = confectioner.Id }, confectioner);
        }
        bool IsUnique(string title)
        {
            var q = (from serv in _context.Confectioners
                     where serv.Name == title
                     select serv).ToList();
            if (q.Count == 0) { return true; }
            return false;
        }

        // DELETE: api/Confectioners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfectioner(int id)
        {
            if (_context.Confectioners == null)
            {
                return NotFound();
            }
            var confectioner = await _context.Confectioners.FindAsync(id);
            if (confectioner == null)
            {
                return NotFound();
            }
            var cds = _context.ConfectionersDesserts.Where(c => c.ConfectionerId == id).ToList();
            if (cds.Count() > 0)
            {
                foreach (var cd in cds)
                {
                    _context.ConfectionersDesserts.Remove(cd);
                    await _context.SaveChangesAsync();
                }
            }
            _context.Confectioners.Remove(confectioner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConfectionerExists(int id)
        {
            return (_context.Confectioners?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
