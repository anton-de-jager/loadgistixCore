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
    public class LoadTypesController : ControllerBase
    {
        private readonly loadgistixContext _context;

        public LoadTypesController(loadgistixContext context)
        {
            _context = context;
        }

        // GET: api/LoadTypes
        [HttpGet]
        public async Task<ProcedureResult> GetLoadType()
        {
            var statusDeleted = await _context.Status.Where(x => x.Table == "loadType" && x.Description == "Deleted").FirstOrDefaultAsync();
            var result = await _context.LoadType.AsNoTracking().Where(x => x.Status != statusDeleted).Include(x => x.LoadCategory).Include(x => x.Status).ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // POST: api/LoadTypes/all
        [HttpPost("all")]
        public async Task<ProcedureResult> GetLoadTypesAll()
        {
            var statusDeleted = await _context.Status.Where(x => x.Table == "loadType" && x.Description == "Deleted").FirstOrDefaultAsync();
            var result = await _context.LoadType.AsNoTracking().Where(x => x.Status != statusDeleted).Include(x => x.LoadCategory).Include(x => x.Status).ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // GET: api/LoadTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoadType>> GetLoadType(Guid id)
        {
            var loadType = await _context.LoadType.FindAsync(id);

            if (loadType == null)
            {
                return NotFound();
            }

            return loadType;
        }

        // PUT: api/LoadTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<ProcedureResult> PutLoadType(LoadType loadType)
        {
            _context.Entry(loadType).State = EntityState.Modified;

            try
            {
                var statusActive = await _context.Status.Where(x => x.Table == "loadType" && x.Description == "Active").FirstOrDefaultAsync();
                loadType.Status = statusActive;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoadTypeExists(loadType.Id))
                {
                    return new ProcedureResult { Result = false, Message = "Item not found" };
                }
                else
                {
                    throw;
                }
            }

            var result = await _context.LoadType.AsNoTracking().Where(x => x.Id == loadType.Id).Include(x => x.LoadCategory).Include(x => x.Status).FirstOrDefaultAsync();

            return new ProcedureResult { Result = true, Id = loadType.Id, Data = result };
        }

        // POST: api/LoadTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ProcedureResult> PostLoadType(LoadType loadType)
        {
            var statusActive = await _context.Status.Where(x => x.Table == "loadType" && x.Description == "Active").FirstOrDefaultAsync();
            loadType.Status = statusActive;
            _context.LoadType.Add(loadType);
            await _context.SaveChangesAsync();

            var result = await _context.LoadType.AsNoTracking().Where(x => x.Id == loadType.Id).Include(x => x.LoadCategory).Include(x => x.Status).FirstOrDefaultAsync();

            return new ProcedureResult { Result = true, Id = loadType.Id, Data = result };
        }

        // DELETE: api/LoadTypes/5
        [HttpPost("delete/{id}")]
        public async Task<ProcedureResult> DeleteLoadType(Guid id)
        {
            var loadType = await _context.LoadType.FindAsync(id);
            if (loadType == null)
            {
                return new ProcedureResult { Result = false, Message = "Item not found" };
            }

            var statusDeleted = await _context.Status.Where(x => x.Table == "loadType" && x.Description == "Deleted").FirstOrDefaultAsync();
            loadType.Status = statusDeleted;
            await _context.SaveChangesAsync();

            return new ProcedureResult { Result = true, Id = id };
        }

        private bool LoadTypeExists(Guid id)
        {
            return _context.LoadType.Any(e => e.Id == id);
        }
    }
}
