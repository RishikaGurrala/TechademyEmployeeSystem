using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Techademy_Employee_System.Data;
using Techademy_Employee_System.Models;

namespace Techademy_Employee_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingHoursController : ControllerBase
    {
        private readonly TechademyDbContext _context;

        public WorkingHoursController(TechademyDbContext context)
        {
            _context = context;
        }

        // GET: api/WorkingHours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkingHours>>> Getworkinghours()
        {
            return await _context.workinghours.ToListAsync();
        }

        // GET: api/WorkingHours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkingHours>> GetWorkingHours(string id)
        {
            var workingHours = await _context.workinghours.FindAsync(id);

            if (workingHours == null)
            {
                return NotFound();
            }

            return workingHours;
        }

        // PUT: api/WorkingHours/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkingHours(string id, WorkingHours workingHours)
        {
            if (id != workingHours.CompanyWorkingHours)
            {
                return BadRequest();
            }

            _context.Entry(workingHours).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkingHoursExists(id))
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

        // POST: api/WorkingHours
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkingHours>> PostWorkingHours(WorkingHours workingHours)
        {
            _context.workinghours.Add(workingHours);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WorkingHoursExists(workingHours.CompanyWorkingHours))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetWorkingHours", new { id = workingHours.CompanyWorkingHours }, workingHours);
        }

        // DELETE: api/WorkingHours/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkingHours(string id)
        {
            var workingHours = await _context.workinghours.FindAsync(id);
            if (workingHours == null)
            {
                return NotFound();
            }

            _context.workinghours.Remove(workingHours);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkingHoursExists(string id)
        {
            return _context.workinghours.Any(e => e.CompanyWorkingHours == id);
        }
    }
}
