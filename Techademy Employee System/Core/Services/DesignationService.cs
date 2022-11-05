using Microsoft.CodeAnalysis;
using Techademy_Employee_System.Core.IServices;
using Techademy_Employee_System.Data;
using Techademy_Employee_System.Models;

namespace Techademy_Employee_System.Core.Services
{
    public class DesignationService : IDesignationService
    {
        private readonly TechademyDbContext _context;
        public DesignationService(TechademyDbContext context)
        {
         _context = context;
        }
        public string DeleteDesignation(string DesignationName)
        {
            var p = _context.designation.FirstOrDefault(p => p.DesignationName == DesignationName);
            Designation des = new Designation();
            try
            {
                if (p != null)
                {


                    _context.Remove(p);
                    _context.SaveChanges();
                    return "Designation deleted successfully";
                }
                else
                    return "Designation deletion failed";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Designation> GetDesignation()
        {
            var db = new TechademyDbContext();
            return db.designation.ToList();
        }

        public Designation GetDesignation(string DesignationName)
        {
            var db = new TechademyDbContext();
            return db.designation.FirstOrDefault(x => x.DesignationName == DesignationName);
        }

        public string PostDesignation(Designation desig)
        {
            try
            {
                if (desig != null)
                {
                    _context.designation.Add(desig);
                    _context.SaveChanges();
                    return "Designation Inserted Successfully";
                }
                else
                {
                    return "Designation Insertion Failed";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateDesignation(string DesignationName, Designation desig)
        {
            try
            {
                if (desig != null)
                {
                    Designation des = new Designation();
                    var p = _context.designation.FirstOrDefault(x => x.DesignationName== DesignationName);
                    p.DesignationName = desig.DesignationName;
                    p.Role = desig.Role;
                    p.DepartmentName = desig.DepartmentName;
                    _context.SaveChanges();
                      return "Designation updation sussessfull";
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
