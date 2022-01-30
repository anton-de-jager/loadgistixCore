using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using loadgistix.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace loadgistix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProspectEmploymentDutiesController : ControllerBase
    {
        private readonly loadgistixContext _context;

        public ProspectEmploymentDutiesController(loadgistixContext context)
        {
            _context = context;
        }

        // GET: api/ProspectEmploymentDuties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProspectEmploymentDuty>>> GetProspectEmploymentDuty()
        {
            return await _context.ProspectEmploymentDuty.ToListAsync();
        }

        // GET: api/ProspectEmploymentDuties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProspectEmploymentDuty>> GetProspectEmploymentDuty(Guid id)
        {
            var prospectEmploymentDuty = await _context.ProspectEmploymentDuty.FindAsync(id);

            if (prospectEmploymentDuty == null)
            {
                return NotFound();
            }

            return prospectEmploymentDuty;
        }

        [HttpGet("{prospectEmploymentId}")]
        public async Task<ProcedureResult> GetProspect(Guid prospectEmploymentId)
        {
            var result = await _context.ProspectEmploymentDuty.Where(x => x.ProspectEmploymentId == prospectEmploymentId).ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // PUT: api/ProspectEmploymentDuties/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProspectEmploymentDuty(Guid id, ProspectEmploymentDuty prospectEmploymentDuty)
        {
            if (id != prospectEmploymentDuty.Id)
            {
                return BadRequest();
            }

            _context.Entry(prospectEmploymentDuty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProspectEmploymentDutyExists(id))
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

        // POST: api/ProspectEmploymentDuties
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProspectEmploymentDuty>> PostProspectEmploymentDuty(ProspectEmploymentDuty prospectEmploymentDuty)
        {
            _context.ProspectEmploymentDuty.Add(prospectEmploymentDuty);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProspectEmploymentDuty", new { id = prospectEmploymentDuty.Id }, prospectEmploymentDuty);
        }

        // DELETE: api/ProspectEmploymentDuties/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProspectEmploymentDuty>> DeleteProspectEmploymentDuty(Guid id)
        {
            var prospectEmploymentDuty = await _context.ProspectEmploymentDuty.FindAsync(id);
            if (prospectEmploymentDuty == null)
            {
                return NotFound();
            }

            _context.ProspectEmploymentDuty.Remove(prospectEmploymentDuty);
            await _context.SaveChangesAsync();

            return prospectEmploymentDuty;
        }

        private bool ProspectEmploymentDutyExists(Guid id)
        {
            return _context.ProspectEmploymentDuty.Any(e => e.Id == id);
        }
    }
}
