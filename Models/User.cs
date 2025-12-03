using System;

namespace HotelManagementSystem.Models
{
    public enum UserRole
    {
        Administrator,
        Manager,
        Receptionist,
        Director
    }

    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public UserRole Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastLogin { get; set; }

        public User()
        {
            IsActive = true;
        }
    }
}
