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
    public class ReactPlansController : ControllerBase
    {
        private readonly ReactContext _context;

        public ReactPlansController(ReactContext context)
        {
            _context = context;
        }

        //// GET: api/ReactPlans
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Plan>>> GetPlans()
        //{
        //  if (_context.Plans == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Plans.ToListAsync();
        //}

        // GET: api/ReactPlans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Plan>>> GetPlan(short id)
        {
          if (_context.Plans == null)
          {
              return NotFound();
          }
            //var plan = await _context.Plans.FindAsync(id);
            var plan = await _context.Plans
                    .Where(b => b.GeneralPlanId == id)
                    .ToListAsync();

            if (plan == null)
            {
                return NotFound();
            }

            return plan;
        }

        //// PUT: api/ReactPlans/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPlan(short id, Plan plan)
        //{
        //    if (id != plan.PlanId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(plan).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PlanExists(id))
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

        //// POST: api/ReactPlans
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Plan>> PostPlan(Plan plan)
        //{
        //  if (_context.Plans == null)
        //  {
        //      return Problem("Entity set 'ReactContext.Plans'  is null.");
        //  }
        //    _context.Plans.Add(plan);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPlan", new { id = plan.PlanId }, plan);
        //}

        //// DELETE: api/ReactPlans/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePlan(short id)
        //{
        //    if (_context.Plans == null)
        //    {
        //        return NotFound();
        //    }
        //    var plan = await _context.Plans.FindAsync(id);
        //    if (plan == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Plans.Remove(plan);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool PlanExists(short id)
        //{
        //    return (_context.Plans?.Any(e => e.PlanId == id)).GetValueOrDefault();
        //}
    }
}
