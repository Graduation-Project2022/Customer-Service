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
    public class ReactInvoicesController : ControllerBase
    {
        private readonly ReactContext _context;

        public ReactInvoicesController(ReactContext context)
        {
            _context = context;
        }

        //// GET: api/ReactInvoices
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices()
        //{
        //  if (_context.Invoices == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Invoices.ToListAsync();
        //}

        // GET: api/ReactInvoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(string id)
        {
          if (_context.Invoices == null)
          {
              return NotFound();
          }
            //var invoice = await _context.Invoices.FindAsync(id);
            var invoice = await _context.Invoices.FirstOrDefaultAsync(x => x.Msisdn == id);

            if (invoice == null)
            {
                return NotFound();
            }

            return invoice;
        }

        //// PUT: api/ReactInvoices/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutInvoice(int id, Invoice invoice)
        //{
        //    if (id != invoice.InvoiceId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(invoice).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!InvoiceExists(id))
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

        //// POST: api/ReactInvoices
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Invoice>> PostInvoice(Invoice invoice)
        //{
        //  if (_context.Invoices == null)
        //  {
        //      return Problem("Entity set 'ReactContext.Invoices'  is null.");
        //  }
        //    _context.Invoices.Add(invoice);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetInvoice", new { id = invoice.InvoiceId }, invoice);
        //}

        //// DELETE: api/ReactInvoices/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteInvoice(int id)
        //{
        //    if (_context.Invoices == null)
        //    {
        //        return NotFound();
        //    }
        //    var invoice = await _context.Invoices.FindAsync(id);
        //    if (invoice == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Invoices.Remove(invoice);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool InvoiceExists(int id)
        //{
        //    return (_context.Invoices?.Any(e => e.InvoiceId == id)).GetValueOrDefault();
        //}
    }
}
