using Microsoft.OData.Edm;
using System.ComponentModel.DataAnnotations.Schema;

namespace Techademy_Employee_System.Models
{
    public class Payment
    {
        public string? PaymentRule { get; set; }
        [ForeignKey("DesignationName")]
        public string? DesignationName { get; set; }
        [ForeignKey("CreatedDate")]
        public Date CreatedDate { get; set; }
        public int experience { get;  set; }
    }
}
