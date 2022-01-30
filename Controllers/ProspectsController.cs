using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using loadgistix.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace loadgistix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProspectsController : ControllerBase
    {
        private readonly loadgistixContext _context;

        public ProspectsController(loadgistixContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public async Task<ProcedureResult> GetProspect()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            Guid id = identity.Claims.Where(x => x.Type == "Id").Count() > 0 ? Guid.Parse(identity.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value) : Guid.Empty;

            var statusDeleted = await _context.Status.Where(x => x.Table == "prospect" && x.Description == "Deleted").FirstOrDefaultAsync();
            var result = await _context.Prospect.Where(x => x.UserId == id).Include(x => x.ProspectEmployment).ThenInclude(x => x.ProspectEmploymentDuty).Include(x => x.ProspectEmployment).ThenInclude(x => x.ProspectEmploymentTechnology).Include(x => x.ProspectSubject).Include(x => x.ProspectTertiary).Include(x => x.ProspectLanguage).ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // GET: api/Prospects/5
        [HttpGet("{id}")]
        public async Task<ProcedureResult> GetProspect(Guid id)
        {
            var result = await _context.Prospect.Where(x => x.Id == id).Include(x => x.ProspectEmployment).ThenInclude(x => x.ProspectEmploymentDuty).Include(x => x.ProspectEmployment).ThenInclude(x => x.ProspectEmploymentTechnology).Include(x => x.ProspectSubject).Include(x => x.ProspectTertiary).Include(x => x.ProspectLanguage).FirstOrDefaultAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // PUT: api/Prospects/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPut]
        public async Task<ProcedureResult> PutProspect(Prospect prospect)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            Guid id = identity.Claims.Where(x => x.Type == "Id").Count() > 0 ? Guid.Parse(identity.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value) : Guid.Empty;

            Prospect prospectDelete = _context.Prospect.Where(x => x.Id == prospect.Id).Include(x => x.ProspectEmployment).ThenInclude(x => x.ProspectEmploymentDuty).Include(x => x.ProspectEmployment).ThenInclude(x => x.ProspectEmploymentTechnology).Include(x => x.ProspectSubject).Include(x => x.ProspectTertiary).Include(x => x.ProspectLanguage).FirstOrDefault();
            foreach (ProspectEmployment prospectEmployment in prospectDelete.ProspectEmployment)
            {
                foreach (ProspectEmploymentDuty prospectEmploymentDuty in prospectEmployment.ProspectEmploymentDuty)
                {
                    _context.ProspectEmploymentDuty.Remove(prospectEmploymentDuty);
                }
                foreach (ProspectEmploymentTechnology prospectEmploymentTechnology in prospectEmployment.ProspectEmploymentTechnology)
                {
                    _context.ProspectEmploymentTechnology.Remove(prospectEmploymentTechnology);
                }
                _context.ProspectEmployment.Remove(prospectEmployment);
            }
            foreach (ProspectLanguage prospectLanguage in prospectDelete.ProspectLanguage)
            {
                _context.ProspectLanguage.Remove(prospectLanguage);
            }
            foreach (ProspectSubject prospectSubject in prospectDelete.ProspectSubject)
            {
                _context.ProspectSubject.Remove(prospectSubject);
            }
            foreach (ProspectTertiary prospectTertiary in prospectDelete.ProspectTertiary)
            {
                _context.ProspectTertiary.Remove(prospectTertiary);
            }
            _context.Prospect.Remove(prospectDelete);
            await _context.SaveChangesAsync();

            prospect.UserId = id;
            if (prospect.ClientId == Guid.Empty)
            {
                prospect.ClientId = null;
            }
            _context.Prospect.Add(prospect);
            await _context.SaveChangesAsync();

            var result = await _context.Prospect.Where(x => x.UserId == id).Include(x => x.ProspectEmployment).ThenInclude(x => x.ProspectEmploymentDuty).Include(x => x.ProspectEmployment).ThenInclude(x => x.ProspectEmploymentTechnology).Include(x => x.ProspectSubject).Include(x => x.ProspectTertiary).Include(x => x.ProspectLanguage).FirstOrDefaultAsync();

            return new ProcedureResult { Result = true, Id = prospect.Id, Data = result };
        }

        // POST: api/Prospects
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPost]
        public async Task<ProcedureResult> PostProspect(Prospect prospect)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            Guid id = identity.Claims.Where(x => x.Type == "Id").Count() > 0 ? Guid.Parse(identity.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value) : Guid.Empty;

            prospect.UserId = id;
            if (prospect.ClientId == Guid.Empty)
            {
                prospect.ClientId = null;
            }
            _context.Prospect.Add(prospect);
            await _context.SaveChangesAsync();

            var result = await _context.Prospect.Where(x => x.UserId == id).Include(x => x.ProspectEmployment).ThenInclude(x => x.ProspectEmploymentDuty).Include(x => x.ProspectEmployment).ThenInclude(x => x.ProspectEmploymentTechnology).Include(x => x.ProspectSubject).Include(x => x.ProspectTertiary).Include(x => x.ProspectLanguage).FirstOrDefaultAsync();

            return new ProcedureResult { Result = true, Id = prospect.Id, Data = result };
        }

        // DELETE: api/Prospects/5
        [HttpDelete("{id}")]
        public async Task<ProcedureResult> DeleteProspect(Guid id)
        {
            var prospect = await _context.Prospect.FindAsync(id);

            _context.Prospect.Remove(prospect);
            await _context.SaveChangesAsync();

            return new ProcedureResult { Result = true, Id = id };
        }

        private bool ProspectExists(Guid id)
        {
            return _context.Prospect.Any(e => e.Id == id);
        }
    }
}
