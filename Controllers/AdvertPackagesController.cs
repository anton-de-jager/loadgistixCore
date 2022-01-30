using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using loadgistix.Models;
using Microsoft.AspNetCore.Authorization;

namespace loadgistix.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertPackagesController : ControllerBase
    {
        private readonly loadgistixContext _context;

        public AdvertPackagesController(loadgistixContext context)
        {
            _context = context;
        }

        // GET: api/AdvertPackages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdvertPackage>>> GetAdvertPackage()
        {
            return await _context.AdvertPackage.ToListAsync();
        }

        // POST: api/AdvertPackages/all
        [HttpPost("all")]
        public async Task<ProcedureResult> GetAdvertPackagesAll()
        {
            var result = await _context.AdvertPackage.ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // GET: api/AdvertPackages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdvertPackage>> GetAdvertPackage(Guid id)
        {
            var advertPackage = await _context.AdvertPackage.FindAsync(id);

            if (advertPackage == null)
            {
                return NotFound();
            }

            return advertPackage;
        }

        // PUT: api/AdvertPackages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdvertPackage(Guid id, AdvertPackage advertPackage)
        {
            if (id != advertPackage.Id)
            {
                return BadRequest();
            }

            _context.Entry(advertPackage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvertPackageExists(id))
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

        // POST: api/AdvertPackages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AdvertPackage>> PostAdvertPackage(AdvertPackage advertPackage)
        {
            _context.AdvertPackage.Add(advertPackage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdvertPackage", new { id = advertPackage.Id }, advertPackage);
        }

        // DELETE: api/AdvertPackages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AdvertPackage>> DeleteAdvertPackage(Guid id)
        {
            var advertPackage = await _context.AdvertPackage.FindAsync(id);
            if (advertPackage == null)
            {
                return NotFound();
            }

            _context.AdvertPackage.Remove(advertPackage);
            await _context.SaveChangesAsync();

            return advertPackage;
        }

        private bool AdvertPackageExists(Guid id)
        {
            return _context.AdvertPackage.Any(e => e.Id == id);
        }
    }
}
