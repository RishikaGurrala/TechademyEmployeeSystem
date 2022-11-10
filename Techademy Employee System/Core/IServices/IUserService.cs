using Techademy_Employee_System.DTO;
using Techademy_Employee_System.Models;

namespace Techademy_Employee_System.Core.IServices
{
    public interface IUserService
    {
        public string SignUp(Users user);
        public string SignIn(Login1DTO login);
    }
}
