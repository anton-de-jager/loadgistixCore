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
    public class ProspectSubjectsController : ControllerBase
    {
        private readonly loadgistixContext _context;

        public ProspectSubjectsController(loadgistixContext context)
        {
            _context = context;
        }

        // GET: api/ProspectSubjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProspectSubject>>> GetProspectSubject()
        {
            return await _context.ProspectSubject.ToListAsync();
        }

        // GET: api/ProspectSubjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProspectSubject>> GetProspectSubject(Guid id)
        {
            var prospectSubject = await _context.ProspectSubject.FindAsync(id);

            if (prospectSubject == null)
            {
                return NotFound();
            }

            return prospectSubject;
        }

        // PUT: api/ProspectSubjects/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProspectSubject(Guid id, ProspectSubject prospectSubject)
        {
            if (id != prospectSubject.Id)
            {
                return BadRequest();
            }

            _context.Entry(prospectSubject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProspectSubjectExists(id))
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

        // POST: api/ProspectSubjects
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProspectSubject>> PostProspectSubject(ProspectSubject prospectSubject)
        {
            _context.ProspectSubject.Add(prospectSubject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProspectSubject", new { id = prospectSubject.Id }, prospectSubject);
        }

        // DELETE: api/ProspectSubjects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProspectSubject>> DeleteProspectSubject(Guid id)
        {
            var prospectSubject = await _context.ProspectSubject.FindAsync(id);
            if (prospectSubject == null)
            {
                return NotFound();
            }

            _context.ProspectSubject.Remove(prospectSubject);
            await _context.SaveChangesAsync();

            return prospectSubject;
        }

        private bool ProspectSubjectExists(Guid id)
        {
            return _context.ProspectSubject.Any(e => e.Id == id);
        }
    }
}
