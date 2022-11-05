using Techademy_Employee_System.Models;

namespace Techademy_Employee_System.Core.IServices
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployee();

        string PostEmployee(Employee emp);
        string DeleteEmployee(int EmpId);
        string UpdateEmployee(int EmpId, Employee emp);
    }
}
