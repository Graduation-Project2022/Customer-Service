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
    public class PlansServicesPricesController : ControllerBase
    {
        private readonly ReactContext _context;

        public PlansServicesPricesController(ReactContext context)
        {
            _context = context;
        }

        // GET: api/PlansServicesPrices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlansServicesPrice>>> GetPlansServicesPrices()
        {
            if (_context.PlansServicesPrices == null)
            {
                return NotFound();
            }
            return await _context.PlansServicesPrices.ToListAsync();
        }

        // GET: api/PlansServicesPrices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PlansServicesPrice>>> GetPlansServicesPrice(short id)
        {
          if (_context.PlansServicesPrices == null)
          {
              return NotFound();
          }
            var plansServicesPrice = await _context.PlansServicesPrices.Where(b => b.PlanId == id).ToListAsync();
            if (plansServicesPrice == null)
            {
                return NotFound();
            }

            return plansServicesPrice;
        }

        //// PUT: api/PlansServicesPrices/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPlansServicesPrice(short id, PlansServicesPrice plansServicesPrice)
        //{
        //    if (id != plansServicesPrice.PlanId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(plansServicesPrice).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PlansServicesPriceExists(id))
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

        //// POST: api/PlansServicesPrices
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<PlansServicesPrice>> PostPlansServicesPrice(PlansServicesPrice plansServicesPrice)
        //{
        //  if (_context.PlansServicesPrices == null)
        //  {
        //      return Problem("Entity set 'ReactContext.PlansServicesPrices'  is null.");
        //  }
        //    _context.PlansServicesPrices.Add(plansServicesPrice);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (PlansServicesPriceExists(plansServicesPrice.PlanId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetPlansServicesPrice", new { id = plansServicesPrice.PlanId }, plansServicesPrice);
        //}

        //// DELETE: api/PlansServicesPrices/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePlansServicesPrice(short id)
        //{
        //    if (_context.PlansServicesPrices == null)
        //    {
        //        return NotFound();
        //    }
        //    var plansServicesPrice = await _context.PlansServicesPrices.FindAsync(id);
        //    if (plansServicesPrice == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.PlansServicesPrices.Remove(plansServicesPrice);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool PlansServicesPriceExists(short id)
        //{
        //    return (_context.PlansServicesPrices?.Any(e => e.PlanId == id)).GetValueOrDefault();
        //}
    }
}
