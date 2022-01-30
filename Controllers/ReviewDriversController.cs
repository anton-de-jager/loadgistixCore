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
    public class ReviewDriversController : ControllerBase
    {
        private readonly loadgistixContext _context;

        public ReviewDriversController(loadgistixContext context)
        {
            _context = context;
        }

        // GET: api/ReviewDrivers
        [HttpGet]
        public async Task<ProcedureResult> GetReviewDriver()
        {
            var result = await _context.ReviewDriver.ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // POST: api/ReviewDrivers/user
        [HttpPost("{user}")]
        public async Task<ProcedureResult> GetReviewDriversByUser(IdRequest request)
        {
            var result = await _context.ReviewDriver.Where(x => x.UserId != request.Id).ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // GET: api/ReviewDrivers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewDriver>> GetReviewDriver(Guid id)
        {
            var reviewDriver = await _context.ReviewDriver.FindAsync(id);

            if (reviewDriver == null)
            {
                return NotFound();
            }

            return reviewDriver;
        }

        // PUT: api/ReviewDrivers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<ProcedureResult> PutReviewDriver(ReviewDriver reviewDriver)
        {
            _context.Entry(reviewDriver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewDriverExists(reviewDriver.Id))
                {
                    return new ProcedureResult { Result = false, Message = "Item not found" };
                }
                else
                {
                    throw;
                }
            }

            var result = await _context.ReviewDriver.Where(x => x.Id == reviewDriver.Id).FirstOrDefaultAsync();

            return new ProcedureResult { Result = true, Id = reviewDriver.Id, Data = result };
        }

        // POST: api/ReviewDrivers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ProcedureResult> PostReviewDriver(ReviewDriver reviewDriver)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            Guid id = identity.Claims.Where(x => x.Type == "Id").Count() > 0 ? Guid.Parse(identity.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value) : Guid.Empty;

            reviewDriver.Timestamp = DateTime.Now; ;
            reviewDriver.UserId = id;

            _context.ReviewDriver.Add(reviewDriver);
            await _context.SaveChangesAsync();

            var result = await _context.ReviewDriver.Where(x => x.Id == reviewDriver.Id).FirstOrDefaultAsync();

            return new ProcedureResult { Result = true, Id = reviewDriver.Id, Data = result };
        }

        private bool ReviewDriverExists(Guid id)
        {
            return _context.ReviewDriver.Any(e => e.Id == id);
        }
    }
}
