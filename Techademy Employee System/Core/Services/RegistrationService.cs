using Techademy_Employee_System.Core.IServices;
using Techademy_Employee_System.Data;
using Techademy_Employee_System.DTO;
using Techademy_Employee_System.Models;

namespace Techademy_Employee_System.Core.Services
{
    public class RegistrationService:IRegistrationService
    {
        private readonly TechademyDbContext emp;
        private readonly IConfiguration config;
        public RegistrationService(TechademyDbContext _emp, IConfiguration _config)
        {
            emp = _emp;
            config = _config;
        }

        public string SignIn(LoginDTO loginDTO)
        {
            try
            {
                var login = emp.users.FirstOrDefault(x => x.Email == loginDTO.Email && x.Password == loginDTO.Password);
                if (login != null)
                {
                    return "Login Succesfull";
                }
                else
                {
                    return "Login Failed";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string SignUp(User user)
        {
            try

            {
                var users = emp.users.FirstOrDefault(x => x.Email == user.Email);
                if (user != null)
                {
                    if (users != null)
                    {
                        return "Email already exist try another one";
                    }
                    else
                    {
                        emp.users.Add(user);
                        emp.SaveChanges();
                        return "registered successfully";
                    }
                }
                else
                {
                    return "registration failed";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
