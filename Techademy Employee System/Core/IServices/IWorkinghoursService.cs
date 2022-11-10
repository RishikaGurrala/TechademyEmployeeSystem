using Techademy_Employee_System.Models;

namespace Techademy_Employee_System.Core.IServices
{
    public interface IWorkinghoursService
    {
        List<WorkingHours> GetWorkingHours();

        string PostWorkingHours(WorkingHours hours);
        string DeleteWorkingHours(int EmpId);
        string UpdateWorkingHours(int empid, WorkingHours hours);
    }
}
