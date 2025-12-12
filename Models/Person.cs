using System;

namespace HotelManagementSystem.Models
{
    // НОВЫЙ КЛАСС (Родительский)
    // Сюда вынес общие поля, присущие любому человеку
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}