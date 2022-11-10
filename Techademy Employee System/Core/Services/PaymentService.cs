using Techademy_Employee_System.Core.IServices;
using Techademy_Employee_System.Data;
using Techademy_Employee_System.Models;

namespace Techademy_Employee_System.Core.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly TechademyDbContext context;
        public PaymentService(TechademyDbContext _context)
        {
           context = _context;
        }

        public string DeletePayment(string designame)
        {
            var p = context.payments.FirstOrDefault(p => p.DesignationName == designame);
            var e = context.designation.FirstOrDefault(x => x.DesignationName == designame);
            Payment payment = new Payment();
            try
            {
                if (p != null && e != null)
                {
                    context.Remove(p);
                    context.SaveChanges();
                    return "Payment rule deleted successfully";
                }
                else if (e == null)
                {
                    return "There is no designation exists";
                }
                else
                    return "Payment rule deletion failed";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Payment> GetPayment()
        {
            var db = new TechademyDbContext();
            return db.payments.ToList();
        }

        public string PostPayment(Payment payment)
        {
            try
            {
                var p = context.designation.FirstOrDefault(x => x.DesignationName == payment.DesignationName);

                if (payment != null && p != null)
                {
                    context.payments.Add(payment);
                    context.SaveChanges();
                    return "Payment rule Inserted Successfully";
                }
                else if (p == null)
                {
                    return "There is no such Designation Exists";
                }
                else
                {
                    return "Payment rule Insertion Failed";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdatePayment(string designame, Payment payment)
        {
            try
            {
                if (payment != null)
                {
                    Payment pay = new Payment();

                    var p = context.payments.FirstOrDefault(x => x.DesignationName == designame);
                    p.PaymentRule = payment.PaymentRule;

                    
                    var e = context.designation.FirstOrDefault(x => x.DesignationName == payment.DesignationName);
                    if (e != null)
                    {
                        p.DesignationName = payment.DesignationName;
                        context.SaveChanges();
                        return "updation sussessfull";
                    }
                    else
                    {
                        return "The Designation name is not in the list of Designations choose correct and try again";
                    }
                }
                else
                {
                    return "Designation updation failed";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
