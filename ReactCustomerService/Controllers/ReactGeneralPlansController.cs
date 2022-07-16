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
    public class ReactGeneralPlansController : ControllerBase
    {
        private readonly ReactContext _context;

        public ReactGeneralPlansController(ReactContext context)
        {
            _context = context;
        }

        // GET: api/ReactGeneralPlans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneralPlan>>> GetGeneralPlans()
        {
          if (_context.GeneralPlans == null)
          {
              return NotFound();
          }
            return await _context.GeneralPlans.ToListAsync();
        }

        // GET: api/ReactGeneralPlans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<GeneralPlan>>> GetGeneralPlan(string id)
        {
          if (_context.GeneralPlans == null)
          {
              return NotFound();
          }
            //var generalPlan = await _context.GeneralPlans.FindAsync(id);
            var generalPlan = await _context.GeneralPlans.Where(b => b.CompanyCode == id).ToListAsync();

            if (generalPlan == null)
            {
                return NotFound();
            }

            return generalPlan;
        }

        //// PUT: api/ReactGeneralPlans/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutGeneralPlan(short id, GeneralPlan generalPlan)
        //{
        //    if (id != generalPlan.GeneralPlanId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(generalPlan).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!GeneralPlanExists(id))
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

        //// POST: api/ReactGeneralPlans
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<GeneralPlan>> PostGeneralPlan(GeneralPlan generalPlan)
        //{
        //  if (_context.GeneralPlans == null)
        //  {
        //      return Problem("Entity set 'ReactContext.GeneralPlans'  is null.");
        //  }
        //    _context.GeneralPlans.Add(generalPlan);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetGeneralPlan", new { id = generalPlan.GeneralPlanId }, generalPlan);
        //}

        //// DELETE: api/ReactGeneralPlans/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteGeneralPlan(short id)
        //{
        //    if (_context.GeneralPlans == null)
        //    {
        //        return NotFound();
        //    }
        //    var generalPlan = await _context.GeneralPlans.FindAsync(id);
        //    if (generalPlan == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.GeneralPlans.Remove(generalPlan);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool GeneralPlanExists(short id)
        //{
        //    return (_context.GeneralPlans?.Any(e => e.GeneralPlanId == id)).GetValueOrDefault();
        //}
    }
}
