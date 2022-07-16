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
    public class ReactPlansQuantitiesController : ControllerBase
    {
        private readonly ReactContext _context;

        public ReactPlansQuantitiesController(ReactContext context)
        {
            _context = context;
        }

        //// GET: api/ReactPlansQuantities
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<PlansQuantity>>> GetPlansQuantities()
        //{
        //  if (_context.PlansQuantities == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.PlansQuantities.ToListAsync();
        //}

        // GET: api/ReactPlansQuantities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PlansQuantity>>> GetPlansQuantity(short id)
        {
          if (_context.PlansQuantities == null)
          {
              return NotFound();
          }
            var plansQuantity = await _context.PlansQuantities
                    .Where(b => b.PlanId == id)
                    .ToListAsync();

            if (plansQuantity == null)
            {
                return NotFound();
            }

            return plansQuantity;
        }

        //// PUT: api/ReactPlansQuantities/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPlansQuantity(short id, PlansQuantity plansQuantity)
        //{
        //    if (id != plansQuantity.PlanId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(plansQuantity).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PlansQuantityExists(id))
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

        //// POST: api/ReactPlansQuantities
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<PlansQuantity>> PostPlansQuantity(PlansQuantity plansQuantity)
        //{
        //  if (_context.PlansQuantities == null)
        //  {
        //      return Problem("Entity set 'ReactContext.PlansQuantities'  is null.");
        //  }
        //    _context.PlansQuantities.Add(plansQuantity);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (PlansQuantityExists(plansQuantity.PlanId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetPlansQuantity", new { id = plansQuantity.PlanId }, plansQuantity);
        //}

        //// DELETE: api/ReactPlansQuantities/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePlansQuantity(short id)
        //{
        //    if (_context.PlansQuantities == null)
        //    {
        //        return NotFound();
        //    }
        //    var plansQuantity = await _context.PlansQuantities.FindAsync(id);
        //    if (plansQuantity == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.PlansQuantities.Remove(plansQuantity);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool PlansQuantityExists(short id)
        //{
        //    return (_context.PlansQuantities?.Any(e => e.PlanId == id)).GetValueOrDefault();
        //}
    }
}
