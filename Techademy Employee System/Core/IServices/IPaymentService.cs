using Techademy_Employee_System.Models;

namespace Techademy_Employee_System.Core.IServices
{
    public interface IPaymentService
    {
        List<Payment> GetPayment();

        string PostPayment(Payment payment);
        string DeletePayment(string designame);
        string UpdatePayment(string designame, Payment payment);
    }
}
