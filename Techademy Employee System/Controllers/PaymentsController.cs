using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Techademy_Employee_System.Core.IServices;
using Techademy_Employee_System.Core.Services;
using Techademy_Employee_System.Data;
using Techademy_Employee_System.Models;

namespace Techademy_Employee_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService payment;

        public PaymentsController(IPaymentService _payment)
        {
            payment = _payment;
        }
        [HttpGet]
        [Route("Read")]
        public List<Payment> GetPayment()
        {
            return payment.GetPayment();
        }
        [HttpPost]
        [Route("Post")]
        public string PostPayment([FromBody] Payment payments)
        {
            return payment.PostPayment(payments);
        }
        [HttpPut("{DesignationName}")]

        public string PutPayment(string DesignationName, Payment payments)
        {
            return payment.UpdatePayment(DesignationName,payments);

        }
        [HttpDelete("{DesignationName}")]

        public string DeletePayment(string DesignationName)
        {
            return payment.DeletePayment(DesignationName);
        }

        //// GET: api/Payments
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Payment>>> Getpayments()
        //{
        //    return await _context.payments.ToListAsync();
        //}

        //// GET: api/Payments/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Payment>> GetPayment(int id)
        //{
        //    var payment = await _context.payments.FindAsync(id);

        //    if (payment == null)
        //    {
        //        return NotFound();
        //    }

        //    return payment;
        //}

        //// PUT: api/Payments/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPayment(int id, Payment payment)
        //{
        //    if (id != payment.id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(payment).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PaymentExists(id))
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

        //// POST: api/Payments
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Payment>> PostPayment(Payment payment)
        //{
        //    _context.payments.Add(payment);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPayment", new { id = payment.id }, payment);
        //}

        //// DELETE: api/Payments/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePayment(int id)
        //{
        //    var payment = await _context.payments.FindAsync(id);
        //    if (payment == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.payments.Remove(payment);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool PaymentExists(int id)
        //{
        //    return _context.payments.Any(e => e.id == id);
        //}
    }
}
