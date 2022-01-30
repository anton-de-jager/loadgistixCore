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
    public class ProspectEmploymentsController : ControllerBase
    {
        private readonly loadgistixContext _context;

        public ProspectEmploymentsController(loadgistixContext context)
        {
            _context = context;
        }

        // GET: api/ProspectEmployments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProspectEmployment>>> GetProspectEmployment()
        {
            return await _context.ProspectEmployment.ToListAsync();
        }

        // GET: api/ProspectEmployments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProspectEmployment>> GetProspectEmployment(Guid id)
        {
            var prospectEmployment = await _context.ProspectEmployment.FindAsync(id);

            if (prospectEmployment == null)
            {
                return NotFound();
            }

            return prospectEmployment;
        }

        // PUT: api/ProspectEmployments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProspectEmployment(Guid id, ProspectEmployment prospectEmployment)
        {
            if (id != prospectEmployment.Id)
            {
                return BadRequest();
            }

            _context.Entry(prospectEmployment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProspectEmploymentExists(id))
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

        // POST: api/ProspectEmployments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProspectEmployment>> PostProspectEmployment(ProspectEmployment prospectEmployment)
        {
            _context.ProspectEmployment.Add(prospectEmployment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProspectEmployment", new { id = prospectEmployment.Id }, prospectEmployment);
        }

        // DELETE: api/ProspectEmployments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProspectEmployment>> DeleteProspectEmployment(Guid id)
        {
            var prospectEmployment = await _context.ProspectEmployment.FindAsync(id);
            if (prospectEmployment == null)
            {
                return NotFound();
            }

            _context.ProspectEmployment.Remove(prospectEmployment);
            await _context.SaveChangesAsync();

            return prospectEmployment;
        }

        private bool ProspectEmploymentExists(Guid id)
        {
            return _context.ProspectEmployment.Any(e => e.Id == id);
        }
    }
}
