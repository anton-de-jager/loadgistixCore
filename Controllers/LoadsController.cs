using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using loadgistix.Models;
using System.Security.Claims;
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace loadgistix.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoadsController : ControllerBase
    {
        private readonly loadgistixContext _context;

        public LoadsController(loadgistixContext context)
        {
            _context = context;
        }

        // GET: api/Loads
        [HttpGet]
        public async Task<ProcedureResult> GetLoad()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            Guid id = identity.Claims.Where(x => x.Type == "Id").Count() > 0 ? Guid.Parse(identity.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value) : Guid.Empty;

            var statusDeleted = await _context.Status.Where(x => x.Table == "load" && x.Description == "Deleted").FirstOrDefaultAsync();
            var result = await _context.Load.Where(x => x.StatusId != statusDeleted.Id && x.UserId == id).Include(x => x.LoadType).Include(x => x.User).Include(x => x.Status).Include(x => x.Bid).ThenInclude(x => x.Status).Include(x => x.Bid).ThenInclude(x => x.Load).Include(x => x.Bid).ThenInclude(x => x.Vehicle).Include(x => x.Bid).ThenInclude(x => x.Driver).ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // GET: api/Loads/user
        [HttpGet("user")]
        public async Task<ProcedureResult> GetLoadsByUserId()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            Guid id = identity.Claims.Where(x => x.Type == "Id").Count() > 0 ? Guid.Parse(identity.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value) : Guid.Empty;

            var statusDeleted = await _context.Status.Where(x => x.Table == "load" && x.Description == "Deleted").FirstOrDefaultAsync();
            var result = await _context.Load.Where(x => x.Status != statusDeleted && x.UserId == id).Include(x => x.LoadType).Include(x => x.User).Include(x => x.Status).Include(x => x.Bid).ThenInclude(x => x.Status).Include(x => x.Bid).ThenInclude(x => x.Load).Include(x => x.Bid).ThenInclude(x => x.Vehicle).Include(x => x.Bid).ThenInclude(x => x.Driver).ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // GET: api/Loads/user
        [HttpPost("available")]
        public ProcedureResult GetLoadsAvailable(LoadsAvailableRequest request)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            Guid id = identity.Claims.Where(x => x.Type == "Id").Count() > 0 ? Guid.Parse(identity.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value) : Guid.Empty;

            SqlParameter userId = new SqlParameter("@userId", id);
            SqlParameter distance = new SqlParameter("@distance", request.Distance);
            SqlParameter weight = new SqlParameter("@weight", request.Weight);
            SqlParameter volumeCm = new SqlParameter("@volumeCm", request.VolumeCm);
            SqlParameter volumeLt = new SqlParameter("@volumeLt", request.VolumeLt);
            var result = _context.Load.FromSqlRaw("EXECUTE [dbo].[sp_action_loads_available] @userId, @distance, @weight, @volumeCm, @volumeLt", userId, distance, weight, volumeCm, volumeLt).ToList();

            return new ProcedureResult { Result = true, Data = result };
        }

        // GET: api/Loads/user
        [HttpPost("bid")]
        public async Task<ProcedureResult> GetBidsFromLoad(IdRequest request)
        {
            var statusDeleted = await _context.Status.Where(x => x.Table == "bid" && x.Description == "Deleted").FirstOrDefaultAsync();
            var result = await _context.Bid.Where(x => x.Status != statusDeleted).Include(x => x.Status).Include(x => x.Load).Include(x => x.Vehicle).Include(x => x.Driver).ToListAsync();
            
            return new ProcedureResult { Result = true, Data = result };
        }

        // GET: api/Loads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Load>> GetLoad(Guid id)
        {
            var load = await _context.Load.FindAsync(id);

            if (load == null)
            {
                return NotFound();
            }

            return load;
        }

        // PUT: api/Loads/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<ProcedureResult> PutLoad(Load load)
        {
            _context.Entry(load).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoadExists(load.Id))
                {
                    return new ProcedureResult { Result = false, Message = "Item not found" };
                }
                else
                {
                    throw;
                }
            }

            var result = await _context.Load.Where(x => x.Id == load.Id).Include(x => x.LoadType).Include(x => x.User).Include(x => x.Status).Include(x => x.Bid).ThenInclude(x => x.Status).FirstOrDefaultAsync();

            return new ProcedureResult { Result = true, Id = load.Id, Data = result };
        }

        // POST: api/Loads
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ProcedureResult> PostLoad(Load load)
        {
            _context.Load.Add(load);
            await _context.SaveChangesAsync();

            var result = await _context.Load.Where(x => x.Id == load.Id).Include(x => x.LoadType).Include(x => x.User).Include(x => x.Status).Include(x => x.Bid).ThenInclude(x => x.Status).FirstOrDefaultAsync();

            return new ProcedureResult { Result = true, Id = load.Id, Data = result };
        }

        // POST: api/Loads
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{status}")]
        public ProcedureResult UpdateStatus(LoadStatusChangeRequest request)
        {

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            Guid userId = identity.Claims.Where(x => x.Type == "Id").Count() > 0 ? Guid.Parse(identity.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value) : Guid.Empty;

            var load = _context.Load.Where(x => x.Id == request.Id).Include(x => x.User).Include(x => x.Bid).ThenInclude(x => x.Status).Include(x => x.Bid).ThenInclude(x => x.User).FirstOrDefault();
            var status = _context.Status.Where(x => x.Table == "load" && x.Description == request.Description).FirstOrDefault();
            var statusAccepted = _context.Status.Where(x => x.Table == "bid" && x.Description == "Accepted").FirstOrDefault();

            var userLoad = load.User;
            var bid = load.Bid.Where(x => x.Status.Id == statusAccepted.Id).FirstOrDefault();
            var userBid = bid.User;

            load.Status = status;
            switch (request.Description)
            {
                case "Accepted":
                    load.UserIdAccepted = userId;
                    break;
                case "Loaded":
                    load.UserIdLoaded = userId;
                    break;
                case "In Transit":
                    load.UserIdLoadedConfirmed = userId;
                    break;
                case "Delivered":
                    load.UserIdDelivered = userId;
                    break;
                case "Completed":
                    load.UserIdDeliveredConfirmed = userId;
                    break;
                default:
                    break;
            }

            _context.SaveChanges();

            SendMessage(
                userId,
                userId == userLoad.Id ? userBid.Id : userLoad.Id,
                "Load Status Updated",
                "Load status has changed to " + request.Description,
                userId == userLoad.Id ? "/bids" : "/loads"
                );

            //SqlParameter _userId = new SqlParameter("@userId", userId);
            //SqlParameter _id = new SqlParameter("@id", request.Id);
            //SqlParameter _description = new SqlParameter("@description", request.Description);
            //var result = _context.Load.FromSqlRaw("EXECUTE [dbo].[sp_load_status] @id, @userId, @description", _id, _userId, _description);
            ////var result = _context.Load.FromSqlRaw("EXECUTE [dbo].[sp_load_status] @id, @userId, @description", _id, _userId, _description).Where(x => x.Id == request.Id).Include(x => x.LoadType).Include(x => x.User).Include(x => x.Status).Include(x => x.Bid).ThenInclude(x => x.Status).FirstOrDefault();
            //var _result = _context.Load.Where(x => x.Id == request.Id).Include(x => x.LoadType).Include(x => x.User).Include(x => x.Status).Include(x => x.Bid).ThenInclude(x => x.Status).FirstOrDefault();

            var _result = _context.Load.Where(x => x.Id == request.Id).Include(x => x.LoadType).Include(x => x.User).Include(x => x.Status).Include(x => x.Bid).ThenInclude(x => x.Status).FirstOrDefault();

            return new ProcedureResult { Result = true, Data = _result };
        }

        private void SendMessage(Guid userIdFrom, Guid userIdTo, string title, string description, string link)
        {
            Message message = new Message();
            message.UserIdFrom = userIdFrom;
            message.UserIdTo = userIdTo;
            message.Title = title;
            message.Description = description;
            message.Link = link;
            message.Timestamp = DateTime.Now;
            message.Read = false;
            message.Status = _context.Status.Where(x => x.Table == "message" && x.Description == "Active").FirstOrDefault();
            _context.Message.Add(message);
            _context.SaveChanges();

            HttpClient httpClient = new HttpClient();
            IdRequest data = new IdRequest();
            data.Id = message.UserIdTo;
            StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            using (var response = httpClient.PostAsync("https://luvirosapi.com:1880/loadgistix/api/message", content))
            {
                var apiResponse = response.Result;
            }
        }

        // DELETE: api/Loads/5
        [HttpPost("delete/{id}")]
        public async Task<ProcedureResult> DeleteLoad(Guid id)
        {
            var load = await _context.Load.FindAsync(id);
            if (load == null)
            {
                return new ProcedureResult { Result = false, Message = "Item not found" };
            }

            var statusDeleted = await _context.Status.Where(x => x.Table == "load" && x.Description == "Deleted").FirstOrDefaultAsync();
            load.Status = statusDeleted;
            await _context.SaveChangesAsync();

            return new ProcedureResult { Result = true, Id = id };
        }

        [HttpPost("uploadImage/{filename}"), DisableRequestSizeLimit]
        public IActionResult Upload(string filename)
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Images", "Loads");
                var pathToSave = Path.Combine(System.IO.Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fullPath = Path.Combine(pathToSave, filename);
                    var dbPath = Path.Combine(folderName, filename);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    var load = _context.Load.FindAsync(Guid.Parse(filename.Substring(0, filename.IndexOf(".")))).Result;
                    load.Avatar = filename.Replace(filename.Substring(0, filename.IndexOf(".")), "");
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

        private bool LoadExists(Guid id)
        {
            return _context.Load.Any(e => e.Id == id);
        }
    }
}