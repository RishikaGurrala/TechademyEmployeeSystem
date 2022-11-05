using Microsoft.OData.Edm;
using System.ComponentModel.DataAnnotations.Schema;

namespace Techademy_Employee_System.Models
{
    public class Leave
    {
        public string? LeaveType { get; set; }
        public Date Date { get; set; }
        public int Days { get; set; }
        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public string? LeaveReason { get; set; }
    }
}
