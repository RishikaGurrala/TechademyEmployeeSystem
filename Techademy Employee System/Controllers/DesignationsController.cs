using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Techademy_Employee_System.Core.IServices;
using Techademy_Employee_System.Data;
using Techademy_Employee_System.Models;

namespace Techademy_Employee_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationsController : ControllerBase
    {
        private readonly IDesignationService designationservice;

        public DesignationsController(IDesignationService _designationservice)
        { 
            designationservice = _designationservice;
        }
        [HttpGet]
        [Route("Read")]
        public List<Designation> GetDesignation()
        {
            return designationservice.GetDesignation();
        }
        [HttpGet]
        public Designation GetDesignation(string Designation)
        {
            try
            {
                var db = new TechademyDbContext();
                var d = db.designation.FirstOrDefault(x => x.DesignationName == Designation);
                if (d != null)
                {
                    return designationservice.GetDesignation(Designation);
                }
                else
                {
                    return "Not Found";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("Post")]
        public string PostDesignation([FromBody] Designation desig)
        {
            return designationservice.PostDesignation(desig);
        }
        [HttpPut]
        [Route("Put")]
        public string PutDesignation(string DesignationName, [FromBody] Designation desig)
        {
            return designationservice.UpdateDesignation(DesignationName, desig);

        }
        [HttpDelete]
        [Route("Delete")]
        public string DeleteDesignation([FromBody] string DesignationName)
        {
            return designationservice.DeleteDesignation(DesignationName);
        }
    }
}
