using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackFormWebAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Zа-яА-Я0-9-_]{1,}")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z0-9-.]+@[a-zA-Z0-9-.]+?\.[a-zA-Z]{2,3}")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,18}$")]
        public string PhoneNumber { get; set; }
    }
}
