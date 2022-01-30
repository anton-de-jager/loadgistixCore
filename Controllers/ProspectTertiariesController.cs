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
    public class ProspectTertiariesController : ControllerBase
    {
        private readonly loadgistixContext _context;

        public ProspectTertiariesController(loadgistixContext context)
        {
            _context = context;
        }

        // GET: api/ProspectTertiaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProspectTertiary>>> GetProspectTertiary()
        {
            return await _context.ProspectTertiary.ToListAsync();
        }

        // GET: api/ProspectTertiaries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProspectTertiary>> GetProspectTertiary(Guid id)
        {
            var prospectTertiary = await _context.ProspectTertiary.FindAsync(id);

            if (prospectTertiary == null)
            {
                return NotFound();
            }

            return prospectTertiary;
        }

        // PUT: api/ProspectTertiaries/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProspectTertiary(Guid id, ProspectTertiary prospectTertiary)
        {
            if (id != prospectTertiary.Id)
            {
                return BadRequest();
            }

            _context.Entry(prospectTertiary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProspectTertiaryExists(id))
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

        // POST: api/ProspectTertiaries
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProspectTertiary>> PostProspectTertiary(ProspectTertiary prospectTertiary)
        {
            _context.ProspectTertiary.Add(prospectTertiary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProspectTertiary", new { id = prospectTertiary.Id }, prospectTertiary);
        }

        // DELETE: api/ProspectTertiaries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProspectTertiary>> DeleteProspectTertiary(Guid id)
        {
            var prospectTertiary = await _context.ProspectTertiary.FindAsync(id);
            if (prospectTertiary == null)
            {
                return NotFound();
            }

            _context.ProspectTertiary.Remove(prospectTertiary);
            await _context.SaveChangesAsync();

            return prospectTertiary;
        }

        private bool ProspectTertiaryExists(Guid id)
        {
            return _context.ProspectTertiary.Any(e => e.Id == id);
        }
    }
}
