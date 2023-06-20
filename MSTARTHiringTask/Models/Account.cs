using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MSTARTHiringTask.Models
{
    public class Account
    {
        [Key]
        public int ID { get; set; }
        public int User_ID { get; set; }
        [Required]
        public DateTime Server_DateTime { get; set; }
        [Required]
        public DateTime DateTime_UTC { get; set; }
        [Required]
        public DateTime Update_DateTime_UTC { get; set; }
        [Required]
        public string Account_Number { get; set; }
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public int Status { get; set; }
    }

    public struct Currency
    {
        public const string USD = "USD";
        public const string EUR = "EUR";
        public const string JD = "JD";
    }

    public enum AccountStatus
    {
        Active,
        Inactive,
        Deleted
    }
}
