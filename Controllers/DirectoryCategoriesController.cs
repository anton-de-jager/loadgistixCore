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
    public class DirectoryCategoriesController : ControllerBase
    {
        private readonly loadgistixContext _context;

        public DirectoryCategoriesController(loadgistixContext context)
        {
            _context = context;
        }

        // GET: api/DirectoryCategories
        [HttpGet]
        public async Task<ProcedureResult> GetDirectoryCategory()
        {
            var statusDeleted = await _context.Status.Where(x => x.Table == "directoryCategory" && x.Description == "Deleted").FirstOrDefaultAsync();
            var result = await _context.DirectoryCategory.ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // POST: api/DirectoryCategories/all
        [HttpPost("available")]
        public async Task<ProcedureResult> GetDirectoryCategoriesAll()
        {
            var statusDeleted = await _context.Status.Where(x => x.Table == "directory" && x.Description == "Deleted").FirstOrDefaultAsync();
            var result = await _context.DirectoryCategory.Include(x => x.Directory).ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // GET: api/DirectoryCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DirectoryCategory>> GetDirectoryCategory(Guid id)
        {
            var directoryCategory = await _context.DirectoryCategory.FindAsync(id);

            if (directoryCategory == null)
            {
                return NotFound();
            }

            return directoryCategory;
        }

        // PUT: api/DirectoryCategories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirectoryCategory(Guid id, DirectoryCategory directoryCategory)
        {
            if (id != directoryCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(directoryCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectoryCategoryExists(id))
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

        // POST: api/DirectoryCategories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DirectoryCategory>> PostDirectoryCategory(DirectoryCategory directoryCategory)
        {
            _context.DirectoryCategory.Add(directoryCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDirectoryCategory", new { id = directoryCategory.Id }, directoryCategory);
        }

        // DELETE: api/DirectoryCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DirectoryCategory>> DeleteDirectoryCategory(Guid id)
        {
            var directoryCategory = await _context.DirectoryCategory.FindAsync(id);
            if (directoryCategory == null)
            {
                return NotFound();
            }

            _context.DirectoryCategory.Remove(directoryCategory);
            await _context.SaveChangesAsync();

            return directoryCategory;
        }

        private bool DirectoryCategoryExists(Guid id)
        {
            return _context.DirectoryCategory.Any(e => e.Id == id);
        }
    }
}
