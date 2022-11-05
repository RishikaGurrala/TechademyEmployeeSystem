using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace Techademy_Employee_System.Models
{
    
    public class WorkingHours
    {
        [Key]
        public string? CompanyWorkingHours { get; set; }
        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public string? EmployeeWorkingHours { get; set; }
    }
}
