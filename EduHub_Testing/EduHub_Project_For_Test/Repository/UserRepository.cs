using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EduHub_Project_For_Test.Models;

namespace EduHub_Project_For_Test.Repository
{
    public class UserRepository : IUserService
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Method to get a specific user by ID
        public async Task<User> GetUserAsync(int userID)
        {
            return await _dbContext.Users.FindAsync(userID);
        }

        // Method to get all students
        public async Task<IEnumerable<User>> GetAllStudentsAsync()
        {
            return await _dbContext.Users.Where(u => u.UserRole == "Student").ToListAsync();
        }

        // Method to create a new user
        public async Task<User> CreateUserAsync(User newUser)
        {
            if (newUser == null)
            {
                throw new ArgumentNullException(nameof(newUser));
            }

            if (await _dbContext.Users.AnyAsync(u => u.Email == newUser.Email))
            {
                throw new InvalidOperationException("User Already Exists");
            }

            if (string.IsNullOrWhiteSpace(newUser.Email))
            {
                throw new ArgumentException("Email cannot be empty");
            }

            if (string.IsNullOrWhiteSpace(newUser.UserName))
            {
                throw new ArgumentException("Username cannot be empty");
            }

            _dbContext.Users.Add(newUser);
            await _dbContext.SaveChangesAsync();
            return newUser;
        }

        // Method to update an existing user
        public async Task<User> UpdateUserAsync(int userId, User updatedUser)
        {
            if (updatedUser == null)
            {
                throw new ArgumentNullException(nameof(updatedUser));
            }

            var user = await _dbContext.Users.FindAsync(userId);
            if (user != null)
            {
                user.UserName = updatedUser.UserName;
                user.Email = updatedUser.Email;
                user.Password = updatedUser.Password;
                user.UserRole = updatedUser.UserRole;
                user.MobileNumber = updatedUser.MobileNumber;
                user.ProfileImage = updatedUser.ProfileImage;

                await _dbContext.SaveChangesAsync();
            }

            return user;
        }

        // Method to delete a user
        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
