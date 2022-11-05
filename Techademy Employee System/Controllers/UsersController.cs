using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Techademy_Employee_System.Core.IServices;
using Techademy_Employee_System.Data;
using Techademy_Employee_System.DTO;
using Techademy_Employee_System.Models;

namespace Techademy_Employee_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrgin")]
    public class UsersController : ControllerBase
    {
        private readonly IRegistrationService registerService;


        public UsersController(IRegistrationService _registerService)
        {
            registerService = _registerService;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("SignUp")]
        public string PostRegistration([FromBody] User user)
        {
            return registerService.SignUp(user);
        }

        [HttpPost]
        [Route("SignIn")]
        [AllowAnonymous]
        public string SignIn([FromBody] LoginDTO loginDTO)
        {
            return registerService.SignIn(loginDTO);
        }
        //    private readonly TechademyDbContext _context;

        //    public UsersController(TechademyDbContext context)
        //    {
        //        _context = context;
        //    }

        //    // GET: api/Users
        //    [HttpGet]
        //    public async Task<ActionResult<IEnumerable<User>>> Getusers()
        //    {
        //        return await _context.users.ToListAsync();
        //    }

        //    // GET: api/Users/5
        //    [HttpGet("{id}")]
        //    public async Task<ActionResult<User>> GetUser(int id)
        //    {
        //        var user = await _context.users.FindAsync(id);

        //        if (user == null)
        //        {
        //            return NotFound();
        //        }

        //        return user;
        //    }

        //    // PUT: api/Users/5
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutUser(int id, User user)
        //    {
        //        if (id != user.UserId)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(user).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UserExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }

        //    // POST: api/Users
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPost]
        //    public async Task<ActionResult<User>> PostUser(User user)
        //    {
        //        _context.users.Add(user);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        //    }

        //    // DELETE: api/Users/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeleteUser(int id)
        //    {
        //        var user = await _context.users.FindAsync(id);
        //        if (user == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.users.Remove(user);
        //        await _context.SaveChangesAsync();

        //        return NoContent();
        //    }

        //    private bool UserExists(int id)
        //    {
        //        return _context.users.Any(e => e.UserId == id);
        //    }
        }
    }
