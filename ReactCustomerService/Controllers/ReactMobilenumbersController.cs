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
    public class ReactMobilenumbersController : ControllerBase
    {
        private readonly ReactContext _context;

        public ReactMobilenumbersController(ReactContext context)
        {
            _context = context;
        }

        //// GET: api/ReactMobilenumbers
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Mobilenumber>>> GetMobilenumbers()
        //{
        //  if (_context.Mobilenumbers == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Mobilenumbers.ToListAsync();
        //}

        // GET: api/ReactMobilenumbers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mobilenumber>> GetMobilenumber(string id)
        {
          if (_context.Mobilenumbers == null)
          {
              return NotFound();
          }
            var mobilenumber = await _context.Mobilenumbers.FindAsync(id);

            if (mobilenumber == null)
            {
                return NotFound();
            }

            return mobilenumber;
        }

        // PUT: api/ReactMobilenumbers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMobilenumber(string id, Mobilenumber mobilenumber)
        {
            if (id != mobilenumber.Msisdn)
            {
                return BadRequest();
            }

            _context.Entry(mobilenumber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MobilenumberExists(id))
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

        //// POST: api/ReactMobilenumbers
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Mobilenumber>> PostMobilenumber(Mobilenumber mobilenumber)
        //{
        //  if (_context.Mobilenumbers == null)
        //  {
        //      return Problem("Entity set 'ReactContext.Mobilenumbers'  is null.");
        //  }
        //    _context.Mobilenumbers.Add(mobilenumber);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (MobilenumberExists(mobilenumber.Msisdn))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetMobilenumber", new { id = mobilenumber.Msisdn }, mobilenumber);
        //}

        //// DELETE: api/ReactMobilenumbers/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteMobilenumber(string id)
        //{
        //    if (_context.Mobilenumbers == null)
        //    {
        //        return NotFound();
        //    }
        //    var mobilenumber = await _context.Mobilenumbers.FindAsync(id);
        //    if (mobilenumber == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Mobilenumbers.Remove(mobilenumber);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool MobilenumberExists(string id)
        {
            return (_context.Mobilenumbers?.Any(e => e.Msisdn == id)).GetValueOrDefault();
        }
    }
}
