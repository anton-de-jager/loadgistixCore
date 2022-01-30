using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using loadgistix.Models;
using System.Security.Claims;

namespace loadgistix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleTypesController : ControllerBase
    {
        private readonly loadgistixContext _context;

        public VehicleTypesController(loadgistixContext context)
        {
            _context = context;
        }

        // GET: api/VehicleTypes
        [HttpGet]
        public async Task<ProcedureResult> GetVehicleTypes()
        {
            var statusDeleted = await _context.Status.Where(x => x.Table == "vehicleType" && x.Description == "Deleted").FirstOrDefaultAsync();
            var result = await _context.VehicleType.AsNoTracking().Where(x => x.Status != statusDeleted).Include(x => x.VehicleCategory).Include(x => x.Status).ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // POST: api/VehicleTypes/all
        [HttpPost("all")]
        public async Task<ProcedureResult> GetVehicleTypesAll()
        {
            var statusDeleted = await _context.Status.Where(x => x.Table == "vehicleType" && x.Description == "Deleted").FirstOrDefaultAsync();
            var result = await _context.VehicleType.AsNoTracking().Where(x => x.Status != statusDeleted).Include(x => x.VehicleCategory).Include(x => x.Status).ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // GET: api/VehicleTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleType>> GetVehicleType(Guid id)
        {
            var vehicleType = await _context.VehicleType.FindAsync(id);

            if (vehicleType == null)
            {
                return NotFound();
            }

            return vehicleType;
        }

        // PUT: api/VehicleTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<ProcedureResult> PutVehicleType(VehicleType vehicleType)
        {
            _context.Entry(vehicleType).State = EntityState.Modified;

            try
            {
                var statusActive = await _context.Status.Where(x => x.Table == "vehicleType" && x.Description == "Active").FirstOrDefaultAsync();
                vehicleType.Status = statusActive;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleTypeExists(vehicleType.Id))
                {
                    return new ProcedureResult { Result = false, Message = "Item not found" };
                }
                else
                {
                    throw;
                }
            }

            var result = await _context.VehicleType.AsNoTracking().Where(x => x.Id == vehicleType.Id).Include(x => x.VehicleCategory).Include(x => x.Status).FirstOrDefaultAsync();

            return new ProcedureResult { Result = true, Id = vehicleType.Id, Data = result };
        }

        // POST: api/VehicleTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ProcedureResult> PostVehicleType(VehicleType vehicleType)
        {
            var statusActive = await _context.Status.Where(x => x.Table == "vehicleType" && x.Description == "Active").FirstOrDefaultAsync();
            vehicleType.Status = statusActive;
            _context.VehicleType.Add(vehicleType);
            await _context.SaveChangesAsync();

            var result = await _context.VehicleType.AsNoTracking().Where(x => x.Id == vehicleType.Id).Include(x => x.VehicleCategory).Include(x => x.Status).FirstOrDefaultAsync();

            return new ProcedureResult { Result = true, Id = vehicleType.Id, Data = result };
        }

        // DELETE: api/VehicleTypes/5
        [HttpPost("delete/{id}")]
        public async Task<ProcedureResult> DeleteVehicleType(Guid id)
        {
            var vehicleType = await _context.VehicleType.FindAsync(id);
            if (vehicleType == null)
            {
                return new ProcedureResult { Result = false, Message = "Item not found" };
            }

            var statusDeleted = await _context.Status.Where(x => x.Table == "vehicleType" && x.Description == "Deleted").FirstOrDefaultAsync();
            vehicleType.Status = statusDeleted;
            await _context.SaveChangesAsync();

            return new ProcedureResult { Result = true, Id = id };
        }

        private bool VehicleTypeExists(Guid id)
        {
            return _context.VehicleType.Any(e => e.Id == id);
        }
    }
}
