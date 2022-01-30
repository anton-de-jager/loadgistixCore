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
    public class MessagesController : ControllerBase
    {
        private readonly loadgistixContext _context;

        public MessagesController(loadgistixContext context)
        {
            _context = context;
        }

        // GET: api/Messages
        [HttpGet]
        public async Task<List<Message>> GetMessage()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            Guid id = identity.Claims.Where(x => x.Type == "Id").Count() > 0 ? Guid.Parse(identity.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value) : Guid.Empty;

            var statusDeleted = await _context.Status.Where(x => x.Table == "message" && x.Description == "Deleted").FirstOrDefaultAsync();
            var result = await _context.Message.AsNoTracking().Where(x => x.Status != statusDeleted && x.UserIdTo == id).ToListAsync();
            return result;
        }

        // GET: api/Messages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessage(Guid id)
        {
            var message = await _context.Message.FindAsync(id);

            if (message == null)
            {
                return NotFound();
            }

            return message;
        }

        // PUT: api/Messages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<ActionResult<Message>> PutMessage(Message notification)
        {
            if (notification == null)
            {
                return BadRequest();
            }

            _context.Entry(notification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageExists(notification.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return notification;
        }

        // PUT: api/Messages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("all")]
        public async Task<IActionResult> PutMessages()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            Guid id = identity.Claims.Where(x => x.Type == "Id").Count() > 0 ? Guid.Parse(identity.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value) : Guid.Empty;

            var messages = await _context.Message.Where(x => x.UserIdTo == id).ToListAsync();
            foreach (Message message in messages)
            {
                _context.Entry(message).State = EntityState.Modified;
                message.Read = true;
            }
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Messages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Message>> PostMessage(Message message)
        {
            _context.Message.Add(message);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessage", new { id = message.Id }, message);
        }

        // POST: api/Messages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("delete")]
        public async Task<bool> DeleteMessage(IdRequest request)
        {
            var message = await _context.Message.FindAsync(request.Id);
            var statusDeleted = await _context.Status.Where(x => x.Table == "message" && x.Description == "Deleted").FirstOrDefaultAsync();
            message.Status = statusDeleted;
            await _context.SaveChangesAsync();
            return true;
        }

        // POST: api/Messages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("delete/all")]
        public async Task<bool> DeleteAllMessages()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            Guid id = identity.Claims.Where(x => x.Type == "Id").Count() > 0 ? Guid.Parse(identity.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value) : Guid.Empty;

            var statusDeleted = await _context.Status.Where(x => x.Table == "message" && x.Description == "Deleted").FirstOrDefaultAsync();

            var messages = await _context.Message.Where(x => x.UserIdTo == id).ToListAsync();
            foreach (Message message in messages)
            {
                message.Status = statusDeleted;
            }
            await _context.SaveChangesAsync();
            return true;
        }

        // POST: api/Messages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("read")]
        public async Task<bool> MarkMessage(Message message)
        {
            var statusDeleted = await _context.Status.Where(x => x.Table == "message" && x.Description == "Deleted").FirstOrDefaultAsync();
            message.Status = statusDeleted;
            await _context.SaveChangesAsync();
            return true;
        }

        // POST: api/Messages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("read/all")]
        public async Task<bool> MarkAllMessages()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            Guid id = identity.Claims.Where(x => x.Type == "Id").Count() > 0 ? Guid.Parse(identity.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value) : Guid.Empty;

            var statusDeleted = await _context.Status.Where(x => x.Table == "message" && x.Description == "Deleted").FirstOrDefaultAsync();

            var messages = await _context.Message.Where(x => x.UserIdTo == id).ToListAsync();
            foreach (Message message in messages)
            {
                message.Status = statusDeleted;
            }
            await _context.SaveChangesAsync();
            return true;
        }

        private bool MessageExists(Guid id)
        {
            return _context.Message.Any(e => e.Id == id);
        }
    }
}
