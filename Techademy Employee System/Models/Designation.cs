using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Techademy_Employee_System.Models
{
    
    public class Designation
    {
        public int id { get; set; }
        public string? DesignationName { get; set; }
        public string? Role { get; set; }
        public string? DepartmentName { get; set; }

    }
}
