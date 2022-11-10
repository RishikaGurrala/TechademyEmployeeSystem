using Microsoft.OData.Edm;
using System.ComponentModel.DataAnnotations.Schema;

namespace Techademy_Employee_System.Models
{
    public class Payment
    {
        public int id { get; set; }
        public string? PaymentRule { get; set; }
        [ForeignKey("DesignationName")]
        public string? DesignationName { get; set; }
        
        
    }
}
