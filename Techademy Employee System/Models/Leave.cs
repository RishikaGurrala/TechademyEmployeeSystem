using Microsoft.OData.Edm;
using System.ComponentModel.DataAnnotations.Schema;

namespace Techademy_Employee_System.Models
{
    public class Leave
    {
        public int id { get; set; }
        public string? LeaveType { get; set; }
        public DateTime  StartDate{ get; set; }
        public DateTime EndDate { get; set; }
        
        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public string? LeaveReason { get; set; }
    }
}
