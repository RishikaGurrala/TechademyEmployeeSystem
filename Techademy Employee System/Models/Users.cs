﻿using System.ComponentModel.DataAnnotations;

namespace Techademy_Employee_System.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public string? Password { get; set; }
    }
}
