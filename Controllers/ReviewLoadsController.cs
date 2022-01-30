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
    public class ReviewLoadsController : ControllerBase
    {
        private readonly loadgistixContext _context;

        public ReviewLoadsController(loadgistixContext context)
        {
            _context = context;
        }

        // GET: api/ReviewLoads
        [HttpGet]
        public async Task<ProcedureResult> GetReviewLoad()
        {
            var result = await _context.ReviewLoad.ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // POST: api/ReviewLoads/user
        [HttpPost("{user}")]
        public async Task<ProcedureResult> GetReviewLoadsByUser(IdRequest request)
        {
            var result = await _context.ReviewLoad.Where(x => x.UserId != request.Id).ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // GET: api/ReviewLoads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewLoad>> GetReviewLoad(Guid id)
        {
            var reviewLoad = await _context.ReviewLoad.FindAsync(id);

            if (reviewLoad == null)
            {
                return NotFound();
            }

            return reviewLoad;
        }

        // PUT: api/ReviewLoads/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<ProcedureResult> PutReviewLoad(ReviewLoad reviewLoad)
        {
            _context.Entry(reviewLoad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewLoadExists(reviewLoad.Id))
                {
                    return new ProcedureResult { Result = false, Message = "Item not found" };
                }
                else
                {
                    throw;
                }
            }

            var result = await _context.ReviewLoad.Where(x => x.Id == reviewLoad.Id).FirstOrDefaultAsync();

            return new ProcedureResult { Result = true, Id = reviewLoad.Id, Data = result };
        }

        // POST: api/ReviewLoads
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ProcedureResult> PostReviewLoad(ReviewLoad reviewLoad)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            Guid id = identity.Claims.Where(x => x.Type == "Id").Count() > 0 ? Guid.Parse(identity.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value) : Guid.Empty;

            reviewLoad.Timestamp = DateTime.Now;
            reviewLoad.UserId = id;

            _context.ReviewLoad.Add(reviewLoad);
            await _context.SaveChangesAsync();

            var result = await _context.ReviewLoad.Where(x => x.Id == reviewLoad.Id).FirstOrDefaultAsync();

            return new ProcedureResult { Result = true, Id = reviewLoad.Id, Data = result };
        }

        private bool ReviewLoadExists(Guid id)
        {
            return _context.ReviewLoad.Any(e => e.Id == id);
        }
    }
}
