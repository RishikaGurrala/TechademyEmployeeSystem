using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Techademy_Employee_System.Core.IServices;
using Techademy_Employee_System.Data;
using Techademy_Employee_System.Models;

namespace Techademy_Employee_System.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly TechademyDbContext context;
        public EmployeeService(TechademyDbContext _context)
        {
            context = _context;
        }

        public string DeleteEmployee(int EmpId)
        {
            var p = context.employee.FirstOrDefault(p => p.EmployeeId == EmpId);
            Employee emp = new Employee();
            try
            {
                if (p != null)
                {
                    context.Remove(p);
                    context.SaveChanges();
                    return "Employee deleted successfully";
                }
                else
                    return "Employee deletion failed";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Employee> GetEmployee()
        {
            var db = new TechademyDbContext();
            return db.employee.ToList();
        }

        public string PostEmployee(Employee emp)
        {
            try
            {
                var p = context.designation.FirstOrDefault(x => x.DesignationName == emp.DesignationName);

                if (emp != null && p!=null)
                {
                    emp.CreatedDate = DateTime.Now;
                    context.employee.Add(emp);
                    context.SaveChanges();
                    return "Employee Inserted Successfully";
                }
                else if(p==null)
                {
                    return "There is no such Designation Exists";
                }
                else
                {
                    return "Employee Insertion Failed";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateEmployee(int EmpId, Employee emp)
        {
            try
            {
                if (emp != null)
                {
                    Employee empl = new Employee();

                    var p = context.employee.FirstOrDefault(x => x.EmployeeId == EmpId);
                    p.EmployeeName = emp.EmployeeName;
                    p.PhoneNo = emp.PhoneNo;
                    p.EmailId = emp.EmailId;
                    p.Address = emp.Address;
                    
                    var e=context.designation.FirstOrDefault(x=> x.DesignationName==emp.DesignationName);
                    if (e != null)
                    {
                        p.DesignationName = emp.DesignationName;
                        context.SaveChanges();
                        return "updation sussessfull";
                    }
                    else
                    {
                        return "The designation is not in the list of designation choose other and try again";
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
