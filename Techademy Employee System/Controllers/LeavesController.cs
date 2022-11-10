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
    public class LeavesController : ControllerBase
    {
        private readonly ILeaveService leaveService;

        public LeavesController(ILeaveService _leaveService)
        {
           leaveService = _leaveService;
        }
        [HttpGet]
        [Route("Read")]
        public List<Leave> GetLeaves()
        {
            return leaveService.GetLeaves();
        }
        [HttpPost]
        [Route("Post")]
        public string PostLeaves([FromBody] Leave leave)
        {
            return leaveService.PostLeaves(leave);
        }
        [HttpPut("{EmployeeId}")]

        public string PutLeaves(int empid, Leave leave)
        {
            return leaveService.UpdateLeaves(empid, leave);

        }
        [HttpDelete("{EmpId}")]

        public string DeleteLeaves(int EmpId)
        {
            return leaveService.DeleteLeaves(EmpId);
        }

    }
}
