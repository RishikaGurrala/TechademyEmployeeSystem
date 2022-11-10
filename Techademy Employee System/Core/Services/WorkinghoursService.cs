using Techademy_Employee_System.Core.IServices;
using Techademy_Employee_System.Data;
using Techademy_Employee_System.Models;

namespace Techademy_Employee_System.Core.Services
{
    public class WorkinghoursService : IWorkinghoursService
    {
        private readonly TechademyDbContext context;
        public WorkinghoursService(TechademyDbContext _context)
        {
            context= _context;
        }

        public string DeleteWorkingHours(int EmpId)
        {
            var p = context.workinghours.FirstOrDefault(p => p.EmployeeId == EmpId);
            var e=context.employee.FirstOrDefault(x=> x.EmployeeId==EmpId);
            WorkingHours hours = new WorkingHours();
            try
            {
                if (p != null && e!=null)
                {
                    context.Remove(p);
                    context.SaveChanges();
                    return "Employee with id "+ EmpId+" working hours deleted successfully";
                }
                else if (e == null)
                {
                    return "There is no such employeee id exists";
                }
                else 
                    return "Employee working hours deletion failed";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<WorkingHours> GetWorkingHours()
        {
            var db = new TechademyDbContext();
            return db.workinghours.ToList();
        }


        public string PostWorkingHours(WorkingHours hours)
        {
            try
            {
                var p = context.employee.FirstOrDefault(x => x.EmployeeId == hours.EmployeeId);

                if (hours != null && p != null)
                {
                    context.workinghours.Add(hours);
                    context.SaveChanges();
                    return "Workinghours Inserted Successfully";
                }
                else if (p == null)
                {
                    return "There is no such EmployeeId Exists";
                }
                else
                {
                    return "Workinghours Insertion Failed";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
   

        public string UpdateWorkingHours(int empid, WorkingHours hours)
        {
            try
            {
                if (hours != null)
                {
                    WorkingHours hrs = new WorkingHours();

                    var p = context.workinghours.FirstOrDefault(x => x.EmployeeId == empid);
                    p.CompanyWorkingHours = hours.CompanyWorkingHours;
                    p.EmployeeWorkingHours= hours.EmployeeWorkingHours;
                    var e = context.employee.FirstOrDefault(x => x.EmployeeId == hours.EmployeeId);
                    if (e != null)
                    {
                        p.EmployeeId = hours.EmployeeId;
                        context.SaveChanges();
                        return "updation sussessfull";
                    }
                    else
                    {
                        return "The EmployeeId is not in the list of Employee choose correct and try again";
                    }
                }
                else
                {
                    return "Workinghours updation failed";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
