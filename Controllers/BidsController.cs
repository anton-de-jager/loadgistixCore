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
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace loadgistix.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BidsController : ControllerBase
    {
        private readonly loadgistixContext _context;

        public BidsController(loadgistixContext context)
        {
            _context = context;
        }

        // GET: api/Bids
        [HttpGet]
        public async Task<ProcedureResult> GetBid()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            Guid id = identity.Claims.Where(x => x.Type == "Id").Count() > 0 ? Guid.Parse(identity.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value) : Guid.Empty;

            var statusDeleted = await _context.Status.Where(x => x.Table == "bid" && x.Description == "Deleted").FirstOrDefaultAsync();
            var result = await _context.Bid.Where(x => x.Status != statusDeleted && x.UserId == id).Include(x => x.User).Include(x => x.Vehicle).Include(x => x.Driver).Include(x => x.Status).Include(x => x.Load).ThenInclude(x => x.Status).Include(x => x.Load).ThenInclude(x => x.LoadType).ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // POST: api/DirectoryCategories/all
        [HttpPost("load")]
        public async Task<ProcedureResult> GetBidByLoadId(IdRequest request)
        {
            var statusDeleted = await _context.Status.Where(x => x.Table == "bid" && x.Description == "Deleted").FirstOrDefaultAsync();
            var result = await _context.Bid.Where(x => x.Status != statusDeleted && x.LoadId == request.Id).Include(x => x.User).Include(x => x.Load).ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // GET: api/Bids/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bid>> GetBid(Guid id)
        {
            var bid = await _context.Bid.FindAsync(id);

            if (bid == null)
            {
                return NotFound();
            }

            return bid;
        }

        // PUT: api/Bids/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<ProcedureResult> PutBid(Bid bid)
        {
            _context.Entry(bid).State = EntityState.Modified;

            var statusAccepted = await _context.Status.Where(x => x.Table == "bid" && x.Description == "Accepted").FirstOrDefaultAsync();
            if (bid.StatusId == statusAccepted.Id)
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                Guid userId = identity.Claims.Where(x => x.Type == "Id").Count() > 0 ? Guid.Parse(identity.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value) : Guid.Empty;
                
                var statusDeclined = await _context.Status.Where(x => x.Table == "bid" && x.Description == "Declined").FirstOrDefaultAsync();

                foreach (Bid item in _context.Bid.Where(x => x.LoadId == bid.LoadId && x.Id != bid.Id))
                {
                    item.Status = statusDeclined;
                }

                var statusLoadAccepted = await _context.Status.Where(x => x.Table == "load" && x.Description == "Accepted").FirstOrDefaultAsync();
                var load = _context.Load.Where(x => x.Id == bid.LoadId).FirstOrDefault();
                load.Status = statusLoadAccepted;
                load.UserIdAccepted = userId;

                Message message = new Message();
                message.UserIdFrom = userId;
                message.UserIdTo = bid.UserId;
                message.Title = "Bid Accepted";
                message.Description = "Your bid has been accepted. Click here to view";
                message.Link = "/bids";
                message.Timestamp = DateTime.Now;
                message.Read = false;
                message.Status = _context.Status.Where(x => x.Table == "message" && x.Description == "Active").FirstOrDefault();
                _context.Message.Add(message);

                HttpClient httpClient = new HttpClient();
                IdRequest data = new IdRequest();
                data.Id = message.UserIdTo;
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                using (var response = httpClient.PostAsync("https://luvirosapi.com:1880/loadgistix/api/message", content))
                {
                    var apiResponse = response.Result;
                }
            }

            await _context.SaveChangesAsync();

            var result = await _context.Bid.Where(x => x.Id == bid.Id).Include(x => x.Vehicle).Include(x => x.Driver).Include(x => x.Status).Include(x => x.Load).ThenInclude(x => x.Status).FirstOrDefaultAsync();

            return new ProcedureResult { Result = true, Id = bid.Id, Data = result };
        }

        // POST: api/Bids
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ProcedureResult> PostBid(Bid bid)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            Guid userId = identity.Claims.Where(x => x.Type == "Id").Count() > 0 ? Guid.Parse(identity.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value) : Guid.Empty;
            bid.UserId = userId;

            _context.Bid.Add(bid);

            var statusAccepted = await _context.Status.Where(x => x.Table == "bid" && x.Description == "Accepted").FirstOrDefaultAsync();
            if(bid.StatusId == statusAccepted.Id)
            {
                var statusDeclined = await _context.Status.Where(x => x.Table == "bid" && x.Description == "Declined").FirstOrDefaultAsync();

                foreach (Bid item in _context.Bid.Where(x => x.LoadId == bid.LoadId && x.Id != bid.Id))
                {
                    item.Status = statusDeclined;
                }

                var statusLoadAccepted = await _context.Status.Where(x => x.Table == "load" && x.Description == "Accepted").FirstOrDefaultAsync();
                var load = _context.Load.Where(x => x.Id == bid.LoadId).FirstOrDefault();
                load.Status = statusLoadAccepted;
                load.UserIdAccepted = userId;

                Message message = new Message();
                message.UserIdFrom = userId;
                message.UserIdTo = bid.UserId;
                message.Title = "Bid Accepted";
                message.Description = "Your bid has been accepted. Click here to view";
                message.Link = "/bids";
                message.Timestamp = DateTime.Now;
                message.Read = false;
                message.Status = _context.Status.Where(x => x.Table == "message" && x.Description == "Active").FirstOrDefault();
                _context.Message.Add(message);

                HttpClient httpClient = new HttpClient();
                IdRequest data = new IdRequest();
                data.Id = message.UserIdTo;
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                using (var response = httpClient.PostAsync("https://luvirosapi.com:1880/loadgistix/api/message", content))
                {
                    var apiResponse = response.Result;
                }
            }

            await _context.SaveChangesAsync();

            var result = await _context.Bid.Where(x => x.Id == bid.Id).Include(x => x.Vehicle).Include(x => x.Driver).Include(x => x.Status).Include(x => x.Load).ThenInclude(x => x.Status).FirstOrDefaultAsync();

            return new ProcedureResult { Result = true, Id = bid.Id, Data = result };
        }

        // DELETE: api/Bids/5
        [HttpPost("delete/{id}")]
        public async Task<ProcedureResult> DeleteBid(Guid id)
        {
            var bid = await _context.Bid.FindAsync(id);
            if (bid == null)
            {
                return new ProcedureResult { Result = false, Message = "Item not found" };
            }

            var statusDeleted = await _context.Status.Where(x => x.Table == "bid" && x.Description == "Deleted").FirstOrDefaultAsync();
            bid.Status = statusDeleted;
            await _context.SaveChangesAsync();

            return new ProcedureResult { Result = true, Id = id };
        }

        private bool BidExists(Guid id)
        {
            return _context.Bid.Any(e => e.Id == id);
        }
    }
}
