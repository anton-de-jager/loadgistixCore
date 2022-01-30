using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using loadgistix.Models;
using System.IO;
using System.Net.Http.Headers;

namespace loadgistix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly loadgistixContext _context;

        public UsersController(loadgistixContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProcedureResult>> PostUser(RegisterRequest model)
        {
            if (_context.User.Where(x => x.Email == model.Email).Count() > 0)
            {
                return CreatedAtAction("PostUser", new { id = Guid.Empty }, new ProcedureResult { Result = false, Message = "Email already exists!" });
            }
            else
            {
                User userNew = new User();
                userNew.Id = Guid.NewGuid();
                userNew.Company = model.Company;
                userNew.FirstName = model.FirstName;
                userNew.LastName = model.LastName;
                userNew.Phone = model.Phone;
                userNew.Email = model.Email;
                userNew.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
                userNew.Status = _context.Status.Where(x => x.Table == "user" && x.Description == "Registered").FirstOrDefault();
                _context.User.Add(userNew);
                await _context.SaveChangesAsync();

                UserPermission userPermissionDashboard = new UserPermission();
                userPermissionDashboard.Permission = _context.Permission.Where(x => x.Description == "dashboard").FirstOrDefault();
                userPermissionDashboard.UserId = userNew.Id;
                _context.UserPermission.Add(userPermissionDashboard);
                await _context.SaveChangesAsync();

                if (model.Vehicles == true)
                {
                    UserPermission userPermissionVehicles = new UserPermission();
                    userPermissionVehicles.Permission = _context.Permission.Where(x => x.Description == "vehicles").FirstOrDefault();
                    userPermissionVehicles.UserId = userNew.Id;
                    _context.UserPermission.Add(userPermissionVehicles);

                    UserPermission userPermissionDrivers = new UserPermission();
                    userPermissionDrivers.Permission = _context.Permission.Where(x => x.Description == "drivers").FirstOrDefault();
                    userPermissionDrivers.UserId = userNew.Id;
                    _context.UserPermission.Add(userPermissionDrivers);

                    UserPermission userPermissionBids = new UserPermission();
                    userPermissionBids.Permission = _context.Permission.Where(x => x.Description == "bids").FirstOrDefault();
                    userPermissionBids.UserId = userNew.Id;
                    _context.UserPermission.Add(userPermissionBids);

                    await _context.SaveChangesAsync();
                }
                if (model.Loads == true)
                {
                    UserPermission userPermission = new UserPermission();
                    userPermission.Permission = _context.Permission.Where(x => x.Description == "loads").FirstOrDefault();
                    userPermission.UserId = userNew.Id;
                    _context.UserPermission.Add(userPermission);
                    await _context.SaveChangesAsync();
                }
                if (model.Adverts == true)
                {
                    UserPermission userPermission = new UserPermission();
                    userPermission.Permission = _context.Permission.Where(x => x.Description == "adverts").FirstOrDefault();
                    userPermission.UserId = userNew.Id;
                    _context.UserPermission.Add(userPermission);
                    await _context.SaveChangesAsync();
                }
                if (model.Directory == true)
                {
                    UserPermission userPermission = new UserPermission();
                    userPermission.Permission = _context.Permission.Where(x => x.Description == "directory").FirstOrDefault();
                    userPermission.UserId = userNew.Id;
                    _context.UserPermission.Add(userPermission);
                    await _context.SaveChangesAsync();
                }

                return CreatedAtAction("PostUser", new { id = userNew.Id }, new ProcedureResult { Result = true, Id = userNew.Id, Data = userNew });
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(Guid id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        [HttpPost("uploadImage/{filename}"), DisableRequestSizeLimit]
        public IActionResult Upload(string filename)
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Images", "Users");
                var pathToSave = Path.Combine(System.IO.Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fullPath = Path.Combine(pathToSave, filename);
                    var dbPath = Path.Combine(folderName, filename);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    var user = _context.User.FindAsync(Guid.Parse(filename.Substring(0, filename.IndexOf(".")))).Result;
                    user.Avatar = filename.Replace(filename.Substring(0, filename.IndexOf(".")), "");
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

        private bool UserExists(Guid id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
