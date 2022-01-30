using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using loadgistix.Models;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace loadgistix.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly loadgistixContext _context;

        public VehiclesController(loadgistixContext context)
        {
            _context = context;
        }

        // GET: api/Vehicles
        [HttpGet]
        public async Task<ProcedureResult> GetVehicle()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            Guid id = identity.Claims.Where(x => x.Type == "Id").Count() > 0 ? Guid.Parse(identity.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value) : Guid.Empty;

            var statusDeleted = await _context.Status.Where(x => x.Table == "vehicle" && x.Description == "Deleted").FirstOrDefaultAsync();
            var result = await _context.Vehicle.Where(x => x.Status != statusDeleted && x.UserId == id).Include(x => x.VehicleType).ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // POST: api/Vehicles/all
        [HttpPost("all")]
        public async Task<ProcedureResult> GetVehiclesAll()
        {
            var statusDeleted = await _context.Status.Where(x => x.Table == "vehicle" && x.Description == "Deleted").FirstOrDefaultAsync();
            var result = await _context.Vehicle.Where(x => x.Status != statusDeleted).ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(Guid id)
        {
            var vehicle = await _context.Vehicle.FindAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return vehicle;
        }

        // PUT: api/Vehicles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<ProcedureResult> PutVehicle(Vehicle vehicle)
        {
            _context.Entry(vehicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleExists(vehicle.Id))
                {
                    return new ProcedureResult { Result = false, Message = "Item not found" };
                }
                else
                {
                    throw;
                }
            }

            var result = await _context.Vehicle.Where(x => x.Id == vehicle.Id).Include(x => x.VehicleType).FirstOrDefaultAsync();

            return new ProcedureResult { Result = true, Id = vehicle.Id, Data = result };
        }

        // POST: api/Vehicles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ProcedureResult> PostVehicle(Vehicle vehicle)
        {
            _context.Vehicle.Add(vehicle);
            await _context.SaveChangesAsync();

            var result = await _context.Vehicle.Where(x => x.Id == vehicle.Id).Include(x => x.VehicleType).FirstOrDefaultAsync();

            return new ProcedureResult { Result = true, Id = vehicle.Id, Data = result };
        }

        // DELETE: api/Vehicles/5
        [HttpPost("delete/{id}")]
        public async Task<ProcedureResult> DeleteVehicle(Guid id)
        {
            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return new ProcedureResult { Result = false, Message = "Item not found" };
            }

            var statusDeleted = await _context.Status.Where(x => x.Table == "vehicle" && x.Description == "Deleted").FirstOrDefaultAsync();
            vehicle.Status = statusDeleted;
            await _context.SaveChangesAsync();

            return new ProcedureResult { Result = true, Id = id };
        }

        [HttpPost("uploadImage/{filename}"), DisableRequestSizeLimit]
        public IActionResult Upload(string filename)
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Images", "Vehicles");
                var pathToSave = Path.Combine(System.IO.Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fullPath = Path.Combine(pathToSave, filename);
                    var dbPath = Path.Combine(folderName, filename);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    var vehicle = _context.Vehicle.FindAsync(Guid.Parse(filename.Substring(0, filename.IndexOf(".")))).Result;
                    vehicle.Avatar = filename.Replace(filename.Substring(0, filename.IndexOf(".")), "");
                    _context.SaveChanges();
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        private bool VehicleExists(Guid id)
        {
            return _context.Vehicle.Any(e => e.Id == id);
        }
    }
}
