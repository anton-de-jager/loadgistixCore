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
    public class LicenceTypesController : ControllerBase
    {
        private readonly loadgistixContext _context;

        public LicenceTypesController(loadgistixContext context)
        {
            _context = context;
        }

        // GET: api/LicenceTypes
        [HttpGet]
        public async Task<ProcedureResult> GetLicenceType()
        {
            var result = await _context.LicenceType.ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // POST: api/LicenceTypes/all
        [HttpPost("all")]
        public async Task<ProcedureResult> GetLicenceTypesAll()
        {
            var result = await _context.LicenceType.ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // GET: api/LicenceTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LicenceType>> GetLicenceType(Guid id)
        {
            var licenceType = await _context.LicenceType.FindAsync(id);

            if (licenceType == null)
            {
                return NotFound();
            }

            return licenceType;
        }

        // PUT: api/LicenceTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLicenceType(Guid id, LicenceType licenceType)
        {
            if (id != licenceType.Id)
            {
                return BadRequest();
            }

            _context.Entry(licenceType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LicenceTypeExists(id))
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

        // POST: api/LicenceTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LicenceType>> PostLicenceType(LicenceType licenceType)
        {
            _context.LicenceType.Add(licenceType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLicenceType", new { id = licenceType.Id }, licenceType);
        }

        // DELETE: api/LicenceTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LicenceType>> DeleteLicenceType(Guid id)
        {
            var licenceType = await _context.LicenceType.FindAsync(id);
            if (licenceType == null)
            {
                return NotFound();
            }

            _context.LicenceType.Remove(licenceType);
            await _context.SaveChangesAsync();

            return licenceType;
        }

        private bool LicenceTypeExists(Guid id)
        {
            return _context.LicenceType.Any(e => e.Id == id);
        }
    }
}
