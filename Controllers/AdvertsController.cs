using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using loadgistix.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IO;

namespace loadgistix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertsController : ControllerBase
    {
        private readonly loadgistixContext _context;

        public AdvertsController(loadgistixContext context)
        {
            _context = context;
        }

        // GET: api/Adverts
        [Authorize]
        [HttpGet]
        public async Task<ProcedureResult> GetAdvert()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            Guid id = identity.Claims.Where(x => x.Type == "Id").Count() > 0 ? Guid.Parse(identity.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value) : Guid.Empty;

            var statusDeleted = await _context.Status.Where(x => x.Table == "advert" && x.Description == "Deleted").FirstOrDefaultAsync();
            var result = await _context.Advert.Where(x => x.Status != statusDeleted && x.UserId == id).Include(x => x.Status).Include(x => x.AdvertPackage).ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // GET: api/Adverts/user
        [HttpPost("available")]
        public ProcedureResult GetAdvertsAvailable()
        {
            var result = _context.Advert.FromSqlRaw("EXECUTE [dbo].[sp_adverts_available]").ToList();

            return new ProcedureResult { Result = true, Data = result };
        }

        // GET: api/Adverts/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Advert>> GetAdvert(Guid id)
        {
            var advert = await _context.Advert.FindAsync(id);

            if (advert == null)
            {
                return NotFound();
            }

            return advert;
        }

        // PUT: api/Adverts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPut]
        public async Task<ProcedureResult> PutAdvert(Advert advert)
        {
            _context.Entry(advert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvertExists(advert.Id))
                {
                    return new ProcedureResult { Result = false, Message = "Item not found" };
                }
                else
                {
                    throw;
                }
            }

            var result = await _context.Advert.Where(x => x.Id == advert.Id).Include(x => x.Status).Include(x => x.AdvertPackage).FirstOrDefaultAsync();

            return new ProcedureResult { Result = true, Id = advert.Id, Data = result };
        }

        // POST: api/Adverts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPost]
        public async Task<ProcedureResult> PostAdvert(Advert advert)
        {
            _context.Advert.Add(advert);
            await _context.SaveChangesAsync();

            var result = await _context.Advert.Where(x => x.Id == advert.Id).Include(x => x.Status).Include(x => x.AdvertPackage).FirstOrDefaultAsync();

            return new ProcedureResult { Result = true, Id = advert.Id, Data = result };
        }

        // DELETE: api/Adverts/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ProcedureResult> DeleteAdvert(Guid id)
        {
            var advert = await _context.Advert.FindAsync(id);
            if (advert == null)
            {
                return new ProcedureResult { Result = false, Message = "Item not found" };
            }

            var statusDeleted = await _context.Status.Where(x => x.Table == "advert" && x.Description == "Deleted").FirstOrDefaultAsync();
            advert.Status = statusDeleted;
            await _context.SaveChangesAsync();

            return new ProcedureResult { Result = true, Id = id };
        }

        [Authorize]
        [HttpPost("uploadImage/{filename}"), DisableRequestSizeLimit]
        public IActionResult Upload(string filename)
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Images", "Adverts");
                var pathToSave = Path.Combine(System.IO.Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fullPath = Path.Combine(pathToSave, filename);
                    var dbPath = Path.Combine(folderName, filename);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    var advert = _context.Advert.FindAsync(Guid.Parse(filename.Substring(0, filename.IndexOf(".")))).Result;
                    advert.Avatar = filename.Replace(filename.Substring(0, filename.IndexOf(".")), "");
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

        private bool AdvertExists(Guid id)
        {
            return _context.Advert.Any(e => e.Id == id);
        }
    }
}
