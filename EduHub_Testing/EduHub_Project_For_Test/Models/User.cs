using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EduHub_Project_For_Test.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }
        public string? MobileNumber { get; set; }
        public string? UserRole { get; set; }
        public string? ProfileImage { get; set; }
    }
}