using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MSTARTHiringTask.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public DateTime Server_DateTime { get; set; }
        [Required]
        public DateTime DateTime_UTC { get; set; }
        [Required]
        public DateTime Update_DateTime_UTC { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string First_Name { get; set; }
        [Required]
        public string Last_Name { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public int Gender { get; set; }
        [Required]
        public DateTime Date_Of_Birth { get; set; }
    }

    public enum UserStatus
    {
        Active,
        Inactive,
        Deleted
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
