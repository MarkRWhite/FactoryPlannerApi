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
    public class UpgradeProfilesController : ControllerBase
    {
        private readonly FactoryPlannerContext _context;

        public UpgradeProfilesController(FactoryPlannerContext context)
        {
            _context = context;
        }

        // GET: api/UpgradeProfiles
        [HttpGet]
        public IEnumerable<UpgradeProfile> GetUpgradeProfiles()
        {
            return _context.UpgradeProfiles;
        }

        // GET: api/UpgradeProfiles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUpgradeProfile([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var upgradeProfile = await _context.UpgradeProfiles.FindAsync(id);

            if (upgradeProfile == null)
            {
                return NotFound();
            }

            return Ok(upgradeProfile);
        }

        // PUT: api/UpgradeProfiles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUpgradeProfile([FromRoute] int id, [FromBody] UpgradeProfile upgradeProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != upgradeProfile.UpgradeProfileId)
            {
                return BadRequest();
            }

            _context.Entry(upgradeProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UpgradeProfileExists(id))
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

        // POST: api/UpgradeProfiles
        [HttpPost]
        public async Task<IActionResult> PostUpgradeProfile([FromBody] UpgradeProfile upgradeProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UpgradeProfiles.Add(upgradeProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUpgradeProfile", new { id = upgradeProfile.UpgradeProfileId }, upgradeProfile);
        }

        // DELETE: api/UpgradeProfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUpgradeProfile([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var upgradeProfile = await _context.UpgradeProfiles.FindAsync(id);
            if (upgradeProfile == null)
            {
                return NotFound();
            }

            _context.UpgradeProfiles.Remove(upgradeProfile);
            await _context.SaveChangesAsync();

            return Ok(upgradeProfile);
        }

        private bool UpgradeProfileExists(int id)
        {
            return _context.UpgradeProfiles.Any(e => e.UpgradeProfileId == id);
        }
    }
}