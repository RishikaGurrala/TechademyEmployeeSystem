using Techademy_Employee_System.Models;

namespace Techademy_Employee_System.Core.IServices
{
    public interface IDesignationService
    {
        List<Designation> GetDesignation();
        Designation GetDesignation(string DesignationName);

        string PostDesignation(Designation desig);
        string DeleteDesignation(string DesignationName);
        string UpdateDesignation(string DesignationName, Designation desig);
    }
}
