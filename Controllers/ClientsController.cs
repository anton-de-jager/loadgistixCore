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

namespace loadgistix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly loadgistixContext _context;

        public ClientsController(loadgistixContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public async Task<ProcedureResult> GetClient()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            Guid id = identity.Claims.Where(x => x.Type == "Id").Count() > 0 ? Guid.Parse(identity.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value) : Guid.Empty;

            var statusDeleted = await _context.Status.Where(x => x.Table == "client" && x.Description == "Deleted").FirstOrDefaultAsync();
            var result = await _context.Client.Where(x => x.Status != statusDeleted && x.UserId == id).Include(x => x.Status).Include(x => x.DateBilling).ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(Guid id)
        {
            var client = await _context.Client.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPut]
        public async Task<ProcedureResult> PutClient(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(client.Id))
                {
                    return new ProcedureResult { Result = false, Message = "Item not found" };
                }
                else
                {
                    throw;
                }
            }

            var result = await _context.Client.Where(x => x.Id == client.Id).Include(x => x.Status).Include(x => x.DateBilling).FirstOrDefaultAsync();

            return new ProcedureResult { Result = true, Id = client.Id, Data = result };
        }

        // POST: api/Clients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPost]
        public async Task<ProcedureResult> PostClient(Client client)
        {
            _context.Client.Add(client);
            await _context.SaveChangesAsync();

            var result = await _context.Client.Where(x => x.Id == client.Id).Include(x => x.Status).Include(x => x.DateBilling).FirstOrDefaultAsync();

            return new ProcedureResult { Result = true, Id = client.Id, Data = result };
        }

        // DELETE: api/Clients/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ProcedureResult> DeleteClient(Guid id)
        {
            var client = await _context.Client.FindAsync(id);
            if (client == null)
            {
                return new ProcedureResult { Result = false, Message = "Item not found" };
            }

            var statusDeleted = await _context.Status.Where(x => x.Table == "client" && x.Description == "Deleted").FirstOrDefaultAsync();
            client.Status = statusDeleted;
            await _context.SaveChangesAsync();

            return new ProcedureResult { Result = true, Id = id };
        }

        private bool ClientExists(Guid id)
        {
            return _context.Client.Any(e => e.Id == id);
        }
    }
}
