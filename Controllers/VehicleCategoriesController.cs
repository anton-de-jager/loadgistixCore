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
    public class VehicleCategoriesController : ControllerBase
    {
        private readonly loadgistixContext _context;

        public VehicleCategoriesController(loadgistixContext context)
        {
            _context = context;
        }

        // GET: api/VehicleCategories
        [HttpGet]
        public async Task<ProcedureResult> GetVehicleCategory()
        {
            var statusDeleted = await _context.Status.Where(x => x.Table == "vehicleCategory" && x.Description == "Deleted").FirstOrDefaultAsync();
            var result = await _context.VehicleCategory.Where(x => x.Status != statusDeleted).Include(x => x.Status).ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // POST: api/VehicleCategories/all
        [HttpPost("all")]
        public async Task<ProcedureResult> GetVehicleCategoriesAll()
        {
            var statusDeleted = await _context.Status.Where(x => x.Table == "vehicleCategory" && x.Description == "Deleted").FirstOrDefaultAsync();
            var result = await _context.VehicleCategory.Where(x => x.Status != statusDeleted).Include(x => x.Status).ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // GET: api/VehicleCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleCategory>> GetVehicleCategory(Guid id)
        {
            var vehicleCategory = await _context.VehicleCategory.FindAsync(id);

            if (vehicleCategory == null)
            {
                return NotFound();
            }

            return vehicleCategory;
        }

        // PUT: api/VehicleCategories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<ProcedureResult> PutVehicleCategory(VehicleCategory vehicleCategory)
        {
            _context.Entry(vehicleCategory).State = EntityState.Modified;

            try
            {
                var statusActive = await _context.Status.Where(x => x.Table == "vehicleCategory" && x.Description == "Active").FirstOrDefaultAsync();
                vehicleCategory.Status = statusActive;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleCategoryExists(vehicleCategory.Id))
                {
                    return new ProcedureResult { Result = false, Message = "Item not found" };
                }
                else
                {
                    throw;
                }
            }

            var result = await _context.VehicleCategory.Where(x => x.Id == vehicleCategory.Id).Include(x => x.Status).FirstOrDefaultAsync();

            return new ProcedureResult { Result = true, Id = vehicleCategory.Id, Data = result };
        }

        // POST: api/VehicleCategories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ProcedureResult> PostVehicleCategory(VehicleCategory vehicleCategory)
        {
            var statusActive = await _context.Status.Where(x => x.Table == "vehicleCategory" && x.Description == "Active").FirstOrDefaultAsync();
            vehicleCategory.Status = statusActive;
            _context.VehicleCategory.Add(vehicleCategory);
            await _context.SaveChangesAsync();

            var result = await _context.VehicleCategory.Where(x => x.Id == vehicleCategory.Id).Include(x => x.Status).FirstOrDefaultAsync();

            return new ProcedureResult { Result = true, Id = vehicleCategory.Id, Data = result };
        }

        // DELETE: api/VehicleCategories/5
        [HttpPost("delete/{id}")]
        public async Task<ProcedureResult> DeleteVehicleCategory(Guid id)
        {
            var vehicleCategory = await _context.VehicleCategory.FindAsync(id);
            if (vehicleCategory == null)
            {
                return new ProcedureResult { Result = false, Message = "Item not found" };
            }

            var statusDeleted = await _context.Status.Where(x => x.Table == "vehicleCategory" && x.Description == "Deleted").FirstOrDefaultAsync();
            vehicleCategory.Status = statusDeleted;
            await _context.SaveChangesAsync();

            return new ProcedureResult { Result = true, Id = id };
        }

        private bool VehicleCategoryExists(Guid id)
        {
            return _context.VehicleCategory.Any(e => e.Id == id);
        }
    }
}
