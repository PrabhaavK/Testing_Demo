using EduHub_Project_For_Test.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduHub_Project_For_Test.Services
{
    public interface IUserService
    {
        Task<User> GetUserAsync(int userID);
        Task<IEnumerable<User>> GetAllStudentsAsync();
        Task<User> CreateUserAsync(User newUser);
        Task<User> UpdateUserAsync(int userId, User updatedUser);
        Task<bool> DeleteUserAsync(int userId);
    }
}
