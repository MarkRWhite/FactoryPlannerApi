using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FactoryPlannerApi.Models;

namespace FactoryPlannerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoriesController : ControllerBase
    {
        private readonly FactoryPlannerContext _context;

        public FactoriesController(FactoryPlannerContext context)
        {
            _context = context;
        }

        // GET: api/Factories
        [HttpGet]
        public IEnumerable<Factory> GetFactories()
        {
            return _context.Factories;
        }

        // GET: api/Factories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFactory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var factory = await _context.Factories.FindAsync(id);

            if (factory == null)
            {
                return NotFound();
            }

            return Ok(factory);
        }

        // PUT: api/Factories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactory([FromRoute] int id, [FromBody] Factory factory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != factory.FactoryId)
            {
                return BadRequest();
            }

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
        [HttpPost]
        public async Task<IActionResult> PostFactory([FromBody] Factory factory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Factories.Add(factory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFactory", new { id = factory.FactoryId }, factory);
        }

        // DELETE: api/Factories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var factory = await _context.Factories.FindAsync(id);
            if (factory == null)
            {
                return NotFound();
            }

            _context.Factories.Remove(factory);
            await _context.SaveChangesAsync();

            return Ok(factory);
        }

        private bool FactoryExists(int id)
        {
            return _context.Factories.Any(e => e.FactoryId == id);
        }
    }
}