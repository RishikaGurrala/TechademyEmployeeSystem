using Techademy_Employee_System.Core.IServices;
using Techademy_Employee_System.Data;
using Techademy_Employee_System.DTO;
using Techademy_Employee_System.Models;

namespace Techademy_Employee_System.Core.Services
{   
    public class UserService : IUserService
    {
        private readonly TechademyDbContext context;
        private readonly IConfiguration config;
        public UserService(TechademyDbContext _context, IConfiguration _config)
        {
            context = _context;
            config = _config;
        }
        public string SignIn(Login1DTO login)
        {
            try
            {
                var log = context.user.FirstOrDefault(x => x.UserName == login.UserName && x.Password == login.Password);
                if (log != null)
                {
                    
                    return new JwtService(config).GenerateToken(
                     log.UserId.ToString(),
                     log.Name,
                    log.UserName,
                    log.Mobile,
                    log.Email,
                     log.Address,
                    log.Gender
                      ) /*"Login Succesfull"*/;
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

        public string SignUp(Users user)
        {
            try

            {
                var users = context.user.FirstOrDefault(x => x.UserName == user.UserName);
                if (user != null)
                {
                    if (users != null)
                    {
                        return "UserName already exist try another one";
                    }
                    else
                    {
                        context.user.Add(user);
                        context.SaveChanges();
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
