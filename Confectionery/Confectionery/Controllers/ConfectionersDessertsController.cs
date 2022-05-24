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
    public class ConfectionersDessertsController : ControllerBase
    {
        private readonly ConfectioneryAPIContext _context;

        public ConfectionersDessertsController(ConfectioneryAPIContext context)
        {
            _context = context;
        }

        // GET: api/ConfectionersDesserts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConfectionersDessert>>> GetConfectionersDesserts()
        {
          if (_context.ConfectionersDesserts == null)
          {
              return NotFound();
          }
            return await _context.ConfectionersDesserts.ToListAsync();
        }

        // GET: api/ConfectionersDesserts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConfectionersDessert>> GetConfectionersDessert(int id)
        {
          if (_context.ConfectionersDesserts == null)
          {
              return NotFound();
          }
            var confectionersDessert = await _context.ConfectionersDesserts.FindAsync(id);

            if (confectionersDessert == null)
            {
                return NotFound();
            }

            return confectionersDessert;
        }

        // PUT: api/ConfectionersDesserts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfectionersDessert(int id, ConfectionersDessert confectionersDessert)
        {
            if (id != confectionersDessert.Id)
            {
                return BadRequest();
            }

            //if (!IsUnique(confectionersDessert.ConfectionerId, confectionersDessert.DessertId))
            //    return Problem("Entity already exists.");

            _context.Entry(confectionersDessert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfectionersDessertExists(id))
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

        // POST: api/ConfectionersDesserts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConfectionersDessert>> PostConfectionersDessert(ConfectionersDessert confectionersDessert)
        {
          if (_context.ConfectionersDesserts == null)
          {
              return Problem("Entity set 'ConfectioneryAPIContext.ConfectionersDesserts'  is null.");
          }
            if (!IsUnique(confectionersDessert.ConfectionerId, confectionersDessert.DessertId))
                return Problem("Entity already exists.");

            _context.ConfectionersDesserts.Add(confectionersDessert);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConfectionersDessert", new { id = confectionersDessert.Id }, confectionersDessert);
        }
        bool IsUnique(int empId, int posId)
        {
            var q1 = _context.ConfectionersDesserts.Where(e => e.ConfectionerId == empId && e.DessertId == posId).ToList();
            if (q1.Count() == 0) { return true; }
            return false;
        }

        // DELETE: api/ConfectionersDesserts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfectionersDessert(int id)
        {
            if (_context.ConfectionersDesserts == null)
            {
                return NotFound();
            }
            var confectionersDessert = await _context.ConfectionersDesserts.FindAsync(id);
            if (confectionersDessert == null)
            {
                return NotFound();
            }

            _context.ConfectionersDesserts.Remove(confectionersDessert);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConfectionersDessertExists(int id)
        {
            return (_context.ConfectionersDesserts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
