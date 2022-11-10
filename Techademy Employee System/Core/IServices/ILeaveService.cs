using Techademy_Employee_System.Models;

namespace Techademy_Employee_System.Core.IServices
{
    public interface ILeaveService
    {
        List<Leave> GetLeaves();

        string PostLeaves(Leave leave);
        string DeleteLeaves(int EmpId);
        string UpdateLeaves(int EmpId, Leave leave);
    }
}
