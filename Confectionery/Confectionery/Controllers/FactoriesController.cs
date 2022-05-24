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
    public class FactoriesController : ControllerBase
    {
        private readonly ConfectioneryAPIContext _context;

        public FactoriesController(ConfectioneryAPIContext context)
        {
            _context = context;
        }

        // GET: api/Factories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factory>>> GetFactories()
        {
          if (_context.Factories == null)
          {
              return NotFound();
          }
            return await _context.Factories.ToListAsync();
        }

        // GET: api/Factories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Factory>> GetFactory(int id)
        {
          if (_context.Factories == null)
          {
              return NotFound();
          }
            var factory = await _context.Factories.FindAsync(id);

            if (factory == null)
            {
                return NotFound();
            }

            return factory;
        }

        // PUT: api/Factories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactory(int id, Factory factory)
        {
            if (id != factory.Id)
            {
                return BadRequest();
            }
            //if (!IsUnique(factory.Title, factory.Address))
            //    return Problem("Entity already exists.");

            _context.Entry(factory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactoryExists(id))
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

        // POST: api/Factories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Factory>> PostFactory(Factory factory)
        {
          if (_context.Factories == null)
          {
              return Problem("Entity set 'ConfectioneryAPIContext.Factories'  is null.");
          }
          if(!IsUnique(factory.Title, factory.Address))
                return Problem("Entity already exists.");

            _context.Factories.Add(factory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFactory", new { id = factory.Id }, factory);
        }

        bool IsUnique(string title, string address)
        {
            var q = (from br in _context.Factories
                     where br.Title == title || br.Address == address
                     select br).ToList();
            if (q.Count == 0) { return true; }
            return false;
        }

        // DELETE: api/Factories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactory(int id)
        {
            if (_context.Factories == null)
            {
                return NotFound();
            }
            var factory = await _context.Factories.FindAsync(id);
            if (factory == null)
            {
                return NotFound();
            }

            _context.Factories.Remove(factory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FactoryExists(int id)
        {
            return (_context.Factories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
