using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    [EnableCors("AllowOrigin")]
    public class Users1Controller : ControllerBase
    {
        private readonly IUserService userService;

        public Users1Controller(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpPost]
        [Route("SignUp")]
        public string SignUp([FromBody]Users user)
        {
            return userService.SignUp(user);
        }
        [HttpPost]
        [Route("SignIn")]
        public string SignIn(Login1DTO login)
        {
            return userService.SignIn(login);
        }
    }
}
