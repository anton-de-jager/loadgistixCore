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
    public class ProspectLanguagesController : ControllerBase
    {
        private readonly loadgistixContext _context;

        public ProspectLanguagesController(loadgistixContext context)
        {
            _context = context;
        }

        // GET: api/ProspectLanguages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProspectLanguage>>> GetProspectLanguage()
        {
            return await _context.ProspectLanguage.ToListAsync();
        }

        // GET: api/ProspectLanguages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProspectLanguage>> GetProspectLanguage(Guid id)
        {
            var prospectLanguage = await _context.ProspectLanguage.FindAsync(id);

            if (prospectLanguage == null)
            {
                return NotFound();
            }

            return prospectLanguage;
        }

        // PUT: api/ProspectLanguages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProspectLanguage(Guid id, ProspectLanguage prospectLanguage)
        {
            if (id != prospectLanguage.Id)
            {
                return BadRequest();
            }

            _context.Entry(prospectLanguage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProspectLanguageExists(id))
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

        // POST: api/ProspectLanguages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProspectLanguage>> PostProspectLanguage(ProspectLanguage prospectLanguage)
        {
            _context.ProspectLanguage.Add(prospectLanguage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProspectLanguage", new { id = prospectLanguage.Id }, prospectLanguage);
        }

        // DELETE: api/ProspectLanguages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProspectLanguage>> DeleteProspectLanguage(Guid id)
        {
            var prospectLanguage = await _context.ProspectLanguage.FindAsync(id);
            if (prospectLanguage == null)
            {
                return NotFound();
            }

            _context.ProspectLanguage.Remove(prospectLanguage);
            await _context.SaveChangesAsync();

            return prospectLanguage;
        }

        private bool ProspectLanguageExists(Guid id)
        {
            return _context.ProspectLanguage.Any(e => e.Id == id);
        }
    }
}
