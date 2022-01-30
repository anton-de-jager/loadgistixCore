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
    public class ClientNotesController : ControllerBase
    {
        private readonly loadgistixContext _context;

        public ClientNotesController(loadgistixContext context)
        {
            _context = context;
        }

        // GET: api/ClientNotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientNote>>> GetClientNote()
        {
            return await _context.ClientNote.ToListAsync();
        }

        // GET: api/ClientNotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientNote>> GetClientNote(Guid id)
        {
            var clientNote = await _context.ClientNote.FindAsync(id);

            if (clientNote == null)
            {
                return NotFound();
            }

            return clientNote;
        }

        // POST: api/Clients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPost("{clientId}")]
        public async Task<ProcedureResult> GetNotes(Guid clientId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            Guid id = identity.Claims.Where(x => x.Type == "Id").Count() > 0 ? Guid.Parse(identity.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value) : Guid.Empty;

            var items = await _context.ClientNote.Where(x => x.ClientId == clientId).ToListAsync();

            List<Note> result = new List<Note>();
            foreach (ClientNote item in items)
            {
                Note note = new Note();
                note.Id = item.Id;
                note.ClientId = item.ClientId;
                note.Content = item.Note;
                note.CreatedBy = item.CreatedBy;
                note.CreatedOn = item.CreatedOn;
                note.IsMine = item.CreatedBy == id ? true : false;
                result.Add(note);
            };

            return new ProcedureResult { Result = true, Data = result };
        }

        // PUT: api/ClientNotes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPut]
        public async Task<ProcedureResult> PutClientNote(ClientNote clientNote)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            Guid id = identity.Claims.Where(x => x.Type == "Id").Count() > 0 ? Guid.Parse(identity.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value) : Guid.Empty;

            clientNote.CreatedBy = id;
            clientNote.CreatedOn = DateTime.Now;
            _context.Entry(clientNote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientNoteExists(clientNote.Id))
                {
                    return new ProcedureResult { Result = false, Message = "Item not found" };
                }
                else
                {
                    throw;
                }
            }

            var items = await _context.ClientNote.Where(x => x.ClientId == clientNote.ClientId).ToListAsync();

            List<Note> result = new List<Note>();
            foreach (ClientNote item in items)
            {
                Note note = new Note();
                note.Id = item.Id;
                note.ClientId = item.ClientId;
                note.Content = item.Note;
                note.CreatedBy = item.CreatedBy;
                note.CreatedOn = item.CreatedOn;
                note.IsMine = item.CreatedBy == id ? true : false;
                result.Add(note);
            };

            return new ProcedureResult { Result = true, Id = clientNote.Id, Data = result };
        }

        // POST: api/ClientNotes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPost]
        public async Task<ProcedureResult> PostClientNote(ClientNote clientNote)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            Guid id = identity.Claims.Where(x => x.Type == "Id").Count() > 0 ? Guid.Parse(identity.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value) : Guid.Empty;

            clientNote.CreatedBy = id;
            clientNote.CreatedOn = DateTime.Now;

            _context.ClientNote.Add(clientNote);
            await _context.SaveChangesAsync();

            var items = await _context.ClientNote.Where(x => x.ClientId == clientNote.ClientId).ToListAsync();

            List<Note> result = new List<Note>();
            foreach (ClientNote item in items)
            {
                Note note = new Note();
                note.Id = item.Id;
                note.ClientId = item.ClientId;
                note.Content = item.Note;
                note.CreatedBy = item.CreatedBy;
                note.CreatedOn = item.CreatedOn;
                note.IsMine = item.CreatedBy == id ? true : false;
                result.Add(note);
            };

            return new ProcedureResult { Result = true, Id = clientNote.Id, Data = result };
        }

        // DELETE: api/ClientNotes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientNote>> DeleteClientNote(Guid id)
        {
            var clientNote = await _context.ClientNote.FindAsync(id);
            if (clientNote == null)
            {
                return NotFound();
            }

            _context.ClientNote.Remove(clientNote);
            await _context.SaveChangesAsync();

            return clientNote;
        }

        private bool ClientNoteExists(Guid id)
        {
            return _context.ClientNote.Any(e => e.Id == id);
        }
    }
}
