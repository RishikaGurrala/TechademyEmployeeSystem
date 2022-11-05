using Microsoft.OData.Edm;
using System.ComponentModel.DataAnnotations.Schema;

namespace Techademy_Employee_System.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public int PhoneNo { get; set; }
        public string? EmailId { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedDate { get; set; }
        
        [ForeignKey("DesignationName")]
        public string? DesignationName { get; set; }
        
        
    }
}
