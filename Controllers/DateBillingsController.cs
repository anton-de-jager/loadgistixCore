using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using loadgistix.Models;

namespace loadgistix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateBillingsController : ControllerBase
    {
        private readonly loadgistixContext _context;

        public DateBillingsController(loadgistixContext context)
        {
            _context = context;
        }

        // GET: api/DateBillings
        [HttpGet]
        public async Task<ProcedureResult> GetDateBilling()
        {
            var result = await _context.DateBilling.ToListAsync();
            return new ProcedureResult { Result = true, Data = result };
        }

        // GET: api/DateBillings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DateBilling>> GetDateBilling(int id)
        {
            var dateBilling = await _context.DateBilling.FindAsync(id);

            if (dateBilling == null)
            {
                return NotFound();
            }

            return dateBilling;
        }

        // PUT: api/DateBillings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDateBilling(int id, DateBilling dateBilling)
        {
            if (id != dateBilling.Id)
            {
                return BadRequest();
            }

            _context.Entry(dateBilling).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DateBillingExists(id))
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

        // POST: api/DateBillings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DateBilling>> PostDateBilling(DateBilling dateBilling)
        {
            _context.DateBilling.Add(dateBilling);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DateBillingExists(dateBilling.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDateBilling", new { id = dateBilling.Id }, dateBilling);
        }

        // DELETE: api/DateBillings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DateBilling>> DeleteDateBilling(int id)
        {
            var dateBilling = await _context.DateBilling.FindAsync(id);
            if (dateBilling == null)
            {
                return NotFound();
            }

            _context.DateBilling.Remove(dateBilling);
            await _context.SaveChangesAsync();

            return dateBilling;
        }

        private bool DateBillingExists(int id)
        {
            return _context.DateBilling.Any(e => e.Id == id);
        }
    }
}
