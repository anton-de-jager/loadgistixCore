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
    public class DriversController : ControllerBase
    {
        private readonly loadgistixContext _context;

        public DriversController(loadgistixContext context)
        {
            _context = context;
        }

        // GET: api/Drivers
        [HttpGet]
        public async Task<ActionResult<ProcedureResult>> GetDriver()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            Guid id = identity.Claims.Where(x => x.Type == "Id").Count() > 0 ? Guid.Parse(identity.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value) : Guid.Empty;

            var statusDeleted = await _context.Status.Where(x => x.Table == "driver" && x.Description == "Deleted").FirstOrDefaultAsync();
            var result = await _context.Driver.Where(x => x.Status != statusDeleted && x.UserId == id).Include(x => x.LicenceType).ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // GET: api/Drivers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> GetDriver(Guid id)
        {
            var driver = await _context.Driver.FindAsync(id);

            if (driver == null)
            {
                return NotFound();
            }

            return driver;
        }

        // PUT: api/Drivers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<ProcedureResult> PutDriver(Driver driver)
        {
            _context.Entry(driver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverExists(driver.Id))
                {
                    return new ProcedureResult { Result = false, Message = "Item not found" };
                }
                else
                {
                    throw;
                }
            }

            var result = await _context.Driver.Where(x => x.Id == driver.Id).Include(x => x.LicenceType).FirstOrDefaultAsync();

            return new ProcedureResult { Result = true, Id = driver.Id, Data = result };
        }

        // POST: api/Drivers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ProcedureResult> PostDriver(Driver driver)
        {
            _context.Driver.Add(driver);
            await _context.SaveChangesAsync();

            var result = await _context.Driver.Where(x => x.Id == driver.Id).Include(x => x.LicenceType).FirstOrDefaultAsync();

            return new ProcedureResult { Result = true, Id = driver.Id, Data = result };
        }

        // DELETE: api/Drivers/5
        [HttpPost("delete/{id}")]
        public async Task<ProcedureResult> DeleteDriver(Guid id)
        {
            var driver = await _context.Driver.FindAsync(id);
            if (driver == null)
            {
                return new ProcedureResult { Result = false, Message = "Item not found" };
            }

            var statusDeleted = await _context.Status.Where(x => x.Table == "driver" && x.Description == "Deleted").FirstOrDefaultAsync();
            driver.Status = statusDeleted;
            await _context.SaveChangesAsync();

            return new ProcedureResult { Result = true, Id = id };
        }

        [HttpPost("uploadImage/{filename}"), DisableRequestSizeLimit]
        public IActionResult Upload(string filename)
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Images", "Drivers");
                var pathToSave = Path.Combine(System.IO.Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fullPath = Path.Combine(pathToSave, filename);
                    var dbPath = Path.Combine(folderName, filename);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    var driver = _context.Driver.FindAsync(Guid.Parse(filename.Substring(0, filename.IndexOf(".")))).Result;
                    driver.Avatar = filename.Replace(filename.Substring(0, filename.IndexOf(".")), "");
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

        private bool DriverExists(Guid id)
        {
            return _context.Driver.Any(e => e.Id == id);
        }
    }
}
