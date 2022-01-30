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
    public class LoadCategoriesController : ControllerBase
    {
        private readonly loadgistixContext _context;

        public LoadCategoriesController(loadgistixContext context)
        {
            _context = context;
        }

        // GET: api/LoadCategories
        [HttpGet]
        public async Task<ProcedureResult> GetLoadCategory()
        {
            var statusDeleted = await _context.Status.Where(x => x.Table == "loadCategory" && x.Description == "Deleted").FirstOrDefaultAsync();
            var result = await _context.LoadCategory.Where(x => x.Status != statusDeleted).Include(x => x.Status).ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // POST: api/LoadCategories/all
        [HttpPost("all")]
        public async Task<ProcedureResult> GetLoadCategoriesAll()
        {
            var statusDeleted = await _context.Status.Where(x => x.Table == "loadCategory" && x.Description == "Deleted").FirstOrDefaultAsync();
            var result = await _context.LoadCategory.Where(x => x.Status != statusDeleted).Include(x => x.Status).ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // GET: api/LoadCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoadCategory>> GetLoadCategory(Guid id)
        {
            var loadCategory = await _context.LoadCategory.FindAsync(id);

            if (loadCategory == null)
            {
                return NotFound();
            }

            return loadCategory;
        }

        // PUT: api/LoadCategories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<ProcedureResult> PutLoadCategory(LoadCategory loadCategory)
        {
            _context.Entry(loadCategory).State = EntityState.Modified;

            try
            {
                var statusActive = await _context.Status.Where(x => x.Table == "loadCategory" && x.Description == "Active").FirstOrDefaultAsync();
                loadCategory.Status = statusActive;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoadCategoryExists(loadCategory.Id))
                {
                    return new ProcedureResult { Result = false, Message = "Item not found" };
                }
                else
                {
                    throw;
                }
            }

            var result = await _context.LoadCategory.Where(x => x.Id == loadCategory.Id).Include(x => x.Status).FirstOrDefaultAsync();

            return new ProcedureResult { Result = true, Id = loadCategory.Id, Data = result };
        }

        // POST: api/LoadCategories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ProcedureResult> PostLoadCategory(LoadCategory loadCategory)
        {
            var statusActive = await _context.Status.Where(x => x.Table == "loadCategory" && x.Description == "Active").FirstOrDefaultAsync();
            loadCategory.Status = statusActive;
            _context.LoadCategory.Add(loadCategory);
            await _context.SaveChangesAsync();

            var result = await _context.LoadCategory.Where(x => x.Id == loadCategory.Id).Include(x => x.Status).FirstOrDefaultAsync();

            return new ProcedureResult { Result = true, Id = loadCategory.Id, Data = result };
        }

        // DELETE: api/LoadCategories/5
        [HttpPost("delete/{id}")]
        public async Task<ProcedureResult> DeleteLoadCategory(Guid id)
        {
            var loadCategory = await _context.LoadCategory.FindAsync(id);
            if (loadCategory == null)
            {
                return new ProcedureResult { Result = false, Message = "Item not found" };
            }

            var statusDeleted = await _context.Status.Where(x => x.Table == "loadCategory" && x.Description == "Deleted").FirstOrDefaultAsync();
            loadCategory.Status = statusDeleted;
            await _context.SaveChangesAsync();

            return new ProcedureResult { Result = true, Id = id };
        }

        private bool LoadCategoryExists(Guid id)
        {
            return _context.LoadCategory.Any(e => e.Id == id);
        }
    }
}
