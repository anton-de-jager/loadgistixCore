using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using loadgistix.Models;

namespace loadgistix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProspectEmploymentTechnologiesController : ControllerBase
    {
        private readonly loadgistixContext _context;

        public ProspectEmploymentTechnologiesController(loadgistixContext context)
        {
            _context = context;
        }

        // GET: api/ProspectEmploymentTechnologies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProspectEmploymentTechnology>>> GetProspectEmploymentTechnology()
        {
            return await _context.ProspectEmploymentTechnology.ToListAsync();
        }

        // GET: api/ProspectEmploymentTechnologies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProspectEmploymentTechnology>> GetProspectEmploymentTechnology(Guid id)
        {
            var prospectEmploymentTechnology = await _context.ProspectEmploymentTechnology.FindAsync(id);

            if (prospectEmploymentTechnology == null)
            {
                return NotFound();
            }

            return prospectEmploymentTechnology;
        }

        // PUT: api/ProspectEmploymentTechnologies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProspectEmploymentTechnology(Guid id, ProspectEmploymentTechnology prospectEmploymentTechnology)
        {
            if (id != prospectEmploymentTechnology.Id)
            {
                return BadRequest();
            }

            _context.Entry(prospectEmploymentTechnology).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProspectEmploymentTechnologyExists(id))
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

        // POST: api/ProspectEmploymentTechnologies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProspectEmploymentTechnology>> PostProspectEmploymentTechnology(ProspectEmploymentTechnology prospectEmploymentTechnology)
        {
            _context.ProspectEmploymentTechnology.Add(prospectEmploymentTechnology);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProspectEmploymentTechnology", new { id = prospectEmploymentTechnology.Id }, prospectEmploymentTechnology);
        }

        // DELETE: api/ProspectEmploymentTechnologies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProspectEmploymentTechnology>> DeleteProspectEmploymentTechnology(Guid id)
        {
            var prospectEmploymentTechnology = await _context.ProspectEmploymentTechnology.FindAsync(id);
            if (prospectEmploymentTechnology == null)
            {
                return NotFound();
            }

            _context.ProspectEmploymentTechnology.Remove(prospectEmploymentTechnology);
            await _context.SaveChangesAsync();

            return prospectEmploymentTechnology;
        }

        private bool ProspectEmploymentTechnologyExists(Guid id)
        {
            return _context.ProspectEmploymentTechnology.Any(e => e.Id == id);
        }
    }
}
