using Techademy_Employee_System.Core.IServices;
using Techademy_Employee_System.Data;
using Techademy_Employee_System.Models;

namespace Techademy_Employee_System.Core.Services
{
    public class LeaveService : ILeaveService
    {
        private readonly TechademyDbContext context;
        public LeaveService(TechademyDbContext _context)
        {
            context = _context;
        }

        public string DeleteLeaves(int EmpId)
        {
            var p = context.leaves.FirstOrDefault(p => p.EmployeeId == EmpId);
            var e = context.employee.FirstOrDefault(x => x.EmployeeId == EmpId);
            Leave leave = new Leave();
            try
            {
                if (p != null && e != null)
                {
                    context.Remove(p);
                    context.SaveChanges();
                    return "Leave request deleted successfully";
                }
                else if (e == null)
                {
                    return "There is no EmployeeId exists";
                }
                else
                    return "Leave Request deletion failed";
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Leave> GetLeaves()
        {
            var db = new TechademyDbContext();
            return db.leaves.ToList();
        }

        public string PostLeaves(Leave leave)
        {
            try
            {
                var p = context.employee.FirstOrDefault(x => x.EmployeeId== leave.EmployeeId);

                if (leave != null && p != null)
                {
                    context.leaves.Add(leave);
                    context.SaveChanges();
                    return "Leave request Inserted Successfully";
                }
                else if (p == null)
                {
                    return "There is no such EmployeeId Exists";
                }
                else
                {
                    return "Leave request Insertion Failed";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateLeaves(int EmpId, Leave leave)
        {
            try
            {
                if (leave != null)
                {
                    Leave leaves = new Leave();

                    var p = context.leaves.FirstOrDefault(x => x.EmployeeId == EmpId);
                    p.LeaveType = leave.LeaveType;
                    p.StartDate = leave.StartDate;
                    p.EndDate = leave.EndDate;
                    p.LeaveReason = leave.LeaveReason;
                    var e = context.employee.FirstOrDefault(x => x.EmployeeId == leave.EmployeeId);
                    if (e != null)
                    {
                        p.EmployeeId = leave.EmployeeId;
                        context.SaveChanges();
                        return "updation sussessfull";
                    }
                    else
                    {
                        return "The employeeid is not in the list of employeeid's choose correct and try again";
                    }
                }
                else
                {
                    return "leave request updation failed";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
