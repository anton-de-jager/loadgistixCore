using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using loadgistix.Models;
using System.IO;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace loadgistix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoriesController : ControllerBase
    {
        private readonly loadgistixContext _context;

        public DirectoriesController(loadgistixContext context)
        {
            _context = context;
        }

        // GET: api/Directories
        [Authorize]
        [HttpGet]
        public async Task<ProcedureResult> GetDirectory()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            Guid id = identity.Claims.Where(x => x.Type == "Id").Count() > 0 ? Guid.Parse(identity.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value) : Guid.Empty;

            var statusDeleted = await _context.Status.Where(x => x.Table == "directory" && x.Description == "Deleted").FirstOrDefaultAsync();
            var result = await _context.Directory.Where(x => x.Status != statusDeleted && x.UserId == id).Include(x => x.Status).Include(x => x.DirectoryCategory).ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // POST: api/Directories/all
        [HttpPost("all")]
        public async Task<ProcedureResult> GetDirectoriesAll()
        {
            var statusDeleted = await _context.Status.Where(x => x.Table == "directory" && x.Description == "Deleted").FirstOrDefaultAsync();
            var result = await _context.Directory.Where(x => x.Status != statusDeleted).Include(x => x.Status).Include(x => x.DirectoryCategory).ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // POST: api/Directories/all
        [HttpPost("available")]
        public async Task<ProcedureResult> GetDirectoriesAvailable()
        {
            var statusDeleted = await _context.Status.Where(x => x.Table == "directory" && x.Description == "Deleted").FirstOrDefaultAsync();
            var result = await _context.Directory.Where(x => x.StatusId != statusDeleted.Id).Include(x => x.Status).Include(x => x.DirectoryCategory).ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // POST: api/Directories/category/5
        [HttpPost("category/{directoryCategoryId}")]
        public async Task<ProcedureResult> GetDirectoriesAvailable(Guid directoryCategoryId)
        {
            var statusDeleted = await _context.Status.Where(x => x.Table == "directory" && x.Description == "Deleted").FirstOrDefaultAsync();
            var result = await _context.Directory.Where(x => x.StatusId != statusDeleted.Id && x.DirectoryCategoryId == directoryCategoryId).Include(x => x.Status).Include(x => x.DirectoryCategory).ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // GET: api/Directories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Directory>> GetDirectory(Guid id)
        {
            var directory = await _context.Directory.FindAsync(id);

            if (directory == null)
            {
                return NotFound();
            }

            return directory;
        }

        // PUT: api/Directories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPut]
        public async Task<ProcedureResult> PutDirectory(Models.Directory directory)
        {
            _context.Entry(directory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectoryExists(directory.Id))
                {
                    return new ProcedureResult { Result = false, Message = "Item not found" };
                }
                else
                {
                    throw;
                }
            }

            var result = await _context.Directory.Include(x => x.Status).Include(x => x.DirectoryCategory).FirstOrDefaultAsync();

            return new ProcedureResult { Result = true, Id = directory.Id, Data = result };
        }

        // POST: api/Directories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPost]
        public async Task<ProcedureResult> PostDirectory(Models.Directory directory)
        {
            _context.Directory.Add(directory);
            await _context.SaveChangesAsync();

            var result = await _context.Directory.Include(x => x.Status).Include(x => x.DirectoryCategory).FirstOrDefaultAsync();

            return new ProcedureResult { Result = true, Id = directory.Id, Data = result };
        }

        // DELETE: api/Directories/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Directory>> DeleteDirectory(Guid id)
        {
            var directory = await _context.Directory.FindAsync(id);
            if (directory == null)
            {
                return NotFound();
            }

            _context.Directory.Remove(directory);
            await _context.SaveChangesAsync();

            return directory;
        }

        [HttpPost("uploadImage/{filename}"), DisableRequestSizeLimit]
        public IActionResult Upload(string filename)
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Images", "Directories");
                var pathToSave = Path.Combine(System.IO.Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fullPath = Path.Combine(pathToSave, filename);
                    var dbPath = Path.Combine(folderName, filename);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    var directory = _context.Directory.FindAsync(Guid.Parse(filename.Substring(0, filename.IndexOf(".")))).Result;
                    directory.Avatar = filename.Replace(filename.Substring(0, filename.IndexOf(".")), "");
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

        private bool DirectoryExists(Guid id)
        {
            return _context.Directory.Any(e => e.Id == id);
        }
    }
}
