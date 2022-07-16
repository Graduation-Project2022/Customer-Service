using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactCustomerService.Data;
using ReactCustomerService.Models;

namespace ReactCustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactCurrentQuantityBalancesController : ControllerBase
    {
        private readonly ReactContext _context;

        public ReactCurrentQuantityBalancesController(ReactContext context)
        {
            _context = context;
        }

        //// GET: api/ReactCurrentQuantityBalances
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CurrentQuantityBalance>>> GetCurrentQuantityBalances()
        //{
        //  if (_context.CurrentQuantityBalances == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.CurrentQuantityBalances.ToListAsync();
        //}

        // GET: api/ReactCurrentQuantityBalances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CurrentQuantityBalance>>> GetCurrentQuantityBalance(string id)
        {
          if (_context.CurrentQuantityBalances == null)
          {
              return NotFound();
          }
   
            var currentQuantityBalance = await _context.CurrentQuantityBalances
                      .Where(b => b.Msisdn == id)
                      .ToListAsync(); 

            if (currentQuantityBalance == null)
            {
                return NotFound();
            }

            return currentQuantityBalance;
        }

        //// PUT: api/ReactCurrentQuantityBalances/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCurrentQuantityBalance(string id, CurrentQuantityBalance currentQuantityBalance)
        //{
        //    if (id != currentQuantityBalance.Msisdn)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(currentQuantityBalance).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CurrentQuantityBalanceExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/ReactCurrentQuantityBalances
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<CurrentQuantityBalance>> PostCurrentQuantityBalance(CurrentQuantityBalance currentQuantityBalance)
        //{
        //  if (_context.CurrentQuantityBalances == null)
        //  {
        //      return Problem("Entity set 'ReactContext.CurrentQuantityBalances'  is null.");
        //  }
        //    _context.CurrentQuantityBalances.Add(currentQuantityBalance);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (CurrentQuantityBalanceExists(currentQuantityBalance.Msisdn))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetCurrentQuantityBalance", new { id = currentQuantityBalance.Msisdn }, currentQuantityBalance);
        //}

        //// DELETE: api/ReactCurrentQuantityBalances/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCurrentQuantityBalance(string id)
        //{
        //    if (_context.CurrentQuantityBalances == null)
        //    {
        //        return NotFound();
        //    }
        //    var currentQuantityBalance = await _context.CurrentQuantityBalances.FindAsync(id);
        //    if (currentQuantityBalance == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.CurrentQuantityBalances.Remove(currentQuantityBalance);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool CurrentQuantityBalanceExists(string id)
        //{
        //    return (_context.CurrentQuantityBalances?.Any(e => e.Msisdn == id)).GetValueOrDefault();
        //}
    }
}
