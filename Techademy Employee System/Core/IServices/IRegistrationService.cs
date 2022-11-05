using Techademy_Employee_System.DTO;
using Techademy_Employee_System.Models;

namespace Techademy_Employee_System.Core.IServices
{
    public interface IRegistrationService
    {
        string SignIn(LoginDTO loginDTO);
        string SignUp(User user);
    }
}
